namespace Assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuestionModel : DbContext
    {
        public QuestionModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<question> question { get; set; }
        public virtual DbSet<questioner> questioner { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<question>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.contents_of_question)
                .IsUnicode(false);

            modelBuilder.Entity<questioner>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<questioner>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<questioner>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<questioner>()
                .Property(e => e.email_addres)
                .IsUnicode(false);

            modelBuilder.Entity<questioner>()
                .HasMany(e => e.question)
                .WithRequired(e => e.questioner)
                .WillCascadeOnDelete(false);
        }
    }
}
