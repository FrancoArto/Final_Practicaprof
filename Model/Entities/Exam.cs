using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int StaffId { get; set; }
        public int CouponId { get; set; }
    }
}
