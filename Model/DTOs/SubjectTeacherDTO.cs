using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class SubjectTeacherDTO
    {
        Subject Subject { get; set; }
        Teacher Teacher { get; set; }
    }
}
