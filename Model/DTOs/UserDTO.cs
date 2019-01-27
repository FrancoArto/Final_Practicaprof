using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class UserDTO
    {
        int UserId { get; set; }
        string Email { get; set; }
        string UserPassword { get; set; }
        DateTime LastLogin { get; set; }
        UserStatus Status { get; set; }
        UserType TypeId { get; set; }
    }
}
