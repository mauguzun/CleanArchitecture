﻿using Email.Interfaces;

namespace Email.Mailchimp
{
    public class EmailService : IEmailService
    {
        public Task SednAsync(string address, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
