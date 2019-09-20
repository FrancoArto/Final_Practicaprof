using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IExamsRepository
    {
        Exam Add(Exam exam);

        List<Exam> GetAll();

        List<Exam> GetExamsByStudentId(int studentId);

        bool Modify(int examId, Exam exam);

        bool Delete(int examId);

        Exam GetExamById(int examId);
    }
}
