using System.Text;

namespace Tutor.Shared.Dtos;

public class TutorSieveModel
{
    public int PageSize { get; set; } = 15;
    public int PageNumber { get; set; } = 1;

    public virtual string GetQueryString()
    {
        var sb = new StringBuilder();
        sb.Append($"pageSize={PageSize}&pageNumber{PageNumber}");
        return sb.ToString();
    }
}
