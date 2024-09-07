using Identidad.Models;

namespace Identidad.Helpers
{
    public class AuditLogger
    {
        private readonly IdentidadDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditLogger(IdentidadDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogClaimChangeAsync(string userId, string claimType, string claimValue, string action)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var changedBy = httpContext?.User.Identity.Name ?? "Unknown";

            var auditLog = new ClaimAudit
            {
                UserId = userId,
                ClaimType = claimType,
                ClaimValue = claimValue,
                Action = action,
                DateTime = DateTime.Now,
                ChangedBy = httpContext.User.Identity.Name // O algún identificador del usuario que hizo el cambio
            };

            _context.ClaimAudits.Add(auditLog);
            await _context.SaveChangesAsync();
        }
    }
}