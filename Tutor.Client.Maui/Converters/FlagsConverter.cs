﻿using System.Globalization;

namespace Tutor.Client.Maui.Converters;

public class FlagsConverter<T> : IValueConverter, IMarkupExtension where T : Enum
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not T)
        {
            return Binding.DoNothing;
        }

        var indexes = new List<int>();
        var binary = System.Convert.ToString((int)value, 2);

        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                indexes.Add(binary.Length - i - 1);
            }
        }

        return indexes.ToArray();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int[] array)
        {
            return Binding.DoNothing;
        }

        var flagValue = 0;
        for (int i = 0; i < array.Length; i++)
        {
            flagValue += (int)Math.Pow(2, (double)(array[i]));
        }

        return (T)(object)flagValue;
    }

    public object ProvideValue(IServiceProvider serviceProvider) => this;
}
