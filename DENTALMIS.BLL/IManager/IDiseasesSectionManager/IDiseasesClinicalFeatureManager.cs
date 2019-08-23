using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
   public interface IDiseasesClinicalFeatureManager
    {
        List<DisesesClinicalFeature> GetAllFeatureByPaging(out int totalrecords, DisesesClinicalFeature model);

        DisesesClinicalFeature GetFeatureById(int clinicalFeatureId);

        int Save(DisesesClinicalFeature _disesesClinicalFeature);

        int Edit(DisesesClinicalFeature _disesesClinicalFeature);

        int Delete(int clinicalfeatureId);

        List<DisesesClinicalFeature> GetAllFeature();
    }
}
