using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Infrastructure.EntitiesConfiguration
{
        public class GenreConfiguration : IEntityTypeConfiguration<Genre>
        {
            public void Configure(EntityTypeBuilder<Genre> builder)
            {
                //Set Primary Key
                builder.HasKey(x => x.Id);

                //Set Property configurations
                builder.Property(x => x.Name)
                       .HasMaxLength(180)
                       .IsRequired();

                //Set Relationship configurations
                builder.HasMany(x => x.Movies)
                       .WithOne(x => x._Genre)
                       .HasForeignKey(x => x.GenreID);
            }
        }
    }
