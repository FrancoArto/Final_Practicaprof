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
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public Modality ModalityId { get; set; }
        public Year YearId { get; set; }
    }
}
