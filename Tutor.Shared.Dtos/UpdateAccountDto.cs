namespace Tutor.Shared.Dtos;

public class UpdateAccountDto
{
    public UpdateUserDto UserData { get; set; }
    public  bool RemoveImageIfNullGiven { get; set; }
    public CreateProfileImageDto ImageData { get; set; }
}
