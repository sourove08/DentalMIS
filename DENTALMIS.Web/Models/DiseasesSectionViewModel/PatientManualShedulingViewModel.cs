using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class PatientManualShedulingViewModel :PatientShedule
    {

        public List<PatientShedule> PatientShedules { get; set; }


        public PatientManualShedulingViewModel()
        {
            
            PatientShedules=new List<PatientShedule>();
        }



    }
}