namespace Hexagonal.Domain.Entities
{
	public record User(
		string Email,
		DateTime Birthday
	)
	{
		public string UserName { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Role { get; set; } = "Guest";
	}
}