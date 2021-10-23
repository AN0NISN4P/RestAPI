using SimpleAssignment1.Models;

namespace SimpleAssignment1.Data
{
	public interface IUserService
	{
		User ValidateUser(string username, string password);
	}
}