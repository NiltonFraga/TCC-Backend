using Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Configuration
{
    public class AdocaoConfiguration : IEntityTypeConfiguration<Adocao>
    {
        public void Configure(EntityTypeBuilder<Adocao> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
