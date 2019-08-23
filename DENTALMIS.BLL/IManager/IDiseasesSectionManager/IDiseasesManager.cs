using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
  public  interface IDiseasesManager
    {

        List<Disease> GetAllDiseasesByPaging(out int totalrecords,Disease model);

        Disease GetDeasesById(int diseasesId);

        int Save(Disease _disease);

        int Edit(Disease _disease);

        int DeleteDiseases(int diseasesId);

        List<Disease> GetAllDiseases();
    }
}
