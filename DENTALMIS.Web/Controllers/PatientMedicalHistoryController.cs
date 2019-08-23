using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Utility.HelperModel;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class PatientMedicalHistoryController :BaseController
    {
        //
        // GET: /PatientMedicalHistory/
        public ActionResult Index( PatientMedicalHistoryViewModel model,int? diseasesId,int? patientId)
        {
            

            ModelState.Clear();
            var totalrecords = 0;

            model.Patients = PatientManager.GetAllPatient();
            model.Diseases = DiseasesManager.GetAllDiseases();
            //model.Patients = PatientManager.GetPatientByDiseasesId(model.SearchField.SearchByDiseasesId);
            //GetAllPatientByDiseasesId(3);

            //ViewBag.DiseasesList = new SelectList(DiseasesManager.GetAllDiseases(), "DiseasesId", "Name");
            //ViewBag.PatientList = new SelectList(new List<Patient>(), "PatientId", "Name");
            model.PatientsMedicalHistories =
                PatientMedicalHistoryManager.GetAllMedicalHistoriesByPaging(out totalrecords, model,diseasesId,patientId);
            model.TotalRecords = totalrecords;
            return View(model);
          
        }
        public ActionResult Edit(PatientMedicalHistoryViewModel model)
      {
            ModelState.Clear();


            //ViewBag.Diseases = new SelectList(DiseasesManager.GetAllDiseases(), "DiseasesId", "Name");
            //ViewBag.Patients = new SelectList(new List<Patient>(), "PatientId", "Name");
            model.Patients = PatientManager.GetAllPatient();
            model.Diseases = DiseasesManager.GetAllDiseases();
            //model.Patients = PatientManager.GetPatientByDiseasesId(model.SearchField.SearchByDiseasesId);
            if (model.PatientHistoryId>0)
            {
                var patientsMedicalHistory =
                PatientMedicalHistoryManager.GetHistorybyId(model.PatientHistoryId);

                model.PatientHistoryId = patientsMedicalHistory.PatientHistoryId;
                model.PatientId = patientsMedicalHistory.PatientId;
                model.DiseasesId = patientsMedicalHistory.DiseasesId;
                model.VitalSign = patientsMedicalHistory.VitalSign;
                model.Medicalhistory = patientsMedicalHistory.Medicalhistory;
                model.CreatedDate = patientsMedicalHistory.CreatedDate;
                model.ModifiedDate = patientsMedicalHistory.ModifiedDate;

            }

            return View(model);
        }

        //public ActionResult Edit1(int diseasesid)
        //{
        //    return View(in)
        //}
        public JsonResult GetAllPatientByDiseasesId(int id)
     {
            var patiens = PatientManager.GetPatientByDiseasesId( id);
            return Json(patiens, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetPatientbyDiseases(int diseasesId)
        {
            List<Patient> patients = PatientMedicalHistoryManager.GetPatientbyDiseases(diseasesId);
            return Json(patients, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetPByDId()
        //{
        //    //var patients= PatientManager.GetPatientByDiseasesId(int diseasesId)
        //    //return Json(new {Success = true, Patients = patients}, JsonRequestBehavior.AllowGet);
        //    return 
        //}

        public JsonResult Save(PatientMedicalHistoryViewModel model)
        {
            //model.Patients = PatientManager.GetAllPatient();
            //model.Diseases = DiseasesManager.GetAllDiseases();
            //model.Patients = PatientManager.GetPatientByDiseasesId(model.SearchField.SearchByDiseasesId);
            int saveIndex = 0;
           
            PatientsMedicalHistory _patientsMedicalHistory=new PatientsMedicalHistory();
            _patientsMedicalHistory.PatientHistoryId = model.PatientHistoryId;
            _patientsMedicalHistory.PatientId = model.PatientId;
            _patientsMedicalHistory.DiseasesId = model.DiseasesId;
            _patientsMedicalHistory.VitalSign = model.VitalSign;
            _patientsMedicalHistory.Medicalhistory = model.Medicalhistory;
            _patientsMedicalHistory.CreatedDate = model.CreatedDate;
            _patientsMedicalHistory.ModifiedDate = model.ModifiedDate;

            saveIndex = model.PatientHistoryId == 0
                ? PatientMedicalHistoryManager.Save(_patientsMedicalHistory)
                : PatientMedicalHistoryManager.Edit(_patientsMedicalHistory);
            return Reload(saveIndex);

        }
        public JsonResult Delete(PatientMedicalHistoryViewModel model)
        {
            int deleteindex = 0;

            try
            {
                deleteindex = PatientMedicalHistoryManager.DeleteHistory(model.PatientHistoryId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteindex > 0 ? Reload() : ErroResult("Failed To saved");
        }
	}
}