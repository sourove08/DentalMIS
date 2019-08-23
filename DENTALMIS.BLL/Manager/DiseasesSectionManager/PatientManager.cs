using System;
using System.Collections.Generic;
using System.Linq;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
  public  class PatientManager:IPatientManager
  {
      private IPatientRepository _patientRepository = null;


      public PatientManager(DENTALERPDbContext context)
      {
          _patientRepository=new PatientRepository(context);
      }

      public List<Patient> GetAllPatienByPaging(out int totalrecords, Patient model)
      {
          List<Patient> patients;

          try
          {
              patients = _patientRepository.GetAllPatienByPaging(out totalrecords, model);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }

          return patients;
      }

      public Patient GetAllPatienById(int patientId)
      {
          Patient patient;

          //try
          //{
          //    patient = _patientRepository.FindOne(x => x.PatientId == patientId);
          //}
          //catch (Exception exception)
          //{
              
          //    throw new Exception(exception.Message);
          //}
          patient = _patientRepository.FindOne(x => x.PatientId == patientId);
          return patient;
      }

      public int Save(Patient _patient)
      {
          int saveIndex = 0;
          try
          {
          
              _patient.IsActive = true;
             

              saveIndex = _patientRepository.Save(_patient);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(Patient _patient)
      {
          int editIndex = 0;

          try
          {
              Patient patient = GetAllPatienById(_patient.PatientId);
              patient.PatientId = _patient.PatientId;
              patient.PatientCode = _patient.PatientCode;
              patient.Name = _patient.Name;
              patient.GenderId = _patient.GenderId;
              patient.Age = _patient.Age;
              patient.Contact = _patient.Contact;
              patient.Address = _patient.Address;
              patient.Email = _patient.Email;
              patient.SerialNumber = _patient.SerialNumber;
              patient.VisitingtDate = _patient.VisitingtDate;
              patient.AppionmentDate = _patient.AppionmentDate;
              patient.CallingDate = _patient.CallingDate;
              patient.DiseasesId = _patient.DiseasesId;

              editIndex = _patientRepository.Edit(patient);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int DeletePatient(int patientId)
      {
          int deleteIndex = 0;

          try
          {
              Patient patient = GetAllPatienById(patientId);
              patient.IsActive = false;
              deleteIndex = _patientRepository.Edit(patient);

          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }

      public bool CheckExistingPatient(Patient patient)
      {
          bool isExist = false;

          try
          {
              isExist =
                  _patientRepository.Exist(
                      x =>
                          x.IsActive == true && x.PatientId != patient.PatientId &&
                          x.Name.Replace(" ", "").ToLower().Equals(patient.Name.Replace(" ", "").ToLower()));
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return isExist;
      }

      public List<Patient> GetAllPatient()
      {
          List<Patient> patients;
          try
          {
              patients = _patientRepository.Filter(x => x.IsActive == true).ToList();
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return patients;
      }

      public List<Patient> GetPatientByDiseasesId(int id)
      {
          List<Patient> patients = null;

          try
          {
              patients = _patientRepository.Filter(x => x.DiseasesId == id && x.IsActive == true).ToList();

          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return patients;
      }

      public Patient GetAllPatienByCode(string patientCode)
      {

          Patient patient = null;

            try
            {
                patient = _patientRepository.GetAllPatienByCode(patientCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return patient;
        
      }
  }
}
