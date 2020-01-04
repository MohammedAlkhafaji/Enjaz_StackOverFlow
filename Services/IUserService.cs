using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Services
{
   public interface IUserService
    {
        Task<UpdateUserForm> UpdateUser(int Id, UpdateUserForm user);


        Task<UserForm> AddNewUser(UserForm newUser);


        Task<int> GetUserPoint(int UserId);


        Task<User> Login(LoginForm loginForm);


        Task<IEnumerable <User> > Getall();
    }
}
