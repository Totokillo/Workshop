namespace Workshop01.BackEnd.View.Infrastructure
{
    public interface IDatabaseService
    {
        Task<bool> SetupDatabase(List<string> request);
    }
}
