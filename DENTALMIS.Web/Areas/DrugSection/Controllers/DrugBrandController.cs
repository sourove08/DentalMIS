using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Utility;
using DENTALMIS.Web.Areas.DrugSection.Models.ViewModel;
using DENTALMIS.Web.Controllers;

namespace DENTALMIS.Web.Areas.DrugSection.Controllers
{

    public class DrugBrandController : BaseController
    {
        //private readonly int _pageSize = AppConfig.PageSize;
     
        public ActionResult Index(DrugBrandViewModel model)
        {
            ModelState.Clear();


            //var startPage = 0;

            //if (model.Page.HasValue && model.Page.Value > 0)
            //{
            //    startPage = model.Page.Value - 1;
            //}

            var totalrecords = 0;

            model.Name = model.SeachByBrandName;

            //model.DrugGenerics = DrugGenericManager.GettAllGenericDrug();

            //var   drugGenericsList = DrugGenericManager.GettAllGenericDrug();

            //var drugGenericsList = DrugGenericManager.GetAllGenericDrug((startPage, _pageSize, out totalrecords , model);

            //model.DrugGenerics = drugGenericsList.Where(x=>x.GenericId==model.GenericId|| model.GenericId==0).ToList();

            //ViewBag.SearchByGenericDSrug=new SelectList(drugGenericsList,"GenericId","Name");
            //var genericId = model.SearchByGenericDSrug;
            //var genericId = model.SearchByGenericDSrug;

            // var drugBrandlist = DrugBrandManager.GetAllDrugBrandByGeneric(genericId);

            // ViewBag.SearchByDrugBrand=new SelectList(drugBrandlist,"BrandId","Name",model.SearchByDrugBrand);
            model.DrugGenerics = DrugGenericManager.GettAllGenericDrug();

            //model.DrugBrands = DrugBrandManager.GetAllDrugBrand(startPage, _pageSize, out totalrecords, model);
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
    }
}