using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;
//using DENTALMIS.Web.Models.ReportViewModel;
using DENTALMIS.Model.Custom;

namespace DENTALMIS.BLL.IManager.IReportManager
{
 public   interface IReportManager
    {
     //List<PaymentMethod> GetPatientBill(PaymentMethod model);



        List<PaymentView> GetPatientBill(object[] objs);
    }
}
