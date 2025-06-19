namespace Hexagonal.Domain.Exceptions
{
	public class UserNotValidException(string message)
		: Exception($"User validation failed. {message}");
}
