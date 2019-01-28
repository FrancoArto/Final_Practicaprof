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
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public DateTime LastLogin { get; set; }
        public UserStatus Status { get; set; }
        public UserType TypeId { get; set; }
    }
}
