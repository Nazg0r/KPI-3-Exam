using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Options;

namespace Hexagonal.Adapter.Auth.Services
{
	public class AuthService(UserValidationOptions options) : IAuthService
	{
		private IEnumerable<string> _roles =
		[
			"Admin",
			"User",
			"Guest"
		];

		public Task<bool> ValidateUserAsync(string email, int age)
		{
			return Task.FromResult(
				options.ValidEmailDomains
					.Any(email.Contains) &&
				age >= options.MinAge &&
				age <= options.MaxAge);
		}

		public Task<string> DefineUserRoleAsync(string username, int age)
		{
			if (username is "Admin") Task.FromResult("Admin");
			if (age < 18) return Task.FromResult("Guest");
			if (age < 30) return Task.FromResult("User");
			return Task.FromResult("Admin");
		}
	}
}