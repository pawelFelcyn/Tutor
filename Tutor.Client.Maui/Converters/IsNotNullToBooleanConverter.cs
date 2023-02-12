using System.Globalization;

namespace Tutor.Client.Maui.Converters;

public class IsNotNullToBooleanConverter : IMarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is not null;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => Binding.DoNothing;

    public object ProvideValue(IServiceProvider serviceProvider) => this;
}
