using System.Globalization;

namespace Tutor.Client.Maui.Converters;

public class NegationConverter : IValueConverter, IMarkupExtension
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool @bool ? !@bool : Binding.DoNothing;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool @bool ? !@bool : Binding.DoNothing;

    public object ProvideValue(IServiceProvider serviceProvider) => this;
}
