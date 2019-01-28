using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class SubjectCareerDTO
    {
        public Subject Subject { get; set; }
        public Career Career { get; set; }
    }
}
