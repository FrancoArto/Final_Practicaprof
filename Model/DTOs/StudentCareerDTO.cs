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
        Subject Subject { get; set; }
        Student Student { get; set; }
        int YearOfInscription { get; set; }
    }
}
