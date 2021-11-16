using BudgeterDB;
using CoreServices.CustomExceptions;
using CoreServices.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _hasher;

        public UserService(AppDbContext context, IPasswordHasher hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public async Task<AuthenticatedUser> Signup(User user)
        {
            var checkUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (checkUser != null)
            {
                throw new UsernameAlreadyExists("Username already exists");
            }
            user.Password = _hasher.HashPassword(user.Password);
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            return new AuthenticatedUser
            {
                Username = user.UserName,
                Token = "test token"
            };

        }
    }
}
