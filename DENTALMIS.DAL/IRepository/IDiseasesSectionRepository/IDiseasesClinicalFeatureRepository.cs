using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
    public interface IDiseasesClinicalFeatureRepository : IRepository<DisesesClinicalFeature>
    {
        List<DisesesClinicalFeature> GetAllFeatureByPaging(out int totalrecords, DisesesClinicalFeature model);
    }
}
