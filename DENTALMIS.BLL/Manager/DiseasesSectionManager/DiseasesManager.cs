using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
   public class DiseasesManager:IDiseasesManager
   {
       private IDiseasesRepository _diseasesRepository = null;


       public DiseasesManager(DENTALERPDbContext context)
       {
           _diseasesRepository=new DiseasesRepository(context);
       }

       public List<Disease> GetAllDiseasesByPaging(out int totalrecords, Disease model)
       {
           List<Disease> _diseases;

           try
           {
               _diseases = _diseasesRepository.GettAllDiseasesPaging(out totalrecords, model);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return _diseases;

       }

       public Disease GetDeasesById(int diseasesId)
       {
           Disease disease=new Disease();

           try
           {
               disease = _diseasesRepository.FindOne(x => x.DiseasesId == diseasesId);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return disease;
       }

       public int Save(Disease _disease)
       {
           int saveIndex = 0;
           try
           {
               _disease.IsActive = true;
               saveIndex = _diseasesRepository.Save(_disease);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return saveIndex;
       }

       public int Edit(Disease _disease)
       {
           int editIndex = 0;
           try
           {
               Disease disease = GetDeasesById(_disease.DiseasesId);
               disease.DiseasesId = _disease.DiseasesId;
               disease.Name = _disease.Name;
               disease.Aetiology = _disease.Aetiology;
               disease.Pathophysiology = _disease.Pathophysiology;
               disease.DiseasesInvestigationId = _disease.DiseasesInvestigationId;
               editIndex = _diseasesRepository.Edit(disease);

           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int DeleteDiseases(int diseasesId)
       {
           int deleteIndex = 0;
           try
           {
               Disease disease = GetDeasesById(diseasesId);
               disease.IsActive = false;
               deleteIndex = _diseasesRepository.Edit(disease);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return deleteIndex;
       }

       public List<Disease> GetAllDiseases()
       {
           List<Disease> diseaseslList;
           try
           {
               diseaseslList = _diseasesRepository.Filter(x => x.IsActive == true).ToList();
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return diseaseslList;
       }
   }
}
