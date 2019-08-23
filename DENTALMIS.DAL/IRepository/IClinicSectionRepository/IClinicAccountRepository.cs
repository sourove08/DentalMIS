using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IClinicSectionRepository
{
   public interface IClinicAccountRepository:IRepository<ClinicAccount>
   {
       List<ClinicAccount> GetAllAccountByPaging(out int totalrecords, ClinicAccount model);



     
   }
}
