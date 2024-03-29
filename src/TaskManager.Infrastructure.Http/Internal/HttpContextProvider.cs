using Microsoft.AspNetCore.Http;
using TaskManager.Infrastructure.Http.Constants;

namespace TaskManager.Infrastructure.Http.Internal
{
    public sealed class HttpContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextProvider(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetTenantId()
        {
            var tenantIdItem = _httpContextAccessor
                .HttpContext?
                .Request
                .Headers[HeaderKeys.TenantId];

            if (!tenantIdItem.HasValue ||
                !Guid.TryParse(tenantIdItem.Value, out Guid tenantId))
            {
                throw new ApplicationException("Tenant Id is not present");
            }

            return tenantId;
        }
    }
}
