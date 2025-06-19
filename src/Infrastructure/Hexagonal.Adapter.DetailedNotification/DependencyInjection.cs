using Hexagonal.Adapter.DetailedNotification.Services;
using Hexagonal.Application.Ports.Secondary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hexagonal.Adapter.DetailedNotification;

public static class DependencyInjection
{
	public static void AddDetailedNotificationAdapter(this IHostApplicationBuilder builder)
	{
		builder.Services.AddScoped<INotificationService, NotificationService>();
	}
}
