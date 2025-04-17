namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendBulkEmailAsync(IEnumerable<string> recipients, string subject, string body);
    }
}

