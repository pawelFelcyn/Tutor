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

    public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create(nameof(ClickedCommand),
		typeof(ICommand), typeof(ProfileImage), null);

    public static readonly BindableProperty ClickedCommandParameterProperty = BindableProperty.Create(nameof(ClickedCommandParameter),
        typeof(object), typeof(ProfileImage), null);
}