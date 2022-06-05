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
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }

        private readonly string ConectionString = "Server=localhost;Port=3306;Database=pets_database;User=root;Password=root";

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public ApiContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(ConectionString,
                    mysqlOptions =>
                        mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb)));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ArquivoConfiguration());
            modelBuilder.ApplyConfiguration(new ServicoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new CurtidaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
