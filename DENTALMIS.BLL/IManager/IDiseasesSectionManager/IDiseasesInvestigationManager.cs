using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
   public interface IDiseasesInvestigationManager
    {
        List<DiseasesInvestigation> GetAllInvestigationByPaging(out int totalrecords, DiseasesInvestigation model);

        DiseasesInvestigation GetInvestigationById(int diseasesInvestigationId);

        int Save(DiseasesInvestigation _dInv);

        int Edit(DiseasesInvestigation _dInv);

        int Delete(int disesesInvestigationId);



        List<DiseasesInvestigation> GetAllInvestigation();
    }
}
