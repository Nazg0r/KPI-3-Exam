using Hexagonal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Adapter.InMemory.Data
{
	public class UserDbContext(DbContextOptions<UserDbContext> options)
		: DbContext(options)
	{
		public DbSet<User> Users { get; set; } = null!;
	}
}