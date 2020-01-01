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
            var user = await ctx.Users.FirstOrDefaultAsync(u => u.Email == loginForm.email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginForm.password, user.Password))
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyString = "kNpMKqse4DkJAEEFrbgsJ22iPfTpSr_KuX3RtE27nkroJridN6mQ2qbszI1ooG9GMJoFm1nUQJLpPN_OVCG_Nw";
            var key = Encoding.ASCII.GetBytes(keyString);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.User_Name),
                    new Claim(ClaimTypes.Role, user.Role),


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;

        }

        public async Task<User> UpdateUser(int Id, User user)
        {
            var item = ctx.Users.Where(c => c.Id == Id).SingleOrDefault();
            _mapper.Map(user, item);

            await ctx.SaveChangesAsync();
            return user;


        }
    }
}
