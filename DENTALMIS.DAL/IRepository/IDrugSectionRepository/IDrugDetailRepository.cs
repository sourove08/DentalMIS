using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDrugSectionRepository
{
    public interface IDrugDetailRepository : IRepository<DrugDetail>
    {
        List<DrugDetail> GetAlldrugDetails(out int totalrecords, DrugDetail model);
    }
}
