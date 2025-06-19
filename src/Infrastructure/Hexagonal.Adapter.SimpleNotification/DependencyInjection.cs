using Hexagonal.Adapter.SimpleNotification.Services;
using Hexagonal.Application.Ports.Secondary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hexagonal.Adapter.SimpleNotification;

public static class DependencyInjection
{
	public static void AddSimpleNotificationAdapter(this IHostApplicationBuilder builder)
	{
		builder.Services.AddScoped<INotificationService, NotificationService>();
	}
}
