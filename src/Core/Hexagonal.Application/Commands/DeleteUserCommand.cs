using MediatR;

namespace Hexagonal.Application.Commands
{
	public record DeleteUserCommand(string Id)
		: IRequest<Unit>;
}