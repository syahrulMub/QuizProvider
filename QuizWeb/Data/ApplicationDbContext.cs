using Microsoft.EntityFrameworkCore;
using QuizWeb.Models;

namespace QuizWeb.Data;

public class ApplicationDbContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
