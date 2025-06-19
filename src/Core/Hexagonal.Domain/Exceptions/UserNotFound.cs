namespace Hexagonal.Domain.Exceptions
{
	public class UserNotFound(string message)
		: Exception($"User not found. {message}");
}
