using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.ClinicDescriptionModel;

namespace DENTALMIS.Web.Controllers
{
    public class ClinicEstablishmentController :BaseController
    {
        //
        // GET: /ClinicEstablishment/
        public ActionResult Index(ClinicEstablishmentViewModel model)
        {

            ModelState.Clear();
            var totalrecords = 0;



            model.ClinicEstablishments = ClinicEstablishmentManager.GetAllAByPaging(out totalrecords, model).Where(x => (x.Date >= model.FromDate || model.FromDate == null) && (x.Date <= model.ToDate || model.ToDate == null)).ToList(); ;



            model.TotalRecords = totalrecords;
            return View(model);
        }

        public ActionResult Edit(ClinicEstablishmentViewModel model)
        {

            if (model.EstablishmentId > 0)
            {
                ClinicEstablishment cles = ClinicEstablishmentManager.GetById(model.EstablishmentId);

                model.EstablishmentId = cles.EstablishmentId;
                model.ClinicHouseCharge = cles.ClinicHouseCharge;
                model.ElectricityBill = cles.ElectricityBill;
                model.EmployeeCost = cles.EmployeeCost;
                model.Vat = cles.Vat;
                model.Date = cles.Date;
                model.RowmaterialCost = cles.RowmaterialCost;
                model.InstrumentServiceCost = cles.InstrumentServiceCost;
                model.TotalCharge = cles.TotalCharge;




            }

            return View(model);
        }
        public JsonResult Save(ClinicEstablishmentViewModel model)
        {
            int saveIndex = 0;

            ClinicEstablishment clesEstablishment = new ClinicEstablishment();

            clesEstablishment.EstablishmentId = model.EstablishmentId;
            clesEstablishment.ClinicHouseCharge = model.ClinicHouseCharge;
            clesEstablishment.ElectricityBill = model.ElectricityBill;
            clesEstablishment.EmployeeCost = model.EmployeeCost;
            clesEstablishment.InstrumentServiceCost = model.InstrumentServiceCost;
            clesEstablishment.RowmaterialCost = model.RowmaterialCost;
            clesEstablishment.Date = model.Date;
            clesEstablishment.Vat = model.Vat;

            clesEstablishment.TotalCharge = clesEstablishment.ClinicHouseCharge + clesEstablishment.ElectricityBill +
                                            clesEstablishment.EmployeeCost + clesEstablishment.InstrumentServiceCost +
                                            clesEstablishment.RowmaterialCost + clesEstablishment.Vat;


            saveIndex = model.EstablishmentId == 0 ? ClinicEstablishmentManager.Save(clesEstablishment) : ClinicEstablishmentManager.Edit(clesEstablishment);


            return Reload(saveIndex);
        }
        public JsonResult Delete(ClinicEstablishmentViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = ClinicEstablishmentManager.Delete(model.EstablishmentId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}