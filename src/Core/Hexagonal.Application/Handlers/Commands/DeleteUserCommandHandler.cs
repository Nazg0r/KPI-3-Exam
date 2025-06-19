using Hexagonal.Application.Commands;
using Hexagonal.Application.Ports.Secondary;
using MediatR;

namespace Hexagonal.Application.Handlers.Commands
{
	public class DeleteUserCommandHandler(
		IUserWriteRepository userRepository)
		: IRequestHandler<DeleteUserCommand, Unit>
	{
		public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
		{
			var isUserDeleted = await userRepository.DeleteUserAsync(command.Id, cancellationToken);
			if (!isUserDeleted)
				throw new ArgumentException("User not found or could not be deleted");

			return Unit.Value;
		}
	}
}