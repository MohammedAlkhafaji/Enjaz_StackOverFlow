using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using Enjaz_StackOverFlow.Services;
using Microsoft.AspNetCore.Mvc;


namespace Enjaz_StackOverFlow.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(LoginForm loginForm)
        {
            return Ok(await _userService.Login(loginForm));
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            return Ok(await _userService.Getall());
        }
        [HttpGet("GetUserPoint")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserPoint(Int32 User_Id)
        {

            return Ok(await _userService.GetUserPoint(User_Id));
        }




        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> AddUser(UserForm user)
        {
            user = await _userService.AddNewUser(user);
            return Ok(user);

        }


        [HttpPut("UpdateUser")]
       
        public async Task<ActionResult<User>> UpdateUser(int Id, User user)
        {
            user = await _userService.UpdateUser(Id, user);
            return Ok(user);

        }



    }
}