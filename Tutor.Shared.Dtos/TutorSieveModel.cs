using Sieve.Models;
using System.Drawing;
using System.Text;

namespace Tutor.Shared.Dtos;

public class TutorSieveModel : SieveModel
{
    public virtual string GetQueryString()
    {
        var sb = new StringBuilder();

        if (Filters is not null)
        {
            sb.Append($"filters={Filters}");
        }

        return sb.ToString();
    }
}
