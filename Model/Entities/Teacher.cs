using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Teacher
    {
        int UserId { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
    }
}
