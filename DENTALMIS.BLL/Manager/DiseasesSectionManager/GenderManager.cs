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
   public class GenderManager:IGenderManager
   {
       private IGenderRepository _genderRepository = null;

       public GenderManager(DENTALERPDbContext context)
       {
           _genderRepository=new GenderRepository(context);
       }

       public List<Gender> GetAllGender(out int totalrecords, Gender model)
       {
           List<Gender> genders;

           try
           {
               genders = _genderRepository.GetAllGender(out totalrecords, model);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return genders;
       }

       public Gender GetGenderById(int genderId)
       {
           Gender gender=new Gender();

           try
           {
               gender = _genderRepository.FindOne(x => x.GenderId == genderId);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return gender;
       }

       public int Save(Gender _gender)
       {
           int saveIndex = 0;

           try
           {
               _gender.IsActive = true;
               saveIndex = _genderRepository.Save(_gender);

           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return saveIndex;

       }

       public int Edit(Gender _gender)
       {
           int editIndex = 0;

           try
           {

               var gender = GetGenderById(_gender.GenderId);
               gender.GenderId = _gender.GenderId;
               gender.Title = _gender.Title;
               editIndex = _genderRepository.Edit(gender);

           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int DeleteGender(int genderId)
       {
           int deleteIndex = 0;

           try
           {
               Gender gender = GetGenderById(genderId);
               gender.IsActive = false;
               deleteIndex = _genderRepository.Edit(gender);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return deleteIndex;
       }

       public List<Gender> GetAllGenderTitle()
       {
           List<Gender> genders;

           try
           
           {
               genders = _genderRepository.Filter(x => x.IsActive == true).ToList();
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return genders;
       }
   }
}
