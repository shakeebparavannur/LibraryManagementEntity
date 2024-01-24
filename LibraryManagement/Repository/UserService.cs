using AutoMapper;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagement.Repository
{
    public class UserService : IUserService
    {
        private readonly LibraryDbContext _context;
        private IMapper mapper;
        private readonly IConfiguration configuration;
        public UserService(LibraryDbContext lIbraryDb,IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public Task<string> AdminLogin(LoginReqDto adminLoginReqDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            User user =await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
            {
                throw new NullReferenceException();
            }
            var _user = mapper.Map<UserDto>(user);
            return _user;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users =await _context.Users.ToListAsync();
            if(users == null)
            {
                throw new NullReferenceException();
            }
            var _users = mapper.Map<IEnumerable<UserDto>>(users);
            return _users;

        }

        public async Task<string> Login(LoginReqDto loginReqDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginReqDto.Email&& x.Password==loginReqDto.Password);
            if(user == null)
            {
                return "Sorry User Not Found";
            }
            var tokenOption = configuration.GetValue<string>("Jwt:Key");
            var key = Encoding.ASCII.GetBytes(tokenOption);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var responseToken  = tokenHandler.WriteToken(token);
            return responseToken;




        }

        public string SignUp(UserDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password,10);
            return user.Password;
        }

        public Task<UserDto> UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
