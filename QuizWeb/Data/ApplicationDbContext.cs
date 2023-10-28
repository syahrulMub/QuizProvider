using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Constant;
using QuizWeb.Models;

namespace QuizWeb.Data;

public class DatabaseContext : IdentityDbContext<User>
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Theme> Themes { get; set; }
    public DbSet<QuizDetail> QuizDetails { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>()
        .Property(i => i.CompleteName)
        .HasMaxLength(30);

        builder.Entity<User>()
        .Property(i => i.PictureProfile);

        builder.Entity<User>()
        .Property(i => i.SchoolLevel);

        builder.Entity<User>()
        .Property(i => i.SchoolName);

        builder.Entity<User>()
        .Property(i => i.SchoolClass);
    }
}