using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IClinicSectionRepository
{
   public interface ICliniEstablismentRepository :IRepository<ClinicEstablishment>
   {
       List<ClinicEstablishment> GetAllAByPaging(out int totalrecords, ClinicEstablishment model);

      
   }
}
