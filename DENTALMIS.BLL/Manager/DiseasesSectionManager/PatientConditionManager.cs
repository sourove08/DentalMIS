using System;
using System.Collections.Generic;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
   public class PatientConditionManager: IPatientConditionManager
   {
       private IPatientConditionRepository _patientConditionRepository = null;

       public PatientConditionManager(DENTALERPDbContext context)
       {
           _patientConditionRepository=new PatientConditionRepository(context);
       }


       public List<PatientCondition> GetAllPatientconditionByPaging(out int totalrecords, PatientCondition model)
       {
           List<PatientCondition> patientConditions;
           try
           {
               patientConditions = _patientConditionRepository.GetAllPatientconditionByPaging(out totalrecords, model);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return patientConditions;
       }

       public PatientCondition GetPatientconditionById(int patientConditionId)
       {

           PatientCondition patientCondition;
           try
           {
               patientCondition = _patientConditionRepository.FindOne(x => x.PatientConditionId == patientConditionId);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return patientCondition;


       }

       public int Save(PatientCondition _patientCondition)
       {
           int saveIndex = 0;

           try
           {
               _patientCondition.IsActive = true;
               _patientCondition.Createddate = DateTime.Now;
               saveIndex = _patientConditionRepository.Save(_patientCondition);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return saveIndex;
       }

       public int Edit(PatientCondition _patientCondition)
       {
           int editIndex = 0;

           try
           {
               PatientCondition patientCondition = GetPatientconditionById(_patientCondition.PatientConditionId);
               patientCondition.PatientConditionId=_patientCondition.PatientConditionId;
               patientCondition.PatienId = _patientCondition.PatienId;
               patientCondition.DiseasesId = _patientCondition.DiseasesId;
               patientCondition.ServiceId = _patientCondition.ServiceId;
               patientCondition.Beforetreatment = _patientCondition.Beforetreatment;
               patientCondition.AfterTreatment = _patientCondition.AfterTreatment;
               //patientCondition.Createddate = DateTime.Now;
               patientCondition.ModifiedDate = DateTime.Now;
               editIndex = _patientConditionRepository.Edit(patientCondition);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int DeleteCondition(int patientConditionId)
       {
           int deleteIndex = 0;
           try
           {
               PatientCondition patientCondition = GetPatientconditionById(patientConditionId);
               patientCondition.IsActive = false;
               deleteIndex = _patientConditionRepository.Edit(patientCondition);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }

           return deleteIndex;
       }

       public List<Patient> GetAllThePatientByDiseasesId(int diseasesId)
       {
           return _patientConditionRepository.GetAllThePatientByDiseasesId(diseasesId);
       }
   }
}
