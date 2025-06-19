using Hexagonal.Adapter.Rest.Endpoints;
using Hexagonal.Application.Handlers.Commands;

namespace Hexagonal.Adapter.Rest;

public class RestAdapter
{
	private readonly WebApplication _app;

	public RestAdapter(string[] args, Action<IHostApplicationBuilder> options)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddMediatR(cfg =>
			cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

		options.Invoke(builder);

		_app = builder.Build();

		_app.MapUserEndpoints();
	}

	public Task StartAsync()
	{
		return _app.RunAsync();
	}
}