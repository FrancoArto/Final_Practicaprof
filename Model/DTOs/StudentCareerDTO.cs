using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class StudentCareerDTO
    {
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public int YearOfInscription { get; set; }
    }
}
