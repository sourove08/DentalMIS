using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class PatientConditionController :BaseController
    {
        //
        // GET: /PatientCondition/
        public ActionResult Index(PatientConditionViewModel model)
        {
            ModelState.Clear();

          
            var totalrecords = 0;

            model.Patients = PatientManager.GetAllPatient();
            model.Diseases = DiseasesManager.GetAllDiseases();
            model.Services = ServiceManager.GetAllService();
            model.PatientConditions =
                PatientConditionManager.GetAllPatientconditionByPaging(out totalrecords, model);
            model.TotalRecords = totalrecords;
            return View(model);
        }
        public ActionResult Edit(PatientConditionViewModel model)
        {
            ModelState.Clear();
            model.Patients = PatientManager.GetAllPatient();
            model.Diseases = DiseasesManager.GetAllDiseases();
            model.Services = ServiceManager.GetAllService();

            if (model.PatientConditionId>0)
            {
                PatientCondition patientCondition =
                    PatientConditionManager.GetPatientconditionById(model.PatientConditionId);
                model.PatientConditionId = patientCondition.PatientConditionId;
                model.PatienId = patientCondition.PatienId;
                model.DiseasesId = patientCondition.DiseasesId;
                model.ServiceId = patientCondition.ServiceId;
                model.Beforetreatment = patientCondition.Beforetreatment;
                model.AfterTreatment = patientCondition.AfterTreatment;
                model.Createddate = patientCondition.Createddate;
                model.ModifiedDate = patientCondition.ModifiedDate;

            }
            return View(model);
        }

        public JsonResult GetAllThePatientByDiseasesId(int diseasesId)
        {
             List<Patient> patients = PatientConditionManager.GetAllThePatientByDiseasesId(diseasesId);

            return Json(patients, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(PatientConditionViewModel model)
        {
            ModelState.Clear();

            int saveIndex = 0;

            PatientCondition _patientCondition=new PatientCondition();
            _patientCondition.PatientConditionId = model.PatientConditionId;
            _patientCondition.PatienId = model.PatienId;
            _patientCondition.DiseasesId = model.DiseasesId;
            _patientCondition.ServiceId = model.ServiceId;
            _patientCondition.Beforetreatment = model.Beforetreatment;
            _patientCondition.AfterTreatment = model.AfterTreatment;
            _patientCondition.Createddate = model.Createddate;
            _patientCondition.ModifiedDate = model.ModifiedDate;

            saveIndex = model.PatientConditionId == 0
                ? PatientConditionManager.Save(_patientCondition)
                : PatientConditionManager.Edit(_patientCondition);
            return Reload(saveIndex);
        } //$.getJSON('/CourseAssignToTeacher/GetTeachersByDepartmentId', { id: deptId }).done(function(data) {
        //    alert(data);
        //    //$.ajax({
        //    //    type: 'GET',
        //    //    url: '/CourseAssignToTeacher/GetTeachersByDepartmentId?id=' + deptId
        //    //}).done(function (data) {


        //    //});
        //});

          //alert(data);
                //if (data.length > 0) {
                //    alert('hi');
                //    var items = '<option>---select Teacher---</option>';
                //    $.each(data, function (i, d) {
                //        alert(d);
                //        items += "<option value='" + d.TeacherId + "'>" + d.Name + "<option>";
                //    });
                //    $('#Teacher_TeacherId').html(items);
                //} else {
                //    var item = '<option> Not Found</option>';
                //    $('#Teacher_TeacherId').html(item);
                //}
        public JsonResult Delete(PatientConditionViewModel model)
        {
            ModelState.Clear();
            int deleteIndex = 0;
            try
            {
                deleteIndex = PatientConditionManager.DeleteCondition(model.PatientConditionId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }

            return deleteIndex>0?Reload(): ErroResult("Faied to Delete") ;
        }
	}
}