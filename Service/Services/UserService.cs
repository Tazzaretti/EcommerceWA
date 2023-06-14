using Model.Models;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly ecommerceDBContext _context;

        public UserService(ecommerceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public Users GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}