using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.Repository.ClinicSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IClinicSectionManager
{
   public interface IClinicAccountManager
    {
       List<ClinicAccount> GetAllAccountByPaging(out int totalrecords, ClinicAccount model);

       ClinicAccount GetAccountiesById(int id);

       int Save(ClinicAccount clinicAccount);

       int Edit(ClinicAccount clinicAccount);

       int Delete(int id);

      
    
        List<ClinicAccount> GetAllATotalIncomeById();}
}
