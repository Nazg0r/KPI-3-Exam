using Hexagonal.Application.Commands;
using Hexagonal.Application.Mappings;
using Hexagonal.Application.Ports.Secondary;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.Exceptions;
using MediatR;

namespace Hexagonal.Application.Handlers.Commands
{
	public class CreateUserCommandHandler(
		IUserRepository userRepository,
		IAuthService authService,
		INotificationService notificationService)
		: IRequestHandler<CreateUserCommand, User>
	{
		public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
		{
			var userAge = GetUserAge(command.Birthday);
			var isUserValid = await authService.ValidateUserAsync(command.Email, userAge);

			if (!isUserValid)
				throw new UserNotValidException("User is not valid");

			var role = await authService.DefineUserRoleAsync(command.UserName, userAge);

			var user = command.ToDomain();
			user.Role = role;

			await userRepository.CreateUserAsync(user, cancellationToken);

			var isEmailSent = await notificationService.SendEmailAsync(user.Email, cancellationToken);
			if (!isEmailSent)
				throw new SendEmailNotificationException();

			return user;
		}

		private int GetUserAge(DateTime birthday)
		{
			var today = DateTime.Today;
			var age = today.Year - birthday.Year;
			if (birthday.Date > today.AddYears(-age))
				age--;
			return age;
		}
	}
}