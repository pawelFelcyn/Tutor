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

    public bool IsEditButtonVisible
    {
        get => (bool)GetValue(IsEditButtonVisibleProperty);
        set => SetValue(IsEditButtonVisibleProperty, value);
    }

    public ICommand EditButtonCommand
    {
        get => (ICommand)GetValue(EditButtonCommandProperty);
        set => SetValue(EditButtonCommandProperty, value);
    }

    public object EditButtonCommandParameter
    {
        get => GetValue(EditButtonCommandParameterProperty);
        set => SetValue(EditButtonCommandParameterProperty, value);
    }

    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create(nameof(ClickedCommand),
		typeof(ICommand), typeof(ProfileImage), null);

    public static readonly BindableProperty ClickedCommandParameterProperty = BindableProperty.Create(nameof(ClickedCommandParameter),
        typeof(object), typeof(ProfileImage), null);

    public static readonly BindableProperty SizeRequestProperty = BindableProperty.Create(nameof(SizeRequest),
        typeof(double), typeof(ProfileImage), 100.0);

    public static readonly BindableProperty IsEditButtonVisibleProperty = BindableProperty.Create(nameof(IsEditButtonVisible),
        typeof(bool), typeof(ProfileImage), false);

    public static readonly BindableProperty EditButtonCommandProperty = BindableProperty.Create(nameof(EditButtonCommand),
        typeof(ICommand), typeof(ProfileImage), null);

    public static readonly BindableProperty EditButtonCommandParameterProperty = BindableProperty.Create(nameof(EditButtonCommandParameter),
        typeof(object), typeof(ProfileImage), null);

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source),
        typeof(ImageSource), typeof(ProfileImage), null);
}