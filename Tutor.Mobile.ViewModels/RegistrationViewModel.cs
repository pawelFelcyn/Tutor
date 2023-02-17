using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class RegistrationViewModel : ViewModel
{
	[ObservableProperty]
	private RegisterUserDto registerUserDto;
	[ObservableProperty]
	private int selectedRoleIndex;
	public string[] AllowedRoles { get; }

	public RegistrationViewModel()
	{
		Title = "Registration";
		AllowedRoles = new string[] { "User", "Tutor" };
		RegisterUserDto = new(null, null, AllowedRoles[0], null, null, null, null);
	}

    partial void OnSelectedRoleIndexChanged(int value)
    {
		var roleProperty = typeof(RegisterUserDto).GetProperty(nameof(RegisterUserDto.Role));
		roleProperty.SetValue(RegisterUserDto, AllowedRoles[value]);
    }

    [RelayCommand]
	private async Task ConfirmAsync()
	{

	}
}
