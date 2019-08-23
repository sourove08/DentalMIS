using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
    public interface IDiseasesManagementRepository : IRepository<DiseasesManagement>
    {
        List<DiseasesManagement> GetAllManagementByPaging(out int totalrecords, DiseasesManagement model);
    }
}
