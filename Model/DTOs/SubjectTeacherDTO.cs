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
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
