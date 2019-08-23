using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IGenderRepository:IRepository<Gender>
   {
       List<Gender> GetAllGender(out int totalrecords, Gender model);
   }
}
