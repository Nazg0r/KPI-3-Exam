using Hexagonal.Application.Commands;
using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.Exceptions;
using MediatR;

namespace Hexagonal.Application.Handlers.Commands
{
	internal class UpdateUserCredentialsCommandHandler(
		IUserReadRepository userReadRepository,
		IUserWriteRepository userWriteRepository)
		: IRequestHandler<UpdateUserCredentialsCommand, User>
	{
		public async Task<User> Handle(UpdateUserCredentialsCommand command, CancellationToken cancellationToken)
		{
			var user = await userReadRepository.GetUserByEmailAsync(command.Email, cancellationToken);
			if (user is null)
				throw new UserNotFound($"User with email: {command.Email} not found");

			user.Name = command.Name;
			user.Surname = command.Surname;
			user.UserName = command.UserName;

			await userWriteRepository.UpdateUserCredentialsAsync(user, cancellationToken);

			return user;
		}
	}
}