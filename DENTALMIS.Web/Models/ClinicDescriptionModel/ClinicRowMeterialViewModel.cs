using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ClinicDescriptionModel
{
    public class ClinicRowMeterialViewModel :RowMatrial
    {
        public List<RowMatrial> RowMatrials { get; set; }


        public string SearchbyNamesd { get; set; }


        public ClinicRowMeterialViewModel()
        {
            RowMatrials=new List<RowMatrial>();
        }
    }
}