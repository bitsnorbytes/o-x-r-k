﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scullery.Models;

#nullable disable

namespace scullery.Migrations
{
    [DbContext(typeof(CinemaCatalogingContext))]
    partial class CinemaCatalogingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Scullery.Data.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Scullery.Data.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("Scullery.Data.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("backdrop_path");

                    b.Property<bool>("IsAdult")
                        .HasColumnType("boolean")
                        .HasColumnName("is_adult");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_language");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_title");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("overview");

                    b.Property<string>("PosterPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("poster_path");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<string>("RunningTimeInMinutes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("running_time_in_mins");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Scullery.Data.Genre", b =>
                {
                    b.HasOne("Scullery.Data.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Scullery.Data.MediaType", b =>
                {
                    b.HasOne("Scullery.Data.Movie", "Movie")
                        .WithMany("MediaTypes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Scullery.Data.Movie", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("MediaTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
