using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IReportManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IReportRepository;
using DENTALMIS.DAL.Repository.ReportRepository;
using DENTALMIS.Model;
using DENTALMIS.Model.Custom;

namespace DENTALMIS.BLL.Manager.ReportManager
{
  public  class ReportManager :Manager,IReportManager
    {
      private readonly IReportRepository _reportRepository;

      public ReportManager(DENTALERPDbContext context)
      {
          _reportRepository=new ReportRepository(context);
      }

      //public List<PaymentMethod> GetPatientBill(PaymentMethod model)
      //{
      //    List<PaymentMethod> paymentMethods;

      //    try
      //    {
      //        paymentMethods = Instance.Context.Database.SqlQuery<PaymentMethod>("GetPatientBill @PatientCode, @FromDate, @ToDate", new SqlParameter("PatientCode", model.Patient.PatientCode), new SqlParameter("FromDate", model.Date.GetValueOrDefault()), new SqlParameter("ToDate", model.PeriodEndDate.GetValueOrDefault())).ToList();
      //    }

      //    catch (Exception exception)
      //    {
      //        throw new Exception(exception.Message);
      //    }
      //    return paymentMethods;
      //}
      public List<PaymentView> GetPatientBill(object[] objs)
      {
           return _reportRepository.GetPatientBill(objs);
        }
      }
    }

