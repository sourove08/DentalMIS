using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.ClinicDescriptionModel;
using DENTALMIS.Web.Models.EmployeeViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class ClinicDetailsController : BaseController
    {
        public ActionResult Index(ClinicDetailsViewModel model)
        {


            ModelState.Clear();
            var totalrecords = 0;

            model.Name = model.SearchByNamee;



            model.ClincDescriptions = ClinicDescriptionManager.GetAllCDE(out totalrecords, model);


            model.TotalRecords = totalrecords;

            return View(model);
        }
        public ActionResult Edit(ClinicDetailsViewModel model)
        {
           
            if (model.ClinicDescriptionId> 0)
            {
                ClincDescription cl = ClinicDescriptionManager.GetClinicById(model.ClinicDescriptionId);

                model.ClinicDescriptionId = cl.ClinicDescriptionId;
                model.Name = cl.Name;
                model.ClinicType = cl.ClinicType;
               
                model.Address = cl.Address;
                model.ClinicContact = cl.ClinicContact;
                model.ClinicMail = cl.ClinicMail;
                model.websilte = cl.websilte;


            }


            return View(model);
        }
        public JsonResult Save(ClinicDetailsViewModel model)
        {
            int saveIndex = 0;

            ClincDescription cl = new ClincDescription();

            cl.ClinicDescriptionId = model.ClinicDescriptionId;
            cl.Name = model.Name;
            cl.ClinicType = model.ClinicType;
            cl.Name = model.Name;
            cl.ClinicContact = model.ClinicContact;
            cl.Address = model.Address;
            cl.ClinicMail = model.ClinicMail;
            cl.websilte = model.websilte;



            saveIndex = model.ClinicDescriptionId == 0 ? ClinicDescriptionManager.Save(cl) : ClinicDescriptionManager.Edit(cl);


            return Reload(saveIndex);
        }
        public JsonResult Delete(ClinicDetailsViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = ClinicDescriptionManager.Delete(model.ClinicDescriptionId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}