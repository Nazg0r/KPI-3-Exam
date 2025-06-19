using Hexagonal.Application.Ports.Secondary;
using Microsoft.Extensions.Logging;

namespace Hexagonal.Adapter.DetailedNotification.Services
{
	public class NotificationService(ILogger<NotificationService> logger)
		: INotificationService
	{
		public async Task<bool> SendEmailAsync(string receiver, CancellationToken cancellationToken)
		{
			logger.LogInformation("Sending email with a lot of information to {Receiver}", receiver);

			await Task.Delay(400, cancellationToken);

			logger.LogInformation("Email with a lot of information sent to {Receiver}", receiver);

			return true;
		}
	}
}