using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IClinicSectionRepository
{
    public interface IClinicDescriptionRepository : IRepository<ClincDescription>
   {
       List<ClincDescription> GetAllCDE(out int totalrecords, ClincDescription model);
   }
}
