using QuizWeb.Data;

namespace QuizWeb.DatabaseServices;

public partial class DatabaseServices : IDatabaseServices
{
    private readonly DatabaseContext _dbContext;
    public DatabaseServices(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
}
