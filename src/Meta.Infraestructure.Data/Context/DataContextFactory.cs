using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Meta.Infraestructure.Data.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            return new DataContext(builder.Options);
        }
    }
}
