using Api.Domain;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Configuration
{
    public class AnimalFavoritoConfiguration : IEntityTypeConfiguration<AnimalFavorito>
    {
        public void Configure(EntityTypeBuilder<AnimalFavorito> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("tb_pet_favorito");
        }
    }
}
