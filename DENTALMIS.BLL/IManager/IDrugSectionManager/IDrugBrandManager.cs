using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDrugSectionManager
{
  public  interface IDrugBrandManager
    {
      
      List<DrugBrand> GetAllDrugBrand(out int totalrecords, DrugBrand model);

        //List<DrugBrand> GetAllDrugBrandByGeneric(int genericId);

        DrugBrand GetBrandDrugById(int brandId);

        int SaveDrugBrand(DrugBrand _drugBrand);

        int EditDrugBrand(DrugBrand _drugBrand);

        int DeleteDrugBrand(int brandId);

        List<DrugBrand> GetdrugBySearchKey(string SearchKey);

        List<DrugBrand> Getdrugs();
    }
}
