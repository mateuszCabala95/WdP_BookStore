﻿using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.EntitiesConfiguration
{
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Author).IsRequired();

            builder.Property(b => b.Title).IsRequired();
            
            builder.Property(b => b.Price).IsRequired();
            
            builder.Property(b => b.AuthorId).IsRequired();
        }
    }
}