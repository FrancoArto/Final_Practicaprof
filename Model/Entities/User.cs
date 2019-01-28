using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public DateTime LastLogin { get; set; }
        public int Status { get; set; }
        public int TypeId { get; set;}


    }
}
