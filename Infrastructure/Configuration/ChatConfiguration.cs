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
    public class ChatDtoConfiguration : IEntityTypeConfiguration<ChatDto>
    {
        public void Configure(EntityTypeBuilder<ChatDto> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("tb_chat");
        }
    }
}
