using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.BLL.Manager.ClinicSectionManager;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.ClinicDescriptionModel;

namespace DENTALMIS.Web.Controllers
{
    public class ClinicAccessoriesController : BaseController
    {
        //
        // GET: /ClinicAccessories/
        public ActionResult Index(ClinicAccessoryViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.Name = model.SearchbyName;

           
            model.ClinicalAccessories = ClinicAccessoryManager.GetAllAccessoriesByPaging(out totalrecords, model);



            model.TotalRecords = totalrecords;

            return View(model);

        }



        public ActionResult Edit(ClinicAccessoryViewModel model)
        {
           
            if (model.AccessoriesId > 0)
            {
                ClinicalAccessory clAssc = ClinicAccessoryManager.GetAccessoriesById(model.AccessoriesId);

                model.AccessoriesId = clAssc.AccessoriesId;
                model.Name = clAssc.Name;
                model.Purpose = clAssc.Purpose;
                model.StockAmount = clAssc.StockAmount;
                model.MarketCost = clAssc.MarketCost;




            }

            return View(model);
        }

        public JsonResult Save(ClinicAccessoryViewModel model)
        {
            int saveIndex = 0;

            ClinicalAccessory clinicalAccessory = new ClinicalAccessory();

            clinicalAccessory.AccessoriesId = model.AccessoriesId;
            clinicalAccessory.Name = model.Name;
            clinicalAccessory.Purpose = model.Purpose;
            clinicalAccessory.MarketCost = model.MarketCost;
            clinicalAccessory.StockAmount = model.StockAmount;




            saveIndex = model.AccessoriesId == 0 ? ClinicAccessoryManager.Save(clinicalAccessory) : ClinicAccessoryManager.Edit(clinicalAccessory);


            return Reload(saveIndex);
        }
        public JsonResult Delete(ClinicAccessoryViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = ClinicAccessoryManager.Delete(model.AccessoriesId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}
	
