using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Ports.Secondary
{
	public interface IAuthService
	{
		Task<bool> ValidateUserAsync(string email, int age);
		Task<string> DefineUserRoleAsync(string username, int age);
	}
}
