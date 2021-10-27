using SimpleAssignment1.Models;

namespace HttpClient.Data
{
	public interface IUserService
	{
		User ValidateUser(string username, string password);
	}
}