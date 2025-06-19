namespace Hexagonal.Application.Ports.Secondary
{
	public interface INotificationService
	{
		Task<bool> SendEmailAsync(string receiver, CancellationToken cancellationToken);
	}
}