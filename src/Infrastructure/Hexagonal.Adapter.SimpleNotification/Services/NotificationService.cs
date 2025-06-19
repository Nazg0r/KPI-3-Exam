using Hexagonal.Application.Ports.Secondary;
using Microsoft.Extensions.Logging;

namespace Hexagonal.Adapter.SimpleNotification.Services
{
	public class NotificationService(ILogger<NotificationService> logger)
		: INotificationService
	{
		public async Task<bool> SendEmailAsync(string receiver, CancellationToken cancellationToken)
		{
			logger.LogInformation("Sending email to {Receiver}", receiver);

			await Task.Delay(400, cancellationToken);

			logger.LogInformation("Email sent to {Receiver}", receiver);

			return true;
		}
	}
}