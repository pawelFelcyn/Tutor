using System.Windows.Input;

namespace Tutor.MobileUI.Controls;

public partial class ProfileImage : ContentView
{
	public ProfileImage()
	{
		InitializeComponent();
	}

    public ICommand ClickedCommand 
	{ 
		get => (ICommand)GetValue(ClickedCommandProperty);
		set => SetValue(ClickedCommandProperty, value);
	}

    public object ClickedCommandParameter
    {
        get => GetValue(ClickedCommandParameterProperty);
        set => SetValue(ClickedCommandParameterProperty, value);
    }

    public double SizeRequest 
    {
        get => (double)GetValue(SizeRequestProperty); 
        set => SetValue(SizeRequestProperty, value);
    }

    public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create(nameof(ClickedCommand),
		typeof(ICommand), typeof(ProfileImage), null);

    public static readonly BindableProperty ClickedCommandParameterProperty = BindableProperty.Create(nameof(ClickedCommandParameter),
        typeof(object), typeof(ProfileImage), null);

    public static readonly BindableProperty SizeRequestProperty = BindableProperty.Create(nameof(SizeRequest),
        typeof(double), typeof(ProfileImage), 100.0);
}