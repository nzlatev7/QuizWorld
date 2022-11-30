﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizMarket;

#nullable disable

namespace QuizWorld.Migrations
{
    [DbContext(typeof(QuizWorldDbContext))]
    [Migration("20221130153952_addedRoles")]
    partial class addedRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuizMarket.Models.DB.Answer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuizId")
                        .HasColumnType("int");

                    b.Property<int?>("QuizId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("QuizId1");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Answer", b =>
                {
                    b.HasOne("QuizMarket.Models.DB.Question", "Question")
                        .WithOne("Answer")
                        .HasForeignKey("QuizMarket.Models.DB.Answer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Question", b =>
                {
                    b.HasOne("QuizMarket.Models.DB.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");

                    b.HasOne("QuizMarket.Models.DB.Quiz", null)
                        .WithMany("listOfQuestion")
                        .HasForeignKey("QuizId1");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Quiz", b =>
                {
                    b.HasOne("QuizMarket.Models.DB.User", null)
                        .WithMany("ListOfQuiz")
                        .HasForeignKey("UserId");

                    b.HasOne("QuizMarket.Models.DB.User", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Question", b =>
                {
                    b.Navigation("Answer")
                        .IsRequired();
                });

            modelBuilder.Entity("QuizMarket.Models.DB.Quiz", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("listOfQuestion");
                });

            modelBuilder.Entity("QuizMarket.Models.DB.User", b =>
                {
                    b.Navigation("ListOfQuiz");

                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
