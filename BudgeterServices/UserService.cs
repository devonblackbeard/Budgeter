using BudgeterDB;
using CoreServices.CustomExceptions;
using CoreServices.DTO;
using CoreServices.Utilities;
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

        public async Task<AuthenticatedUser> SignIn(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u=>u.UserName == user.UserName);
            if (existingUser == null || _hasher.VerifyHashedPassword(existingUser.Password, user.Password) == PasswordVerificationResult.Failed)
            {
                throw new InvalidSignInException("Invalid Username or Password");
            }
            else
            {
                return new AuthenticatedUser
                {
                    Username = user.UserName,
                    Token = JwtGenerator.GenerateUserToken(user.UserName)
                };
            }
        }

        public async Task<AuthenticatedUser> Signup(User user)
        {
            var checkUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (checkUser != null)
            {
                throw new UsernameAlreadyExistsException("Username already exists");
            }
            user.Password = _hasher.HashPassword(user.Password);
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            return new AuthenticatedUser
            {
                Username = user.UserName,
                Token = JwtGenerator.GenerateUserToken(user.UserName)
            };

        }
    }
}
