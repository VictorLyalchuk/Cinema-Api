﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20230920174658_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 5,
                            Name = "History"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mistery"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Thriller"
                        });
                });

            modelBuilder.Entity("Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "John, an ex-CIA officer, is entrusted with the responsibility of safeguarding an entrepreneur's daughter. When the girl gets kidnapped, John vows to seek revenge.",
                            Duration = new TimeSpan(0, 2, 26, 0, 0),
                            Title = "Main on Fire",
                            Year = 2004
                        },
                        new
                        {
                            Id = 2,
                            Description = "Commodus takes over power and demotes Maximus, one of the preferred generals of his father, Emperor Marcus Aurelius. As a result, Maximus is relegated to fighting till death as a gladiator.",
                            Duration = new TimeSpan(0, 2, 35, 0, 0),
                            Title = "Gladiator",
                            Year = 2000
                        },
                        new
                        {
                            Id = 3,
                            Description = "When a group of firefighters from California ignores a warning by Superintendent Eric Marsh about a wildfire, he decides to get his crew certified as wildfire hotshots.",
                            Duration = new TimeSpan(0, 2, 13, 0, 0),
                            Title = "Only the Brave",
                            Year = 2017
                        },
                        new
                        {
                            Id = 4,
                            Description = "Baker Dill is a fishing boat captain who leads tours off of the tranquil enclave of Plymouth Island. His peaceful life is soon shattered when his ex-wife Karen tracks him down. Desperate for help, Karen begs Baker to save her -- and their young son -- from her abusive husband. She wants him to take the brute out for a fishing excursion -- then throw him overboard to the sharks. Thrust back into a life that he wanted to forget, Baker now finds himself struggling to choose between right and wrong.",
                            Duration = new TimeSpan(0, 1, 46, 0, 0),
                            Title = "Serenity",
                            Year = 2019
                        },
                        new
                        {
                            Id = 5,
                            Description = "An unmanned, half-mile-long freight train hurtles towards a town at breakneck speed. An engineer and a young conductor, who happen to be on the same route, must race against time to try and stop it.",
                            Duration = new TimeSpan(0, 1, 38, 0, 0),
                            Title = "Unstoppable",
                            Year = 2010
                        });
                });

            modelBuilder.Entity("Core.Entities.MovieGenre", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.HasKey("MovieID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("MoviesGenres");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            GenreID = 1
                        },
                        new
                        {
                            MovieID = 1,
                            GenreID = 2
                        },
                        new
                        {
                            MovieID = 1,
                            GenreID = 3
                        },
                        new
                        {
                            MovieID = 2,
                            GenreID = 1
                        },
                        new
                        {
                            MovieID = 2,
                            GenreID = 4
                        },
                        new
                        {
                            MovieID = 2,
                            GenreID = 5
                        },
                        new
                        {
                            MovieID = 3,
                            GenreID = 1
                        },
                        new
                        {
                            MovieID = 3,
                            GenreID = 3
                        },
                        new
                        {
                            MovieID = 4,
                            GenreID = 1
                        },
                        new
                        {
                            MovieID = 4,
                            GenreID = 6
                        },
                        new
                        {
                            MovieID = 4,
                            GenreID = 7
                        },
                        new
                        {
                            MovieID = 5,
                            GenreID = 3
                        },
                        new
                        {
                            MovieID = 5,
                            GenreID = 7
                        });
                });

            modelBuilder.Entity("Core.Entities.MovieGenre", b =>
                {
                    b.HasOne("Core.Entities.Genre", "_Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Movie", "_Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_Genre");

                    b.Navigation("_Movie");
                });

            modelBuilder.Entity("Core.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Core.Entities.Movie", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}