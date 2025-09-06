using ivana.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace ivana.data
{
    public class IvanaDbcontext:DbContext
    {
        public IvanaDbcontext(DbContextOptions<IvanaDbcontext>options):base(options) 
        {}
        public DbSet<User> User {  get; set; }

    }

}
