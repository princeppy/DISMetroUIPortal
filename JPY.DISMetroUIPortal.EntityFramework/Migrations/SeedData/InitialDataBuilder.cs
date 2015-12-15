using JPY.DISMetroUIPortal.EntityFramework;
using EntityFramework.DynamicFilters;

namespace JPY.DISMetroUIPortal.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly DISMetroUIPortalDbContext _context;

        public InitialDataBuilder(DISMetroUIPortalDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
