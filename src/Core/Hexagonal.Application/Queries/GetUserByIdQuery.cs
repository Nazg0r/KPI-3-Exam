using Hexagonal.Domain.Entities;
using MediatR;

namespace Hexagonal.Application.Queries
{
	public record GetUserByIdQuery(string Id) 
		: IRequest<User>;
}