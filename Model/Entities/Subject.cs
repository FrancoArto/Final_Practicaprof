using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Subject
    {
        int SubjectId { get; set; }
        string Name { get; set; }
        int WorkLoad { get; set; }
        int ModalityId { get; set; }
    }
}
