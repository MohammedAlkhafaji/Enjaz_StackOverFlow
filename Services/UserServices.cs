using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Enjaz_StackOverFlow.Services
{
    public class UserServices : IUserService
    {
        private readonly Enjaz_Context ctx;
        private readonly IMapper _mapper;

        public UserServices(Enjaz_Context context, IMapper mapper)
        {
            ctx = context;
            _mapper = mapper;
        }

        public async Task<UserForm> AddNewUser(UserForm newUser)
        {

            var user = new User();
            _mapper.Map(newUser, user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await ctx.Users.AddAsync(user);
            await ctx.SaveChangesAsync();
            return newUser;

        }

        public async Task<IEnumerable<User>> Getall()
        {
            return await ctx.Users.ToListAsync();
        }

        public async Task<int> GetUserPoint(int UserId)
        {
            return await ctx.Users.Where(s => s.Id == UserId).Select(u => u.Point).SingleOrDefaultAsync();
        }

        public async Task<User> Login(LoginForm loginForm)
        {
            var user_item = await ctx.Users.FirstOrDefaultAsync(u => u.Email == loginForm.email);
            if (user_item == null || !BCrypt.Net.BCrypt.Verify(loginForm.password, user_item.Password))
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyString = "kNpMKqse4DkJAEEFrbgsJ22iPfTpSr_KuX3RtE27nkroJridN6mQ2qbszI1ooG9GMJoFm1nUQJLpPN_OVCG_Nw";
            var key = Encoding.ASCII.GetBytes(keyString);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user_item.Id.ToString()),
                    new Claim("point", user_item.Point.ToString()),
                     new Claim(ClaimTypes.Name, user_item.User_Name),
                    new Claim(ClaimTypes.Role, user_item.Role),


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user_item.Token = tokenHandler.WriteToken(token);

            return user_item;

        }

        public async Task<UpdateUserForm> UpdateUser(int Id, UpdateUserForm user)
        {
            var item = ctx.Users.Where(c => c.Id == Id).SingleOrDefault();
            _mapper.Map(user, item);

            await ctx.SaveChangesAsync();
            return user;


        }
    }
}
