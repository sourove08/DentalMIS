using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
    public interface IDiseasesRepository : IRepository<Disease>
    {
        List<Disease> GettAllDiseasesPaging(out int totalrecords, Disease model);
    }
}
