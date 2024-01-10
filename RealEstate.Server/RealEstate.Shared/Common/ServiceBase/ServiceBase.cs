using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace RealEstate.Shared.Common.ServiceBase
{
    public abstract class ServiceBase<TDbContext> where TDbContext : DbContext
    {
        protected readonly ILogger _logger;
        protected readonly TDbContext _dbContext;
        protected readonly IHttpContextAccessor _httpContext;
        protected ServiceBase(ILogger logger, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
            _dbContext = httpContext.HttpContext!.RequestServices.GetRequiredService<TDbContext>();
        }
        protected ServiceBase(ILogger logger,IHttpContextAccessor httpContext, TDbContext dbContext)
        {
            _logger = logger;
            _httpContext = httpContext;
            _dbContext = dbContext;
        }
    }
}
