using Email.Interfaces;

namespace Email.Mailchimp
{
    public class EmailService : IEmailService
    {
        public Task SednAsync(string address, string subject, string body)
        {
            Console.WriteLine(address);
            Console.WriteLine(subject);
            Console.WriteLine(body);
            return Task.CompletedTask;
        }
    }
}
