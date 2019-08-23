using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDrugSectionRepository
{
    public interface IDrugBrandRepository : IRepository<DrugBrand>
    {
        //List<DrugBrand> GetAllDrugBrand(int startPage, int _pageSize, out int totalrecords, DrugBrand model);
        List<DrugBrand> GetAllDrugBrand(out int totalrecords, DrugBrand model);

        //List<DrugBrand> GetAllDrugBrandByGeneric(int genericId);
    }
}
