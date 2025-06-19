using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Ports.Secondary
{
	public interface IUserReadRepository
	{
		Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken);
		Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
	}
}