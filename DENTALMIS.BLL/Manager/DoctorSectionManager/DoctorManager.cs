using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IDoctorSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDoctorSectionRepositoy;
using DENTALMIS.DAL.Repository.DoctorSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DoctorSectionManager
{
  public  class DoctorManager:IDoctorManager
    {
      private IDoctorRepository _doctorRepository=null;

      public DoctorManager(DENTALERPDbContext context)
      {
          _doctorRepository=new DoctorRepository(context);
      }

      public List<Doctor> GetAllDoctorByPaging(out int totalrecords, Doctor model)
      {
          List<Doctor> doctors = null; 

            try
            {
               doctors= _doctorRepository.GetAllDoctorByPaging(out totalrecords, model);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return doctors;
        }

      public Doctor GetDoctorById(int id)
      {
          Doctor doctor = null;

          try
          {
              doctor = _doctorRepository.FindOne(x=>x.DoctorId==id && x.IsActive==true);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return doctor;
      }

      public int Save(Doctor _doctor)
      {
          int saveIndex = 0;

          try
          {
              _doctor.IsActive = true;
              saveIndex = _doctorRepository.Save(_doctor);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(Doctor _doctor)
      {
          int editIndex = 0;

          try
          {

              Doctor doctor = GetDoctorById(_doctor.DoctorId);

              doctor.DoctorId = _doctor.DoctorId;
              doctor.GenderId = _doctor.GenderId;
              doctor.DessignationId = _doctor.DessignationId;
              doctor.Name = _doctor.Name;
              doctor.RegistrationNo = _doctor.RegistrationNo;
              doctor.Adress = _doctor.Adress;
              doctor.Contact = _doctor.Contact;
              doctor.Email = _doctor.Email;
              doctor.Website = _doctor.Website;
              doctor.FacebookId = _doctor.FacebookId;
              doctor.Twitter = _doctor.Twitter;
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int Delete(int id)
      {
          int deleteIndex = 0;

          try
          {
              Doctor doctor = GetDoctorById(id);
              doctor.IsActive = false;
              deleteIndex = _doctorRepository.Edit(doctor);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }
    }
    }

