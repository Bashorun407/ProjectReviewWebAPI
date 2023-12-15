using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record SelectServiceProviderDto 
    {
        public string? ServiceProviderId { get; set; }
    }
}
