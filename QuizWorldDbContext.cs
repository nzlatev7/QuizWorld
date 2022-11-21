using Microsoft.EntityFrameworkCore;
using QuizMarket.Models.DB;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QuizMarket
{
    public class QuizWorldDbContext : DbContext
    {
        public QuizWorldDbContext(DbContextOptions<QuizWorldDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }


        //Fluent API - https://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure StudentId as FK for StudentAddress
            //modelBuilder.Entity<Question>()
            //            .HasOne(s => s.Answer);
            //modelBuilder.Entity<Answer>()
            //            .HasOne(s => s.Question);

            base.OnModelCreating(modelBuilder);

            //this is to configure joining table
            //many to many
            //modelBuilder.Entity<User>()
            //    .HasMany<Quiz>(s => s.Quizzes)
            //    .WithMany(c => c.Users)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("UserRefId");
            //        cs.MapRightKey("QuizRefId");
            //        cs.ToTable("UserQuiz");
            //    });

            //one to one
            modelBuilder.Entity<Question>()
            .HasOne(a => a.Answer)
            .WithOne(a => a.Question)
            .HasForeignKey<Answer>(c => c.Id);


            //one to many
            //modelBuilder.Entity<Student>()
            //.HasRequired<Grade>(s => s.Grade) //Student entity requires Grade 
            //.WithMany(s => s.Students);
        }
    }
}
