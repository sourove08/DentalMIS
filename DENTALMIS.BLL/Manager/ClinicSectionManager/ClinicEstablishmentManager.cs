using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IClinicSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IClinicSectionRepository;
using DENTALMIS.DAL.Repository.ClinicSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.ClinicSectionManager
{
 public   class ClinicEstablishmentManager :IClinicEstablishmentManager
 {

     private ICliniEstablismentRepository _cliniEstablismentRepository = null;


     public ClinicEstablishmentManager(DENTALERPDbContext context)
     {
         _cliniEstablismentRepository=new ClinicEsatblismentRepository(context);
     }

     public List<ClinicEstablishment> GetAllAByPaging(out int totalrecords, ClinicEstablishment model)
     {
         List<ClinicEstablishment> clinicEstablishments;
         try
         {
             clinicEstablishments = _cliniEstablismentRepository.GetAllAByPaging(out totalrecords, model);
         }
         catch (Exception exception)
         {

             throw new Exception(exception.Message);
         }

         return clinicEstablishments;
     }

     public ClinicEstablishment GetById(int id)
     {
         ClinicEstablishment clinicEstablishment;

         try
         {
             clinicEstablishment =
                 _cliniEstablismentRepository.FindOne(x => x.EstablishmentId == id && x.IsActive == true);
         }
         catch (Exception exception)
         {
             
             throw new Exception(exception.Message);
         }
         return clinicEstablishment;
     }

     public int Save(ClinicEstablishment clesEstablishment)
     {
         int saveIndex = 0;
         try
         {
             clesEstablishment.IsActive = true;
             saveIndex = _cliniEstablismentRepository.Save(clesEstablishment);
         }
         catch (Exception exception)
         {

             throw new Exception(exception.Message);
         }
         return saveIndex;
     }

     public int Edit(ClinicEstablishment clesEstablishment)
     {
         int editIndex = 0;
         try
         {
             ClinicEstablishment _cl = GetById(clesEstablishment.EstablishmentId);
             _cl.EstablishmentId = clesEstablishment.EstablishmentId;
             _cl.ClinicHouseCharge = clesEstablishment.ClinicHouseCharge;
             _cl.ElectricityBill = clesEstablishment.ElectricityBill;
             _cl.EmployeeCost = clesEstablishment.EmployeeCost;
             _cl.InstrumentServiceCost = clesEstablishment.InstrumentServiceCost;
             _cl.RowmaterialCost = clesEstablishment.RowmaterialCost;
             _cl.Vat = clesEstablishment.Vat;
             _cl.Date = clesEstablishment.Date;

             _cl.TotalCharge = _cl.ClinicHouseCharge + _cl.ElectricityBill + _cl.EmployeeCost +
                               _cl.InstrumentServiceCost + _cl.RowmaterialCost + _cl.Vat;

             editIndex = _cliniEstablismentRepository.Edit(_cl);
         }
         catch (Exception exception)
         {

             throw new Exception(exception.Message);
         }
         return editIndex;
     }

     public int Delete(int id)
     {
         int deletIndex = 0;
         try
         {
             ClinicEstablishment cles = GetById(id);
             cles.IsActive = false;
             deletIndex = _cliniEstablismentRepository.Edit(cles);
         }
         catch (Exception exception)
         {
             
             throw new Exception(exception.Message);
         }

         return deletIndex;
     }

   
     
 }
}
