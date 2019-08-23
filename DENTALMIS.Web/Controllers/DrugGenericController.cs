using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Areas.DrugSection.Models.ViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DrugGenericController : BaseController
    {
        
        public ActionResult Index(DrugGenericViewModel model)
        {
            ModelState.Clear();
           

            var totalRecords = 0;

            model.Name = model.SearchDrugGenericName;

            model.DrugGenerics = DrugGenericManager.GetAllGenericDrug(out totalRecords, model);

            model.TotalRecords = totalRecords;

            return View(model);

        }

        public ActionResult Edit(DrugGenericViewModel model)
        {
            ModelState.Clear();
            if (model.GenericId > 0)
            {
                var _drugGeneric = new DrugGeneric();

                _drugGeneric = DrugGenericManager.GetGenericDrugById(model.GenericId);
                model.GenericId = _drugGeneric.GenericId;
                model.Name = _drugGeneric.Name;
            }
            return View(model);
        }

        public JsonResult Save(DrugGenericViewModel model)
        {
            int saveIndex = 0;

            var _drugGeneric = new DrugGeneric();
            _drugGeneric.GenericId = model.GenericId;
            _drugGeneric.Name = model.Name;
            saveIndex = model.GenericId == 0 ? DrugGenericManager.SaveDrugGeneric(_drugGeneric) : DrugGenericManager.EditDrugGenerIc(_drugGeneric);
            return saveIndex > 0 ? Reload() : ErroeMessageResult();
        }

        public JsonResult Delete(DrugGenericViewModel model)
        {
            int deleteIndex = 0;

            try
            {
                deleteIndex = DrugGenericManager.DeleteDrugGeneric(model.GenericId);
            }
            catch (Exception exception)
            {

                return ErroResult(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete ");

        }
	}
}