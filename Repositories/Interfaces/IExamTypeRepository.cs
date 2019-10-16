using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IExamTypeRepository
    {
        ExamType Add(ExamType examType);

        List<ExamType> GetAll();

        bool Modify(int examTypeId, ExamType examType);

        bool Delete(int examTypeId);
    }
}
