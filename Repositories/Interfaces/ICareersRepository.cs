using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICareersRepository
    {
        Career Add(Career career);

        List<Career> GetAll();

        bool Modify(int careerId, Career career);

        bool Delete(int careerId);

        Career GetCareerById(int careerId);
    }
}
