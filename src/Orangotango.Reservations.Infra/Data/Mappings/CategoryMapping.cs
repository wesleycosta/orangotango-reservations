﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Rooms.Aggregates;

namespace Orangotango.Reservations.Infra.Data.Mappings;

internal sealed class CategoryMapping : MappingBase, IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(MAX_LENGTH_STRING);
    }
}
