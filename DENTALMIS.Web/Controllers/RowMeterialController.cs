using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.ClinicDescriptionModel;

namespace DENTALMIS.Web.Controllers
{
    public class RowMeterialController : BaseController
    {
        //
        // GET: /RowMeterial/
        public ActionResult Index(ClinicRowMeterialViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.Name = model.SearchbyNamesd;


            model.RowMatrials = RowMeterialManager.GetAllRowMeterial(out totalrecords, model);



            model.TotalRecords = totalrecords;


            return View(model);
        }
        public ActionResult Edit(ClinicRowMeterialViewModel model)
        {
            if (model.RowMaterialId>0)
            {
                RowMatrial meterials = RowMeterialManager.GetRowMeterialById(model.RowMaterialId);

                model.RowMaterialId = meterials.RowMaterialId;
                model.Name = meterials.Name;
                model.Cost = meterials.Cost;
                model.ManufacturingDate = meterials.ManufacturingDate;
                model.ExpireDate = meterials.ExpireDate;
                model.Amount = meterials.Amount;
            }
            return View(model);
        }
            public JsonResult Save(ClinicRowMeterialViewModel model)
        {
            int saveIndex = 0;

            RowMatrial mt = new RowMatrial();

            mt.RowMaterialId = model.RowMaterialId;
            mt.Name = model.Name;
            mt.Cost = model.Cost;
            mt.ManufacturingDate = model.ManufacturingDate;
            mt.ExpireDate = model.ExpireDate;
                mt.Amount = model.Amount;




            saveIndex = model.RowMaterialId == 0 ? RowMeterialManager.Save(mt) : RowMeterialManager.Edit(mt);


            return Reload(saveIndex);
        }
        public JsonResult Delete(ClinicRowMeterialViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = RowMeterialManager.Delete(model.RowMaterialId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
    }
