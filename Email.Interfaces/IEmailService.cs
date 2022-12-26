namespace Email.Interfaces
{
    public interface IEmailService
    {
        Task SednAsync(string address, string subject, string body);
    }
}
