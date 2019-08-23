using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ClinicDescriptionModel
{
    public class ClinicInstrumentViewModel : ClinicalInstrument
    
    {
        public List<ClinicalInstrument> ClinicalInstruments { get; set; }


        public ClinicInstrumentViewModel()
        {
            ClinicalInstruments=new List<ClinicalInstrument>();
        }

        public string SearchbyName { get; set; }
    }
}