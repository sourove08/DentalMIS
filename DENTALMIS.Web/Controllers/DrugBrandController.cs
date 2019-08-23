using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DENTALMIS.Model;
using DENTALMIS.Web.Areas.DrugSection.Models.ViewModel;
using DENTALMIS.Web.Models.ClinicDescriptionModel;
using DENTALMIS.Web.ReportHelper;

namespace DENTALMIS.Web.Controllers
{
    public class DrugBrandController : BaseController
    {
        public ActionResult Index(DrugBrandViewModel model)
        {
            ModelState.Clear();
            model.Name = model.SeachByBrandName;
            //if (!model.IsSearch)
            //{
            //    model.IsSearch = true;
            //    return View(model);
            //}

            var totalrecords = 0;

           

           
            model.DrugGenerics = DrugGenericManager.GettAllGenericDrug();

            model.DrugBrands = DrugBrandManager.GetAllDrugBrand(out totalrecords, model);
            model.TotalRecords = totalrecords;

            return View(model);
        }


        public ActionResult Edit(DrugBrandViewModel model)
        {
            ModelState.Clear();
            model.DrugGenerics = DrugGenericManager.GettAllGenericDrug();
            if (model.BrandId > 0)
            {



                var _drugBrand = DrugBrandManager.GetBrandDrugById(model.BrandId) ?? new DrugBrand(); ;

                model.BrandId = _drugBrand.BrandId;
                model.Name = _drugBrand.Name;
                model.Preparation = _drugBrand.Preparation;
                model.GenericId = _drugBrand.GenericId;

            }
            return View(model);
        }


        public JsonResult Save(DrugBrandViewModel model)
        {
            int saveIndex = 0;

            var _drugBrand = new DrugBrand();

            _drugBrand.BrandId = model.BrandId;
            _drugBrand.Name = model.Name;
            _drugBrand.Preparation = model.Preparation;
            _drugBrand.GenericId = model.GenericId;
            saveIndex = model.BrandId == 0 ? DrugBrandManager.SaveDrugBrand(_drugBrand) : DrugBrandManager.EditDrugBrand(_drugBrand);
            //return saveIndex > 0 ? Reload(saveIndex) : ErroeMessageResult();
            return Reload(saveIndex);
        }

        public JsonResult Delete(DrugBrandViewModel model)
        {
            int deleteIndex = 0;

            try
            {
                deleteIndex = DrugBrandManager.DeleteDrugBrand(model.BrandId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed to delete");
        }
        public void GetExcel(DrugBrandViewModel model)
        {
            List<DrugBrand> drugBrands = DrugBrandManager.Getdrugs();
            model.DrugBrands = drugBrands;

            const string fileName = "DrugBrands";
            var boundFields = new List<BoundField>
            {
                new BoundField(){HeaderText = @"Brand Name", DataField = "Name"},
                new BoundField(){HeaderText = @"Description", DataField = "Preparation"},
                new BoundField(){HeaderText = @"Generic Name", DataField = "DrugGeneric.Name"}
            };
            ReportConverter.CustomGridView(boundFields, model.DrugBrands, fileName);
        }

        public ActionResult Print(DrugBrandViewModel model)
        {
            var totalrecords = 0;
            //List<DrugBrand> drugBrands = DrugBrandManager.GetdrugBySearchKey(model.SeachByBrandName);

            List<DrugBrand> drugBrands = DrugBrandManager.Getdrugs();
            //List<DrugBrand> drugBrands = DrugBrandManager.GetAllDrugBrand(out totalrecords, model);
            model.DrugBrands = drugBrands;
            return View("_DrugBrandtPdfReport", model);
        }

     
	}
}