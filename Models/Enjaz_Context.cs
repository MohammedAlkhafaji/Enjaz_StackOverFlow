using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Enjaz_StackOverFlow.Models
{
    public class Enjaz_Context : DbContext
    {
        public Enjaz_Context(DbContextOptions dbContextOptions ):base(dbContextOptions)
        {
             
        }
 
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Question_History> Question_Histories { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<User> Users { get; set; }





        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DB_Enjaz_StackOverFlow;Persist Security Info=True");
        //    }
        //}

    }
}
