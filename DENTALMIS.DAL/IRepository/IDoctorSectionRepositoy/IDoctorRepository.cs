using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDoctorSectionRepositoy
{
   public interface IDoctorRepository :IRepository<Doctor>
   {
       List<Doctor> GetAllDoctorByPaging(out int totalrecords, Doctor model);
   }
}
