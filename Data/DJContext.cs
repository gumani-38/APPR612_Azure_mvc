using APPR612_Activity2.Models;
using Microsoft.EntityFrameworkCore;

namespace APPR612_Activity2.Data
{
    public class DJContext : DbContext
    {
        public DJContext(DbContextOptions<DJContext> options) : base(options) { }
            public DbSet<DJ> DJ {get;set;}
        
    }
}
