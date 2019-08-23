using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class DiseasesClinicalFeatureViewModel:DisesesClinicalFeature
    {
        public DiseasesClinicalFeatureViewModel()
        {
            DisesesClinicalFeatures=new List<DisesesClinicalFeature>();
        }

        public List<DisesesClinicalFeature> DisesesClinicalFeatures { get; set; }

        public string SearchBySymptom { get; set; }
        public string SearchBySign { get; set; }




    }
}