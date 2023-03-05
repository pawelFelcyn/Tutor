using Tutor.Shared.Dtos;

namespace Tutor.Client.Models;

public class AdvertisementsFilterModel
{
    public AdvertisementsFilterModel(AdvertisementsSieveModel originalFilters, IEnumerable<SubjectDto> allSubjects)
    {
        OriginalFilters = originalFilters;
        Filters = (AdvertisementsSieveModel)OriginalFilters.Clone();
        AllSubjects = allSubjects;
    }

    public AdvertisementsSieveModel OriginalFilters { get; }
    public AdvertisementsSieveModel Filters { get; }
    public IEnumerable<SubjectDto> AllSubjects { get; }
}
