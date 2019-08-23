using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DoctSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DoctorDesignationController : BaseController
    {
        //
        // GET: /DoctorDesignation/
        public ActionResult Index(DoctorDesinationViewmodel model)
        {

            ModelState.Clear();
            var totalrecord = 0;

            model.DoctorsDesignations = DoctorDesignationManager.GetAllDesignationByPaging(out totalrecord, model);
            model.TotalRecords = totalrecord;

            return View(model);
        }
        public ActionResult Edit(DoctorDesinationViewmodel model)
        {


            if (model.DoctorDesignationId>0)
            {
                DoctorsDesignation doctorsDesignation =
                    DoctorDesignationManager.GetDesignationById(model.DoctorDesignationId);

                model.DoctorDesignationId = doctorsDesignation.DoctorDesignationId;
                model.DesignationName = doctorsDesignation.DesignationName;
                model.Description = doctorsDesignation.Description;

            }
            return View(model);
        }
        public JsonResult Save(DoctorDesinationViewmodel model)
        {
            int saveIndex = 0;

            DoctorsDesignation doctorsDesignation=new DoctorsDesignation();

            doctorsDesignation.DoctorDesignationId = model.DoctorDesignationId;
            doctorsDesignation.DesignationName = model.DesignationName;
            doctorsDesignation.Description = model.Description;

            saveIndex = model.DoctorDesignationId == 0
                ? DoctorDesignationManager.Save(doctorsDesignation)
                : DoctorDesignationManager.Edit(doctorsDesignation);

            return Reload(saveIndex);
        }
        public JsonResult Delete(DoctorDesinationViewmodel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = DoctorDesignationManager.Delete(model.DoctorDesignationId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }


            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}