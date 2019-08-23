using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ServiceSectionViewModel
{
    public class ServiceViewModel:Service
    {
        public List<Service> Services { get; set; }


        public ServiceViewModel()
        {
          Services=new List<Service>();  
        }
    }
}