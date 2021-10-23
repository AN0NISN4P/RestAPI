using SimpleAssignment1.Models;

namespace RestAPI.Data
{
	public interface IUserService
	{
		User ValidateUser(string username, string password);
	}
}