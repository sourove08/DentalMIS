using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ClinicDescriptionModel
{
    public class ClinicAcountViewModel:ClinicAccount
    {

        public List<ClinicAccount> ClinicAccounts { get; set; }


        public ClinicAcountViewModel()
        {
            ClinicAccounts=new List<ClinicAccount>();
        }

        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
    }
}