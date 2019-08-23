using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IDiseasesInvestigationRepository:IRepository<DiseasesInvestigation>
   {
       List<DiseasesInvestigation> GettAllInvestigationbyPaging(out int totalrecords, DiseasesInvestigation model);
   }
}
