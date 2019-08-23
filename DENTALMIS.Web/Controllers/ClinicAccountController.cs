using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.ClinicDescriptionModel;

namespace DENTALMIS.Web.Controllers
{
    public class ClinicAccountController : BaseController
    {
        //
        // GET: /ClinicAccount/
        public ActionResult Index(ClinicAcountViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;



            model.ClinicAccounts = ClinicAccountManager.GetAllAccountByPaging(out totalrecords, model).Where(x => (x.Date >= model.FromDate || model.FromDate == null) && (x.Date <= model.ToDate || model.ToDate == null)).ToList(); ;



            model.TotalRecords = totalrecords;

            return View(model);

        }



        public ActionResult Edit(ClinicAcountViewModel model)
        {
            ClinicAccount clinicAccount = ClinicAccountManager.GetAccountiesById(model.ClinicAccountId);
            if (model.ClinicAccountId > 0)
            {


                model.ClinicAccountId = clinicAccount.ClinicAccountId;
                model.Income = clinicAccount.Income;
                model.OutCome = clinicAccount.OutCome;
                model.Date = clinicAccount.Date;
                model.DayTotalIncome = clinicAccount.DayTotalIncome;
                model.TotalIncome = clinicAccount.TotalIncome;




            }


            return View(model);
        }

        public List<ClinicAccount> GetAllATotalIncomeById()
        {
            List<ClinicAccount> totalIncomes = ClinicAccountManager.GetAllATotalIncomeById();

            return totalIncomes;
        }

        public JsonResult Save(ClinicAcountViewModel model)
        {


            int saveIndex = 0;



            ClinicAccount clinicAccount = new ClinicAccount();
            clinicAccount.ClinicAccountId = model.ClinicAccountId;
            clinicAccount.Income = model.Income;
            clinicAccount.OutCome = model.OutCome;
            clinicAccount.Date = model.Date;
            clinicAccount.DayTotalIncome = clinicAccount.Income - clinicAccount.OutCome;
            clinicAccount.TotalIncome = clinicAccount.DayTotalIncome;


            List<ClinicAccount> allATotalIncomeById = GetAllATotalIncomeById();

            foreach (ClinicAccount account in allATotalIncomeById)
            {

                clinicAccount.TotalIncome += account.DayTotalIncome;


            }
            saveIndex = model.ClinicAccountId == 0 ? ClinicAccountManager.Save(clinicAccount) : ClinicAccountManager.Edit(clinicAccount); ;

            return Reload(saveIndex);
        }
        public JsonResult Delete(ClinicAcountViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = ClinicAccountManager.Delete(model.ClinicAccountId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
    }
}