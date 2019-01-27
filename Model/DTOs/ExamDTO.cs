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
        int ExamId { get; set; }
        DateTime Date { get; set; }
        decimal Grade { get; set; }
        string Description { get; set; }
        ExamType Type { get; set; }
        Subject Subject { get; set; }
        Student Student { get; set; }
        Staff Staff { get; set; }
        Coupon Coupon { get; set; }
    }
}
