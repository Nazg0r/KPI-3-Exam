using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Ports.Secondary
{
	public interface IUserWriteRepository
	{
		Task CreateUserAsync(User user, CancellationToken cancellationToken);
		Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken);
		Task UpdateUserCredentialsAsync(User user, CancellationToken cancellationToken);
	}
}