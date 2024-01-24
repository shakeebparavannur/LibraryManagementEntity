using LibraryManagement.Models.Dtos;

namespace LibraryManagement.Repository
{
    public interface IUserService
    {
        Task<string> Login(LoginReqDto loginReqDto);
        Task<string> AdminLogin(LoginReqDto adminLoginReqDto);
        string SignUp(UserDto user);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(Guid userId);
        Task<UserDto> UpdateUser(UserDto user);

        
    }
}
