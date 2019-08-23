using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IClinicSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IClinicSectionRepository;
using DENTALMIS.DAL.Repository.ClinicSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.ClinicSectionManager
{
   public class ClinicAccountManager:IClinicAccountManager
   {
       private IClinicAccountRepository _clinicAccountRepository = null;

       public ClinicAccountManager(DENTALERPDbContext context)
       {
           _clinicAccountRepository=new ClinicAccounRepositoroy(context);
       }

       public List<ClinicAccount> GetAllAccountByPaging(out int totalrecords, ClinicAccount model)
       {

           List<ClinicAccount> clinicAccounts;
           try
           {
               clinicAccounts = _clinicAccountRepository.GetAllAccountByPaging(out totalrecords, model);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }

           return clinicAccounts;
       }

       public ClinicAccount GetAccountiesById(int id)
       {
           ClinicAccount clinicAccount;
           try
           {
               clinicAccount = _clinicAccountRepository.FindOne(x => x.ClinicAccountId == id && x.IsActive == true);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return clinicAccount;
       }

       public int Save(ClinicAccount clinicAccount)
       {
           int saveIndex = 0;

           try
           {
              
               clinicAccount.IsActive = true;
               //clinicAccount.TotalIncome = clinicAccount.TotalIncome + clinicAccount.DayTotalIncome;
               saveIndex = _clinicAccountRepository.Save(clinicAccount);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return saveIndex;
       }

       public int Edit(ClinicAccount clinicAccount)
       {
           int editIndex = 0;
           try
           {
               List<ClinicAccount> clinic = GetAllATotalIncomeById();
               ClinicAccount  _clinicAccount = GetAccountiesById(clinicAccount.ClinicAccountId);
               _clinicAccount.ClinicAccountId = clinicAccount.ClinicAccountId;
               _clinicAccount.Income = clinicAccount.Income;
               _clinicAccount.OutCome = clinicAccount.OutCome;
               _clinicAccount.Date = clinicAccount.Date;
               _clinicAccount.DayTotalIncome =clinicAccount.Income- clinicAccount.OutCome;

               _clinicAccount.TotalIncome = clinicAccount.TotalIncome;
               //foreach (ClinicAccount account in clinic)
               //{
               //    _clinicAccount.TotalIncome += account.DayTotalIncome;
               //}

               editIndex = _clinicAccountRepository.Edit(_clinicAccount);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int Delete(int id)
       {
           int deleteIndex = 0;
           try
           {
               ClinicAccount clinicAccount = GetAccountiesById(id);

               clinicAccount.IsActive = false;

               deleteIndex = _clinicAccountRepository.Edit(clinicAccount);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return deleteIndex;
       }

       public List<ClinicAccount> GetAllATotalIncomeById()
       {
           
           List<ClinicAccount> totalIncome;

           try
           {
               totalIncome =
                   _clinicAccountRepository.All().Where(x=>x.IsActive==true).ToList();
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return totalIncome;
       }

      
       
   }
}
