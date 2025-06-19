namespace Hexagonal.Domain.Options
{
	public class UserValidationOptions
	{
		public int MinAge { get; set; } = 18;
		public int MaxAge { get; set; } = 42;
		public IEnumerable<string> ValidEmailDomains { get; set; } = ["gmail", "proton", "kpi"];
	}
}
