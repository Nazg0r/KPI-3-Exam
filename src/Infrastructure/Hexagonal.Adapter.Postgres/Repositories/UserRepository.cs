using Hexagonal.Adapter.Postgres.Data;
using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Entities;

namespace Hexagonal.Adapter.Postgres.Repositories
{
	public class UserRepository(UserDbContext dbContext)
		: IUserRepository
	{
		public Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task CreateUserAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task UpdateUserCredentialsAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}