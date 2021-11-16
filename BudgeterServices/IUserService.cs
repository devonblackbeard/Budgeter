using BudgeterDB;
using CoreServices.DTO;
using System.Threading.Tasks;

namespace CoreServices
{
    public interface IUserService
    {
        Task<AuthenticatedUser> Signup(User user);
    }
}
