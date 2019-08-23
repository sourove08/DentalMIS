using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ClinicDescriptionModel
{
    public class ClinicAccessoryViewModel :ClinicalAccessory
    {

        public List<ClinicalAccessory> ClinicalAccessories { get; set; }

        public string SearchbyName { get; set; }

        public ClinicAccessoryViewModel()
        {
            ClinicalAccessories=new List<ClinicalAccessory>();
        }
    }
}