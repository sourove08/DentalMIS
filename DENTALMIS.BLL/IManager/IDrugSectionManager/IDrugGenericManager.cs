using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDrugSectionManager
{
   public interface IDrugGenericManager
    {
        //List<DrugGeneric> GetAllGenericDrug(int startPage, int _pageSize, out int totalRecords,DrugGeneric model);
       List<DrugGeneric> GetAllGenericDrug( out int totalRecords, DrugGeneric model);


        DrugGeneric GetGenericDrugById(int genericId);

        int SaveDrugGeneric(DrugGeneric _drugGeneric);

        int EditDrugGenerIc(DrugGeneric _drugGeneric);

        int DeleteDrugGeneric(int genericId);



        List<DrugGeneric> GettAllGenericDrug();

        
    }
}
