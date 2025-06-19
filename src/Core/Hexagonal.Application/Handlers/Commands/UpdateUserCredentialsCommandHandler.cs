using Hexagonal.Application.Commands;
using Hexagonal.Application.Mappings;
using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Entities;
using MediatR;

namespace Hexagonal.Application.Handlers.Commands
{
	internal class UpdateUserCredentialsCommandHandler(
		IUserRepository userRepository)
		: IRequestHandler<UpdateUserCredentialsCommand, User>
	{
		public async Task<User> Handle(UpdateUserCredentialsCommand command, CancellationToken cancellationToken)
		{
			var user = command.ToDomain();
			await userRepository.UpdateUserCredentialsAsync(user, cancellationToken);

			return user;
		}
	}
}