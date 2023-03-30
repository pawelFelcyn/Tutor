using System.Globalization;

namespace Tutor.Client.Maui.Converters;

public class AndMultiConverter : IMultiValueConverter, IMarkupExtension
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        => values?.All(v => v is bool b && b) ?? Binding.DoNothing;

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new InvalidOperationException("This converter can be uesd only with one way binding.");
    }

    public object ProvideValue(IServiceProvider serviceProvider) => this;
}
