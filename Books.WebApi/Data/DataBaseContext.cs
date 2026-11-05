using Books.WebApi.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

namespace Books.WebApi.Data;

public sealed class DataBaseContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DataBaseContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("table_authors");

            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id)
                .HasColumnName("id");

            entity.Property(a => a.FullName)
                .HasColumnName("full_name")
                .IsRequired();

            entity.HasIndex(a => a.FullName)
                .IsUnique()
                .HasDatabaseName("ux_table_authors_full_name");

            entity.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    join => join.HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("book_id")
                        .HasConstraintName("fk_table_book_author_book_id"),
                    join => join.HasOne<Author>()
                        .WithMany()
                        .HasForeignKey("author_id")
                        .HasConstraintName("fk_table_book_author_author_id"),
                    join =>
                    {
                        join.ToTable("table_books_authors");
                        join.HasKey("book_id", "author_id");

                        join.Property<Guid>("book_id")
                            .HasColumnName("book_id");

                        join.Property<Guid>("author_id")
                            .HasColumnName("author_id");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("table_books");

            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id)
                .HasColumnName("id");

            entity.Property(b => b.Title)
                .HasColumnName("title")
                .IsRequired();

            entity.HasIndex(b => b.Title)
                .HasDatabaseName("ix_table_books_title");
        });
    }
}