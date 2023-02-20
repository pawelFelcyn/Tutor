using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI;

public partial class StartShell : Shell
{
	public StartShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("//Login/Register", typeof(RegistrationPage));
	}
}