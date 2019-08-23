using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class PatientController : BaseController
    {
        //
        // GET: /Patient/
        public ActionResult Index(PatientViewModel model)
        {
            ModelState.Clear();
           
            var totalrecords = 0;
            model.Name = model.SearchByName;
            model.Genders = GenderManager.GetAllGenderTitle();
            model.Diseases = DiseasesManager.GetAllDiseases();
            model.Patients = PatientManager.GetAllPatienByPaging(out totalrecords, model).Where(x=>(x.VisitingtDate>=model.FromDate|| model.FromDate==null)&&(x.VisitingtDate<=model.ToDate||model.ToDate==null)).ToList();
            model.TotalRecords = totalrecords;
           

            return View(model);
        }

        public ActionResult Edit(PatientViewModel model)
        {
            ModelState.Clear();
            model.Genders = GenderManager.GetAllGenderTitle();
            model.Diseases = DiseasesManager.GetAllDiseases();

            if (model.PatientId > 0)
            {
                var patient = PatientManager.GetAllPatienById(model.PatientId) ?? new Patient();

                model.PatientId = patient.PatientId;
               
                model.Name = patient.Name;
                model.Age = patient.Age;
                model.Contact = patient.Contact;
                model.Email = patient.Email;
                model.SerialNumber = patient.SerialNumber;
                model.Address = patient.Address;
                model.CallingDate = patient.CallingDate;
                model.VisitingtDate = patient.VisitingtDate;
                model.AppionmentDate = patient.AppionmentDate;
                model.GenderId = patient.GenderId;
                model.DiseasesId = patient.DiseasesId;
                model.PatientCode = patient.PatientCode;
            }
            return View(model);
        }

        public JsonResult Save(PatientViewModel model)
        {

            var isExist = PatientManager.CheckExistingPatient(model);
            if (isExist)
            {
                return ErroResult(model.Name + " " + "Patient All ready Exist");
            }
            int saveindex = 0;
            Patient _patient = new Patient();
            _patient.PatientId = model.PatientId;
          
            _patient.Name = model.Name;
            _patient.Age = model.Age;
            _patient.PatientCode = model.PatientCode;
            _patient.Contact = model.Contact;
            _patient.Email = model.Email;
            _patient.SerialNumber = model.SerialNumber;
            _patient.Address = model.Address;
            _patient.CallingDate = model.CallingDate;
            _patient.VisitingtDate = model.VisitingtDate;
            _patient.AppionmentDate = model.AppionmentDate;
            _patient.GenderId = model.GenderId;
            _patient.DiseasesId = model.DiseasesId;

            saveindex = model.PatientId == 0 ? PatientManager.Save(_patient) : PatientManager.Edit(_patient);
            return Reload(saveindex);
        }

        public JsonResult Delete(PatientViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = PatientManager.DeletePatient(model.PatientId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
    }
}