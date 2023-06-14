using Model.Models;

namespace Service.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int id);
        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}