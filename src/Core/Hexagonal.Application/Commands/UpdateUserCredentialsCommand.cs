using Hexagonal.Domain.Entities;
using MediatR;

namespace Hexagonal.Application.Commands
{
	public record UpdateUserCredentialsCommand(
		string Email,
		string UserName,
		string Name,
		string Surname,
		DateTime Birthday) 
		: IRequest<User>;
}