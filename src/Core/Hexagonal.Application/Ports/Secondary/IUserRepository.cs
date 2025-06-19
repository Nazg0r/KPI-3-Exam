using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Ports.Secondary
{
	public interface IUserRepository
	{
		Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken);
		Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
		Task CreateUserAsync(User user, CancellationToken cancellationToken);
		Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken);
		Task UpdateUserCredentialsAsync(User user, CancellationToken cancellationToken);
	}
}