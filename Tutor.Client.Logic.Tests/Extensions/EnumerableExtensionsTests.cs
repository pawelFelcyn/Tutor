using Tutor.Client.Logic.Extensions;

namespace Tutor.Client.Logic.Tests.Extensions;

public class EnumerableExtensionsTests
{
    public static IEnumerable<object[]> GetTestData_FirstIndex()
    {
        yield return new object[] { (int v) => v == 2, 1 };
        yield return new object[] { (int v) => v > 0, 0 };
        yield return new object[] { (int v) => v > 4, 4 };
        yield return new object[] { (int v) => v % 5 == 0, 4 };
    }


    [Theory]
    [MemberData(nameof(GetTestData_FirstIndex))]
    public void FirstIndex_ForGivenCondition_ReturnsIndexOfFirstItemMeetingThatCondition(Func<int, bool> condition, int expected)
    {
        var source = new int[] { 1, 2, 3, 4, 5, 6 };
        source.FirstIndex(condition).Should().Be(expected);
    }

    [Fact]
    public void FirstIndex_ForSourceNull_ThrowsArgumentNullException()
    {
        int[] src = null!;
        var action = () =>  src.FirstIndex(v => true);
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void FirstIndex_ForConditionNull_ThorowsArgumentNullException()
    {
        int[] src = new int[] { 1, 2, 3};
        var action = () => src.FirstIndex(null);
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void FirstIndex_ForNoElementMeetingCondition_ReturnsMinutOne()
    {
        int[] src = new int[] { 1, 2, 3 };
        src.FirstIndex(v => false).Should().Be(-1);
    }
}
