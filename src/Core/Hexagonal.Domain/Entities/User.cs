namespace Hexagonal.Domain.Entities
{
	public record User(
		string Email,
		string UserName,
		string Name,
		string Surname,
		DateTime Birthday
	)
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Role { get; set; } = "Guest";
	}
}