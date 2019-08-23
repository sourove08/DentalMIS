using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
  public  interface IDiseasesManagementManager
    {
        List<DiseasesManagement> GetAllManagementByPaging(out int totalrecords, DiseasesManagement model);



        DiseasesManagement GetDeasesManagementById(int diseasesManagementId);

        int Save(DiseasesManagement _diseaseManagement);

        int Edit(DiseasesManagement _diseaseManagement);

        int Delete(int diseasesManagementId);
    }
}
