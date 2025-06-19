using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Application.Queries;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.Exceptions;
using MediatR;

namespace Hexagonal.Application.Handlers.Queries
{
	internal class GetUserByIdQueryHandler(
		IUserReadRepository userRepository)
		: IRequestHandler<GetUserByIdQuery, User>
	{
		public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
		{
			var user = await userRepository.GetUserByIdAsync(query.Id, cancellationToken);
			if (user is null)
				throw new UserNotFound($"User with id: {query.Id} not found");

			return user;
		}
	}
}