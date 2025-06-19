using Hexagonal.Adapter.InMemory.Data;
using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Adapter.InMemory.Repositories
{
	public class UserRepository(UserDbContext dbContext)
		: IUserReadRepository, IUserWriteRepository
	{
		public async Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken) =>
			await dbContext.Users.FindAsync(id);

		public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken) =>
			await dbContext.Users
				.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

		public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
		{
			dbContext.Users.Add(user);
			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken)
		{
			var user = dbContext.Users.Find(id);
			if (user is null)
				return Task.FromResult(false);

			dbContext.Users.Remove(user);
			return dbContext.SaveChangesAsync(cancellationToken).ContinueWith(t => t.Result > 0, cancellationToken);
		}

		public async Task UpdateUserCredentialsAsync(User user, CancellationToken cancellationToken)
		{
			dbContext.Users.Update(user);
			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}