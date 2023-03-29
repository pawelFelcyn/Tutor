using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Client.Logic.Helpers;

public class ClientSubjectValidationHelper : ISubjectValidationHelper
{
    public bool Exists(Guid id) => true;
}
