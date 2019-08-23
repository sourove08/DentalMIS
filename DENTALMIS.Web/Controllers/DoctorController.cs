using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DoctSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DoctorController : BaseController
    {
        //
        // GET: /Doctor/
        public ActionResult Index(DoctorviewModel model)
        {

            ModelState.Clear();
            var totalrecords = 0;
            model.Name = model.SearchbyName;
            model.RegistrationNo = model.SearchByRegistrationNumber;
            model.DoctorsDesignations = DoctorDesignationManager.GetAllDesignation();
            model.Genders = GenderManager.GetAllGenderTitle();
            model.Doctors = DoctorManager.GetAllDoctorByPaging(out totalrecords, model);
                
                //.Where(x=>(x.Name==model.Name||model.Name==null)&&(x.RegistrationNo==model.RegistrationNo||model.RegistrationNo==null)&&(x.GenderId==model.GenderId||model.GenderId==0)&&(x.DessignationId==model.DessignationId||model.DessignationId==0)).ToList();

            model.TotalRecords = totalrecords;
            return View(model);
        }
        public ActionResult Edit(DoctorviewModel model)
        {
            model.Genders = GenderManager.GetAllGenderTitle();
            model.DoctorsDesignations = DoctorDesignationManager.GetAllDesignation();
            if (model.DoctorId>0)
            {
                Doctor doctor = DoctorManager.GetDoctorById(model.DoctorId);

                model.DoctorId = doctor.DoctorId;
                model.GenderId = doctor.GenderId;
                model.DessignationId = doctor.DessignationId;
                model.Name = doctor.Name;
                model.RegistrationNo = doctor.RegistrationNo;
                model.Adress = doctor.Adress;
                model.Contact = doctor.Contact;
                model.Email = doctor.Email;

                model.Website = doctor.Website;
                model.FacebookId = doctor.FacebookId;
                model.Twitter = doctor.Twitter;

            }

            return View(model);
        }
        public JsonResult Save(DoctorviewModel model)
        {
            int saveIndex = 0;

            Doctor _doctor=new Doctor();

           _doctor.DoctorId= model.DoctorId ;
           _doctor.GenderId= model.GenderId;
           _doctor.DessignationId= model.DessignationId ;
            _doctor.Name=model.Name;
           _doctor.RegistrationNo= model.RegistrationNo;
           _doctor.Adress= model.Adress;
           _doctor.Contact= model.Contact;
           _doctor.Email= model.Email ;

           _doctor.Website= model.Website;
          _doctor.FacebookId=  model.FacebookId ;
           _doctor.Twitter= model.Twitter;

            saveIndex = model.DoctorId == 0 ? DoctorManager.Save(_doctor) : DoctorManager.Edit(_doctor);


            return Reload(saveIndex);
        }
        public JsonResult Delete(DoctorviewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = DoctorManager.Delete(model.DoctorId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}