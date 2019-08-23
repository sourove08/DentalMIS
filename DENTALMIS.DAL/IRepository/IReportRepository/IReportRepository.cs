using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENTALMIS.DAL.IRepository.IReportRepository
{
  public  interface IReportRepository
    {
        List<Model.Custom.PaymentView> GetPatientBill(object[] objs);
    }
}
