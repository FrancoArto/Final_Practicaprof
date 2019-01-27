using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class SubjectDTO
    {
        int SubjectId { get; set; }
        string Name { get; set; }
        int WorkLoad { get; set; }
        Modality ModalityId { get; set; }
        Year YearId { get; set; }
    }
}
