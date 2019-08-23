using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDrugSectionManager
{
    public interface IDrugDetailManager
    {
        List<DrugDetail> GetAllDrugDetails(out int totalrecords,DrugDetail  model);

        DrugDetail GetDrugDeatilsbyId(int drugDetailId);

        int SaveDrugDetail(DrugDetail _drugDetails);

        int EditDrugdetail(DrugDetail _drugDetails);

        int DeletedrugDetail(int detailid);
    }
}
