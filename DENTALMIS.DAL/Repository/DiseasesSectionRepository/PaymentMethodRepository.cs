using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
    public class PaymentMethodRepository:Repository<PaymentMethod>,IPaymentMethodRepository
    {
        public PaymentMethodRepository(DENTALERPDbContext context) : base(context)
        {
        }

        public List<PaymentMethod> GetAllPaymentbyPaging(out int totalrecords, PaymentMethod model)
        {
            int pageindex = model.PageIndex;

            int pageSize = AppConfig.PageSize;

            var paymentMethods =
                Context.PaymentMethods.Include(x => x.Patient)
                    .Include(x => x.Service)
                    .Where(x =>x.IsActive == true &&
                                (x.PatientId == model.PatientId || model.PatientId == 0) && (x.ServiceId == model.ServiceId || model.ServiceId == 0));

            totalrecords = paymentMethods.Count();

            switch (model.Sort)
            {
                case "PatientId":

                    switch (model.SortDir)
                    {
                        case "DESC":
                            paymentMethods = paymentMethods.OrderByDescending(x => x.PatientId)
                                    .Skip(pageSize * pageindex)
                                    .Take(pageSize);
                            break;
                        default:
                            paymentMethods = paymentMethods.OrderBy(x => x.PatientId)
                                 .Skip(pageSize * pageindex)
                                 .Take(pageSize);
                            break;
                    }
                    break;
                case "ServiceId":

                    switch (model.SortDir)
                    {
                        case "DESC":
                            paymentMethods = paymentMethods.OrderByDescending(x => x.ServiceId)
                                    .Skip(pageSize * pageindex)
                                    .Take(pageSize);
                            break;
                        default:
                            paymentMethods = paymentMethods.OrderBy(x => x.ServiceId)
                                 .Skip(pageSize * pageindex)
                                 .Take(pageSize);
                            break;
                    }
                    break;
                case "TotalCharge":

                    switch (model.SortDir)
                    {
                        case "DESC":
                            paymentMethods = paymentMethods.OrderByDescending(x => x.TotalCharge)
                                    .Skip(pageSize * pageindex)
                                    .Take(pageSize);
                            break;
                        default:
                            paymentMethods = paymentMethods.OrderBy(x => x.TotalCharge)
                                 .Skip(pageSize * pageindex)
                                 .Take(pageSize);
                            break;
                    }
                    break;
                default:
                    paymentMethods = paymentMethods.OrderBy(x => x.PatientId)
                         .Skip(pageSize * pageindex)
                         .Take(pageSize);
                    break;
            }

            return paymentMethods.ToList();
        }
    }
}
