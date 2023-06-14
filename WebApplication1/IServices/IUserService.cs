﻿using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}