using Hexagonal.Adapter.Auth;
using Hexagonal.Adapter.DetailedNotification;
using Hexagonal.Adapter.InMemory;
using Hexagonal.Adapter.Rest;

var api = new RestAdapter(args, options =>
{
	options.AddInMemoryAdapter();
	options.AddAuthAdapter();
	options.AddDetailedNotificationAdapter();
});

await api.StartAsync();