﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestionManagement.Data;

#nullable disable

namespace QuestionManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250205062613_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuestionManagement.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCorrect = false,
                            QuestionId = 1,
                            Text = "3"
                        },
                        new
                        {
                            Id = 2,
                            IsCorrect = true,
                            QuestionId = 1,
                            Text = "4"
                        });
                });

            modelBuilder.Entity("QuestionManagement.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.Property<string>("ModelAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Difficulty = "Easy",
                            Marks = 5,
                            ModelAnswer = "",
                            SubjectId = 1,
                            Text = "What is 2 + 2?",
                            Type = "MCQ"
                        },
                        new
                        {
                            Id = 2,
                            Difficulty = "Easy",
                            Marks = 5,
                            ModelAnswer = "False",
                            SubjectId = 2,
                            Text = "The Earth is flat.",
                            Type = "TrueFalse"
                        },
                        new
                        {
                            Id = 3,
                            Difficulty = "Hard",
                            Marks = 10,
                            ModelAnswer = "An object remains at rest or in motion unless acted upon by an external force.",
                            SubjectId = 2,
                            Text = "Explain Newton's First Law of Motion.",
                            Type = "Descriptive"
                        });
                });

            modelBuilder.Entity("QuestionManagement.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mathematics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("QuestionManagement.Models.Option", b =>
                {
                    b.HasOne("QuestionManagement.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuestionManagement.Models.Question", b =>
                {
                    b.HasOne("QuestionManagement.Models.Subject", "Subject")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("QuestionManagement.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("QuestionManagement.Models.Subject", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
