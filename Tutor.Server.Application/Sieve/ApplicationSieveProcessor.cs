using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Application.Sieve;

internal class ApplicationSieveProcessor : SieveProcessor
{
    public ApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.Property<Advertisement>(a => a.PricePerHour)
              .CanFilter()
              .CanSort();
        mapper.Property<Advertisement>(a => a.CreationDate)
              .CanFilter()
              .CanSort();
        mapper.Property<Advertisement>(a => a.LastModificationDate)
              .CanFilter()
              .CanSort();
        mapper.Property<Advertisement>(a => a.Title)
              .CanFilter()
              .CanSort();
        mapper.Property<Advertisement>(a => a.Description)
             .CanFilter()
             .CanSort();
        mapper.Property<Advertisement>(a => a.Levels)
              .CanFilter()
              .CanSort();
        mapper.Property<Advertisement>(a => a.Subject)
              .CanFilter()
              .CanSort();
        mapper.Property<Advertisement>(a => a.Modes)
             .CanFilter()
             .CanSort();

        return mapper;
    }
}
