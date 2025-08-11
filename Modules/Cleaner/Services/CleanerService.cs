namespace CleaningServiceAPI.Modules.Cleaner.Services
{
public class CleanerService
{
    public Task<object> First()
    {
        return  Task.FromResult((object)new { message = "Cleaner service works!" });
    }
}
}