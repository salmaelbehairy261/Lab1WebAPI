using lab_3.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab_3.Data.Context
{
    public class SchoolContext:IdentityDbContext<Teacher>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Teacher>().ToTable("Teachers");
        }
    }
}
