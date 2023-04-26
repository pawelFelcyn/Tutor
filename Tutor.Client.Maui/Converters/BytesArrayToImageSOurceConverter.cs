using System.Globalization;

namespace Tutor.Client.Maui.Converters;

public class BytesArrayToImageSourceConverter : IMarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not byte[] bytes)
        {
            return Binding.DoNothing;
        }

        var stream = new MemoryStream(bytes);
        return ImageSource.FromStream(() => stream);   
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object ProvideValue(IServiceProvider serviceProvider) => this;
}
