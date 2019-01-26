using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User
    {
        int UserId { get; set; }
        string Email { get; set; }
        string UserPassword { get; set; }
        DateTime LastLogin { get; set; }
        int Status { get; set; }
        int TypeId { get; set;}


    }
}
