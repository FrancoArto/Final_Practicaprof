using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class StudentCareer
    {
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int YearOfInscription { get; set; }
    }
}
