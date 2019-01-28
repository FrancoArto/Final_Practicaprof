using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    class ExamDTO
    {
        public int ExamId { get; set; }
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public ExamType Type { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public Staff Staff { get; set; }
        public Coupon Coupon { get; set; }
    }
}
