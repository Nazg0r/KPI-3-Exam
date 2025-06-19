using Hexagonal.Adapter.InMemory.Data;
using Hexagonal.Adapter.InMemory.Repositories;
using Hexagonal.Application.Ports.Secondary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hexagonal.Adapter.InMemory
{
	public static class DependencyInjection
	{
		public static void AddInMemoryAdapter(this IHostApplicationBuilder builder)
		{
			builder.Services.AddDbContext<UserDbContext>(options =>
			{
				options.UseInMemoryDatabase("HexagonalInMemoryDb");
			});

			builder.Services.AddScoped<IUserReadRepository, UserRepository>();
			builder.Services.AddScoped<IUserWriteRepository, UserRepository>();
		}
	}
}