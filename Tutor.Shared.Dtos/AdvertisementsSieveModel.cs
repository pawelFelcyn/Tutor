using System.Text;

namespace Tutor.Shared.Dtos;

public class AdvertisementsSieveModel : TutorSieveModel
{
    public bool CreatedByClientOnly { get; set; }
    public string Title { get; set; }
    public Guid? SelectedSubject { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    public override string GetQueryString()
    {
        var baseQuery = base.GetQueryString();
        var sb = new StringBuilder();
        sb.Append($"{baseQuery}&createdByClientOnly={CreatedByClientOnly}");

        if (!string.IsNullOrWhiteSpace(Title))
        {
            sb.Append($"&{nameof(Title)}={Title}");
        }

        if (SelectedSubject.HasValue)
        {
            sb.Append($"&{nameof(SelectedSubject)}={SelectedSubject}");
        }

        if (MinPrice.HasValue)
        {
            sb.Append($"&{nameof(MinPrice)}={MinPrice}");
        }

        if (MaxPrice.HasValue)
        {
            sb.Append($"&{nameof(MaxPrice)}={MaxPrice}");
        }

        return sb.ToString();
    }
}
