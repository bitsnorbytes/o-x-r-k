﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scullery.Models;

#nullable disable

namespace scullery.Migrations
{
    [DbContext(typeof(CinemaCatalogingContext))]
    [Migration("20230604085950_TMDBSchemaSync")]
    partial class TMDBSchemaSync
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Scullery.Models.CinemaCatalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("backdrop_path")
                        .HasAnnotation("Relational:JsonPropertyName", "backdrop_path");

                    b.Property<bool>("IsAdult")
                        .HasColumnType("boolean")
                        .HasColumnName("adult")
                        .HasAnnotation("Relational:JsonPropertyName", "adult");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_language")
                        .HasAnnotation("Relational:JsonPropertyName", "original_language");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_title")
                        .HasAnnotation("Relational:JsonPropertyName", "original_title");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("overview")
                        .HasAnnotation("Relational:JsonPropertyName", "overview");

                    b.Property<string>("PosterPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("poster_path")
                        .HasAnnotation("Relational:JsonPropertyName", "poster_path");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date")
                        .HasAnnotation("Relational:JsonPropertyName", "release_date");

                    b.Property<int>("RunTimeInMinutes")
                        .HasColumnType("integer")
                        .HasColumnName("runtime")
                        .HasAnnotation("Relational:JsonPropertyName", "runtime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.Property<string>("imdbId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imdb_id")
                        .HasAnnotation("Relational:JsonPropertyName", "imdb_id");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Scullery.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MoviesId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("Genres");

                    b.HasAnnotation("Relational:JsonPropertyName", "genres");
                });

            modelBuilder.Entity("Scullery.Models.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("mediatype_id");

                    b.Property<int>("MoviesId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("Scullery.Models.Genre", b =>
                {
                    b.HasOne("Scullery.Models.CinemaCatalogue", "Movies")
                        .WithMany("Genres")
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Scullery.Models.MediaType", b =>
                {
                    b.HasOne("Scullery.Models.CinemaCatalogue", "Movies")
                        .WithMany("MediaTypes")
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Scullery.Models.CinemaCatalogue", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("MediaTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
