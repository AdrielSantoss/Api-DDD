using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    class UserMap : IEntityTypeConfiguration<UserEntity> //criando o mapeamento da tabela antes dela ser adicionada no banco de dados
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        { //configuração da tabela

            builder.ToTable("Users");

            builder.HasKey(u => u.id);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.Email)
                .HasMaxLength(100);
        }
    }
}
