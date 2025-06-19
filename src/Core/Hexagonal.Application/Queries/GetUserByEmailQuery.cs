using Hexagonal.Domain.Entities;
using MediatR;

namespace Hexagonal.Application.Queries
{
	public record GetUserByEmailQuery(string Email)
		: IRequest<User>;
}
