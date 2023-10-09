using BloodTransferAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodTransferAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<BloodTransferModel> BloodTransfers { get; set; }
    }
}
