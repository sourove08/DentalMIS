using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IReportRepository;
using DENTALMIS.Model.Custom;

namespace DENTALMIS.DAL.Repository.ReportRepository
{
   public class ReportRepository:IReportRepository
    {
        public DENTALERPDbContext Context { get; set; }
        public ReportRepository(DENTALERPDbContext context)
        {
            Context = context;
        }

       public List<PaymentView> GetPatientBill(object[] objs)
       {
           return Context.Database.SqlQuery<PaymentView>("GetPatientBill @PatientCode, @FromDate, @ToDate", objs[0], objs[1], objs[2]).ToList();
       }
    }
}
