using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IModalitiesRepository
    {
        Modality Add(Modality modality);

        List<Modality> GetAll();

        bool Modify(int modalityId, Modality modality);

        bool Delete(int modalityId);
    }
}
