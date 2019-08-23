using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class TodayPatientStatusViewModel:TodaysPatientstatu
    {
        public List<TodaysPatientstatu> TodaysPatientstatus { get; set; }


        public TodayPatientStatusViewModel()
        {
            TodaysPatientstatus = new List<TodaysPatientstatu>();
            Values=new List<string>();
            
        }

        public string SearchByName { get; set; }
        [Required]
        public string InTime { get; set; }

        public List<string> Values { get; set; }

    }
}