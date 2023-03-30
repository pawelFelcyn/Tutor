using Sieve.Models;

namespace Tutor.Shared.Dtos;

public class AdvertisementsSieveModel : TutorSieveModel
{
    public bool CreatedByClientOnly { get; set; }

    public override string GetQueryString()
    {
        var baseQuery = base.GetQueryString();
        return $"{baseQuery}&createdByClientOnly={CreatedByClientOnly}";
    }
}
