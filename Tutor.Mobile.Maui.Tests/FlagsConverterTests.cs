using FluentAssertions;
using System.Globalization;
using Tutor.Client.Maui.Converters;

namespace Tutor.Mobile.Maui.Tests;

public class FlagsConverterTests
{
    private readonly FlagsConverter<TestFlags> _converter;

    public FlagsConverterTests()
    {
        _converter = new();   
    }

    [Flags]
    public enum TestFlags
    {
        A = 1,
        B = 2,
        C = 4,
        D = 8,
        E = 16
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { TestFlags.A, new int[] { 0 } };
        yield return new object[] { TestFlags.A | TestFlags.B, new int[] { 0, 1 } };
        yield return new object[] { TestFlags.A | TestFlags.D, new int[] { 0, 3 } };
        yield return new object[] { TestFlags.A | TestFlags.C | TestFlags.E, new int[] { 0, 2, 4 } };
        yield return new object[] { TestFlags.C | TestFlags.E, new int[] { 2, 4 } };
        yield return new object[] { TestFlags.A | TestFlags.B | TestFlags.C | TestFlags.D | TestFlags.E, new int[] { 0, 1, 2, 3, 4 } };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    private void Convert_ForFlagsGiven_ReturnsProperIndexesArray(TestFlags flags, int[] expected)
    {
        var result = (IList<int>)_converter.Convert(flags, typeof(int[]), null, CultureInfo.CurrentCulture);

        result.Count.Should().Be(expected.Length);
        for (int i = 0; i < result.Count; i++)
        {
            expected.Should().Contain(result[0]);
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    private void ConvertBack_ForIndexesArrayGiven_ReturnsProperEnum(TestFlags expected, int[] input)
    {
        var result = (TestFlags)_converter.ConvertBack(input, typeof(TestFlags), null, CultureInfo.CurrentCulture);
        result.Should().Be(expected);
    }
}
