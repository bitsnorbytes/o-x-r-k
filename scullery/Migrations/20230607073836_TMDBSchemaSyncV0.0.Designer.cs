﻿// <auto-generated />
using System;
using System.Collections.Generic;
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
    [Migration("20230607073836_TMDBSchemaSyncV0.0")]
    partial class TMDBSchemaSyncV00
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

                    b.Property<List<string>>("BackdropSizes")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("backdrop_sizes");

                    b.Property<int[]>("GenreIds")
                        .HasColumnType("integer[]")
                        .HasColumnName("genre_ids");

                    b.Property<bool>("IsAdult")
                        .HasColumnType("boolean")
                        .HasColumnName("adult")
                        .HasAnnotation("Relational:JsonPropertyName", "adult");

                    b.Property<string>("MediaType")
                        .HasColumnType("text")
                        .HasColumnName("media_type");

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

                    b.Property<List<string>>("PosterSizes")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("poster_sizes");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date")
                        .HasAnnotation("Relational:JsonPropertyName", "release_date");

                    b.Property<int>("RunTimeInMinutes")
                        .HasColumnType("integer")
                        .HasColumnName("runtime")
                        .HasAnnotation("Relational:JsonPropertyName", "runtime");

                    b.Property<string>("SecureBaseImageURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("secure_base_image_URL");

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
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
