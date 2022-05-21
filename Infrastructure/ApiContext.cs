using Api.Domain;
using Api.Domain.Entities;
using Api.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;

namespace Api.Infrastructure
{
    public class ApiContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Adocao> Adocoes { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }

        private readonly string ConectionString = "Server=localhost;Port=3306;Database=pets_database;User=root;Password=root";

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public ApiContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(ConectionString,
                    mysqlOptions =>
                        mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb)));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdocaoConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ArquivoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
