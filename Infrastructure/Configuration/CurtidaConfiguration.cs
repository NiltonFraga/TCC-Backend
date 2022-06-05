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
    public class CurtidaConfiguration : IEntityTypeConfiguration<Curtida>
    {
        public void Configure(EntityTypeBuilder<Curtida> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("tb_curtida");
        }
    }
}
