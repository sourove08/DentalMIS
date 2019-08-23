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
   public class DoctorDesignationManager:IDoctorDesignationManager
   {
       private IDoctorDesignationRepossitory _doctorDesignationRepossitory = null;


       public DoctorDesignationManager(DENTALERPDbContext context)
       {
           _doctorDesignationRepossitory=new DoctorDesignationRepository(context);
       }

       public List<DoctorsDesignation> GetAllDesignationByPaging(out int totalrecord, DoctorsDesignation model)
       {
           List<DoctorsDesignation> doctorsDesignations;


           try
           {
               doctorsDesignations = _doctorDesignationRepossitory.GetAllDesignationByPaging(out totalrecord, model);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }

           return doctorsDesignations;
       }

       public DoctorsDesignation GetDesignationById(int id)
       {


           DoctorsDesignation doctorsDesignation;
           try
           {
               doctorsDesignation =
                   _doctorDesignationRepossitory.FindOne(x => x.DoctorDesignationId == id && x.IsActive == true);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return doctorsDesignation;
       }

       public int Save(DoctorsDesignation doctorsDesignation)
       {
           int saveIndex = 0;

           try
           {
               doctorsDesignation.IsActive = true;

               saveIndex = _doctorDesignationRepossitory.Save(doctorsDesignation);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return saveIndex;
       }

       public int Edit(DoctorsDesignation doctorsDesignation)
       {
           int editIndex = 0;

           try
           {
               DoctorsDesignation _doctorsDesignation = GetDesignationById(doctorsDesignation.DoctorDesignationId);

               _doctorsDesignation.DoctorDesignationId = doctorsDesignation.DoctorDesignationId;
               _doctorsDesignation.DesignationName = doctorsDesignation.DesignationName;
               _doctorsDesignation.Description = doctorsDesignation.Description;

               editIndex = _doctorDesignationRepossitory.Save(_doctorsDesignation);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int Delete(int dId)
       {
           int deleteIndex = 0;

           try
           {
               DoctorsDesignation doctorsDesignation = GetDesignationById(dId);

               doctorsDesignation.IsActive = false;

               deleteIndex = _doctorDesignationRepossitory.Edit(doctorsDesignation);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return deleteIndex; 
       }

       public List<DoctorsDesignation> GetAllDesignation()
       {
           List<DoctorsDesignation> doctorsDesignations;


           try
           {
               doctorsDesignations = _doctorDesignationRepossitory.Filter(x => x.IsActive == true).ToList();
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return doctorsDesignations;
       }
   }
}
