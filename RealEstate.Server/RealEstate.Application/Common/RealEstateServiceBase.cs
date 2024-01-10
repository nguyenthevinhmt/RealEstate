using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RealEstate.Infrastructure.Persistence;
using RealEstate.Shared.Common.ServiceBase;

namespace RealEstate.Application.Common
{
    public class RealEstateServiceBase : ServiceBase<ApplicationDbContext>
    {
        public RealEstateServiceBase(ILogger logger, IHttpContextAccessor httpContext, ApplicationDbContext context) : base(logger, httpContext, context)
        {
        }
    }
}
