using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Enjaz_StackOverFlow.Models
{
    public class User
    {

        public User()
        {
            Point = 5;
            Role = "User";
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string Person_Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte[] Profile_Picture { get; set; }
        public DateTime Creation_Date { get; set; }
        public int Point { get; set; } 
        [NotMapped]
        public string Token { get; set; }
        public string Role { get; set; }
     
    }
}
