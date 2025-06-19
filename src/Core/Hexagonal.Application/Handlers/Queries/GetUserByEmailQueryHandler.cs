using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Application.Queries;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.Exceptions;
using MediatR;

namespace Hexagonal.Application.Handlers.Queries
{
	public class GetUserByEmailQueryHandler(
		IUserRepository userRepository)
		: IRequestHandler<GetUserByEmailQuery, User>
	{
		public async Task<User> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
		{
			var user = await userRepository.GetUserByEmailAsync(query.Email, cancellationToken);
			if (user is null)
				throw new UserNotFound($"User with email: {query.Email} not found");

			return user;
		}
	}
}