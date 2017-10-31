using Microsoft.EntityFrameworkCore;
using RecruitingAteliware.Models;

namespace RecruitingAteliware.Context
{
    public class AteliwareContext : DbContext
    {
        public AteliwareContext(DbContextOptions<AteliwareContext> options) : base(options){}               

        public DbSet<Repositorio> Repositorios { get; set; }
    }
}