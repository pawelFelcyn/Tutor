using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Tutor.Shared.Enums;

namespace Tutor.Client.Models;

public class AdvertisementsSieveModel : ICloneable
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public EducationLevels Levels { get; set; }
    public Guid Subject { get; set; }

    public object Clone()
    {
        var json = JsonConvert.SerializeObject(this);
        return JsonConvert.DeserializeObject<AdvertisementsSieveModel>(json) 
            ?? throw new InvalidOperationException();
    }
}
