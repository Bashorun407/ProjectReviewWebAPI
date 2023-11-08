using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record SelectServiceProviderDto /*(string? serviceProviderId);*/
    {
        public string? ServiceProviderId { get; set; }
    }
}
