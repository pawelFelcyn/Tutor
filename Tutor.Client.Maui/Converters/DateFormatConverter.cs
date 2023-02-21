using System.Globalization;

namespace Tutor.Client.Maui.Converters;

public class DateFormatConverter : IValueConverter, IMarkupExtension
{

    public string Format { get; set; } = "dd.MM.yyyy";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is DateTime dateTime ? dateTime.ToString(Format) : Binding.DoNothing;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new InvalidOperationException("This converter can be used only woth one way binding");
    }

    public object ProvideValue(IServiceProvider serviceProvider) => this;
}
