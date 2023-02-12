using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Client.Logic.Helpers;

internal class ClientEmailValidationHelper : IEmailValidationHelper
{
    public bool IsEmailTaken(string email) => false;
}