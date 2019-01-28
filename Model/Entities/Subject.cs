using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public int ModalityId { get; set; }
        public int YearId { get; set; }
    }
}
