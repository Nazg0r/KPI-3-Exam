using Hexagonal.Adapter.Auth.Services;
using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hexagonal.Adapter.Auth;

public static class DependencyInjection
{
	public static void AddAuthAdapter(this IHostApplicationBuilder builder)
	{
		builder.Services.AddSingleton(new UserValidationOptions());
		builder.Services.AddScoped<IAuthService, AuthService>();
	}
}