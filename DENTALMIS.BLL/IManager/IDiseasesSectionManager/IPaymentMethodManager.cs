using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
  public  interface IPaymentMethodManager
    {
        List<PaymentMethod> GetAllPaymentbyPaging(out int totalrecords,PaymentMethod model);

        PaymentMethod GetPaymentbyId(int id);

        int Save(PaymentMethod paymentMethod);

        int Edit(PaymentMethod paymentMethod);

        int Delete(int id);
    }
}
