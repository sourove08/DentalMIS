using System;
using System.Collections.Generic;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
   public class PaymentMethodManager:IPaymentMethodManager
   {
       private IPaymentMethodRepository _paymentMethodRepository = null;

       public PaymentMethodManager(DENTALERPDbContext context)
       {
           _paymentMethodRepository=new PaymentMethodRepository(context);
       }

       public List<PaymentMethod> GetAllPaymentbyPaging(out int totalrecords, PaymentMethod model)
       {
           List<PaymentMethod> paymentMethods;


           try
           {
               paymentMethods = _paymentMethodRepository.GetAllPaymentbyPaging(out totalrecords, model);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return paymentMethods;
       }

       public PaymentMethod GetPaymentbyId(int id)
       {
           PaymentMethod payment;

           try
           {
               payment = _paymentMethodRepository.FindOne(x => x.PaymentMethodId == id && x.IsActive == true);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return payment;
       }

       public int Save(PaymentMethod paymentMethod)
       {
           int saveIndex = 0;
           try
           {
             
               paymentMethod.IsActive = true;
               paymentMethod.CreatedDate = DateTime.Now;


               saveIndex = _paymentMethodRepository.Save(paymentMethod);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return saveIndex;

       }

       public int Edit(PaymentMethod paymentMethod)
       {
           int editIndex = 0;

           try
           {
               PaymentMethod _paymentMethod = GetPaymentbyId(paymentMethod.PaymentMethodId);
               _paymentMethod.PatientId = paymentMethod.PatientId;
               _paymentMethod.PaymentMethodId = paymentMethod.PaymentMethodId;
               _paymentMethod.ServiceId = paymentMethod.ServiceId;
               _paymentMethod.Date = paymentMethod.Date;
               _paymentMethod.Charge = paymentMethod.Charge;
               _paymentMethod.DiscountAmount = paymentMethod.DiscountAmount;
               _paymentMethod.Paid += paymentMethod.Paid;
               _paymentMethod.TotalCharge = paymentMethod.Charge - paymentMethod.DiscountAmount;

               _paymentMethod.Due = _paymentMethod.TotalCharge - _paymentMethod.Paid;
               _paymentMethod.PaymentType = paymentMethod.PaymentType;
           
              
               _paymentMethod.LastPaidDate = DateTime.Now;
               editIndex = _paymentMethodRepository.Edit(_paymentMethod);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int Delete(int id)
       {
           int deleteIndex = 0;
         

           try
           {
               PaymentMethod paymentMethod = GetPaymentbyId(id);
               paymentMethod.IsActive = false;

               deleteIndex = _paymentMethodRepository.Edit(paymentMethod);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return deleteIndex;
       }
   }
}
