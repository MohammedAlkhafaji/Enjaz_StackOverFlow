using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Dtos
{
    public class ReplyDto
    {
        public string Description { get; set; }
        public int User_Id { get; set; }
        public int Comment_Id { get; set; }
        public DateTime Question_Date { get; set; }
        public int Question_Id { get; set; }
    }
}
