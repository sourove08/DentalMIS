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
  public  class RowMeterialManager :IRowMeterialManager
  {

      private IRrowMeterialRepository _rrowMeterialRepository = null;


      public RowMeterialManager(DENTALERPDbContext context)
      {
          _rrowMeterialRepository=new RowMeterialRpository(context);
      }

      public List<RowMatrial> GetAllRowMeterial(out int totalrecords, RowMatrial model)
      {
          List<RowMatrial> meteriaList;
          try
          {
              meteriaList = _rrowMeterialRepository.GetAllRowMeterial(out totalrecords, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }

          return meteriaList;
      }

      public RowMatrial GetRowMeterialById(int id)
      {

          RowMatrial matrial;
          try
          {
              matrial = _rrowMeterialRepository.FindOne(x => x.RowMaterialId == id && x.IsActive == true);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return matrial;
      }

      public int Save(RowMatrial mt)
      {
          int saveIndex = 0;

          try
          {
              mt.IsActive = true;
              saveIndex = _rrowMeterialRepository.Save(mt);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(RowMatrial mt)
      {
          int editIndex = 0;
          try
          {
              RowMatrial _rowMatrial = GetRowMeterialById(mt.RowMaterialId);
              _rowMatrial.RowMaterialId = mt.RowMaterialId;
              _rowMatrial.Name = mt.Name;
              _rowMatrial.Cost = mt.Cost;
              _rowMatrial.ManufacturingDate = mt.ManufacturingDate;
              _rowMatrial.ExpireDate = mt.ExpireDate;
              _rowMatrial.Amount = mt.Amount;
              editIndex = _rrowMeterialRepository.Edit(_rowMatrial);
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
              RowMatrial mt = GetRowMeterialById(id);

              mt.IsActive = false;

              deleteIndex = _rrowMeterialRepository.Edit(mt);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }
  }
}
