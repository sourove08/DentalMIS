using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;
using DENTALMIS.Utility.HelperModel;
using System.Web.Mvc;
using DENTALMIS.Utility;
using DENTALMIS.Web.Areas.DrugSection.Models.ViewModel;
using DENTALMIS.Web.Controllers;

namespace DENTALMIS.Web.Areas.DrugSection.Controllers
{
    public class DrugGenericController :BaseController
    {
        //private readonly int _pageSize = AppConfig.PageSize;
        public ActionResult Index(DrugGenericViewModel model)
        {
            ModelState.Clear();
            //if (!model.IsSearch)
            //{
            //    model.IsSearch = true;
            //    return View(model);
            //}

            //var startPage = 0;

            //if (model.Page.HasValue && model.Page.Value>0)
            //{
            //    startPage = model.Page.Value - 1;
            //}

            var totalRecords = 0;

            model.Name = model.SearchDrugGenericName;
            //model.DrugGenerics = DrugGenericManager.GetAllGenericDrug(startPage, _pageSize, out totalRecords, model);
            model.DrugGenerics = DrugGenericManager.GetAllGenericDrug( out totalRecords, model);

            model.TotalRecords = totalRecords;

            return View(model);

        }

        public ActionResult Edit(DrugGenericViewModel model)
        {
            ModelState.Clear();
            if (model.GenericId>0)
            {
              var _drugGeneric=new DrugGeneric();

                _drugGeneric = DrugGenericManager.GetGenericDrugById(model.GenericId);
                model.GenericId = _drugGeneric.GenericId;
                model.Name = _drugGeneric.Name;
            }
            //return View(model);
            return Dialog(model);
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