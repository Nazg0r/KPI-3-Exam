using Hexagonal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Adapter.Postgres.Data
{
	public class UserDbContext(DbContextOptions<UserDbContext> options)
		: DbContext(options)
	{
		DbSet<User> Users { get; set; } = null!;
	}
}