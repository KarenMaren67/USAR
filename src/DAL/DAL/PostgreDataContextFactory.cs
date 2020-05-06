using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class PostgreDataContextFactory : IDesignTimeDbContextFactory<PostgreDataContext>
    {
        public PostgreDataContext CreateDbContext(string[] args)
        {
            return new PostgreDataContext();
        }
    }
}
