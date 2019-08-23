using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDrugSectionRepository
{
   public interface IDrugGenericRepository :IRepository<DrugGeneric>
   {
       //List<DrugGeneric> GetAllGenericDrug(int startPage, int _pageSize, out int totalRecords, DrugGeneric model);
       List<DrugGeneric> GetAllGenericDrug( out int totalRecords, DrugGeneric model);
   }
}
