using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Exam
    {
        int ExamId { get; set; }
        DateTime Date { get; set; }
        decimal Grade { get; set; }
        string Description { get; set; }
        int TypeId { get; set; }
        int SubjectId { get; set; }
        int StudentId { get; set; }
        int StaffId { get; set; }
        int CouponId { get; set; }
    }
}
