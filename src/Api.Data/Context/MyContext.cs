using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<UfEntity> UfEntities { get; set; }
        public DbSet<CepEntity> CepEntities { get; set; }
        public DbSet<MunicipioEntity> MunicipioEntities { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            var map = new UserMap();

            modelBuilder.Entity<UserEntity>(map.Configure);

        }
    }
}
