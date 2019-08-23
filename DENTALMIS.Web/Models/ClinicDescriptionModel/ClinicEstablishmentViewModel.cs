using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ClinicDescriptionModel
{
    public class ClinicEstablishmentViewModel : ClinicEstablishment
    {

        public List<ClinicEstablishment> ClinicEstablishments { get; set; }


        public ClinicEstablishmentViewModel()
        {
        
            ClinicEstablishments=new List<ClinicEstablishment>();
            
        }
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
    }
}