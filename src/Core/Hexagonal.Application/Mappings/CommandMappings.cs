using Hexagonal.Application.Commands;
using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Mappings
{
	public static class CommandMappings
	{
		public static User ToDomain(this CreateUserCommand command) =>
			new User(command.Email, command.Birthday)
			{
				UserName = command.UserName,
				Name = command.Name,
				Surname = command.Surname,
			};
	}
}