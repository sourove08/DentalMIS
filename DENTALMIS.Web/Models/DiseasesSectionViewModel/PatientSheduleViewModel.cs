using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class PatientSheduleViewModel:PatientShedule
    {


        public List<PatientShedule> PatientShedules { get; set; }


        public PatientSheduleViewModel()
        {
            PatientShedules=new List<PatientShedule>();
        }
    }
}