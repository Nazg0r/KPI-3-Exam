using Hexagonal.Application.Commands;
using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Mappings
{
	public static class CommandMappings
	{
		public static User ToDomain(this CreateUserCommand command) =>
			new User(
				command.Email,
				command.UserName,
				command.Name,
				command.Surname,
				command.Birthday
			);

		public static User ToDomain(this UpdateUserCredentialsCommand command) =>
			new User(
				command.Email,
				command.UserName,
				command.Name,
				command.Surname,
				command.Birthday
			);
	}
}