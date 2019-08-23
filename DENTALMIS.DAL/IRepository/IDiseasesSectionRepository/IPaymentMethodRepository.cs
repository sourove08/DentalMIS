using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IPaymentMethodRepository:IRepository<PaymentMethod>
   {
       List<PaymentMethod> GetAllPaymentbyPaging(out int totalrecords, PaymentMethod model);
   }
}
