using Hexagonal.Adapter.Postgres.Data;
using Hexagonal.Adapter.Postgres.Repositories;
using Hexagonal.Application.Ports.Secondary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hexagonal.Adapter.Postgres;

public static class DependencyInjection
{
	public static void AddPostgresAdapter(this IHostApplicationBuilder builder)
	{
		builder.Services.AddDbContext<UserDbContext>(options =>
		{
			options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
		});

		builder.Services.AddScoped<IUserRepository, UserRepository>();
	}
}