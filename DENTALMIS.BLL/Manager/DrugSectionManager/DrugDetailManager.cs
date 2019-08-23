using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IDrugSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDrugSectionRepository;
using DENTALMIS.DAL.Repository.DrugSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DrugSectionManager
{
    public class DrugDetailManager : IDrugDetailManager
    {
        private IDrugDetailRepository _drugDetailRepository = null;

        public DrugDetailManager(DENTALERPDbContext context)
        {
            _drugDetailRepository = new DrugDetailRepository(context);
        }

        public List<DrugDetail> GetAllDrugDetails(out int totalrecords, DrugDetail model)
        {
            List<DrugDetail> drugDetails;
            try
            {
                drugDetails = _drugDetailRepository.GetAlldrugDetails(out totalrecords, model);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return drugDetails;
        }

        public DrugDetail GetDrugDeatilsbyId(int drugDetailId)
        {
            var drugDetail = new DrugDetail();

            try
            {
                drugDetail = _drugDetailRepository.FindOne(x => x.DrugDetailId == drugDetailId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return drugDetail;
        }

        public int SaveDrugDetail(DrugDetail _drugDetails)
        {
            int saveIndex = 0;
            try
            {
                _drugDetails.IsActive = true;
                saveIndex = _drugDetailRepository.Save(_drugDetails);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return saveIndex;

        }

        public int EditDrugdetail(DrugDetail _drugDetails)
        {
            int editIndex = 0;
            try
            {
                DrugDetail drugDetail = GetDrugDeatilsbyId(_drugDetails.DrugDetailId);
                 drugDetail.DrugDetailId=_drugDetails.DrugDetailId;
                drugDetail.Indication = _drugDetails.Indication;
               drugDetail.Dosage= _drugDetails.Dosage;

               drugDetail.Contraindication= _drugDetails.Contraindication;
                 drugDetail.SideEffect=_drugDetails.SideEffect;
                drugDetail.UseInPregnency=_drugDetails.UseInPregnency ;
               drugDetail.UseInLactation= _drugDetails.UseInLactation;
                drugDetail.DrugInteraction=_drugDetails.DrugInteraction;
               drugDetail.Precaution= _drugDetails.Precaution;
               drugDetail.Mechanism= _drugDetails.Mechanism ;
                drugDetail.GenericId=_drugDetails.GenericId ;

                editIndex = _drugDetailRepository.Edit(drugDetail);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return editIndex;
        }

        public int DeletedrugDetail(int detailid)
        {
            int deleteIndex = 0;
            try
            {
                var drugDetail = GetDrugDeatilsbyId(detailid);
                drugDetail.IsActive = false;
                deleteIndex = _drugDetailRepository.Edit(drugDetail);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex;

        }
    }
}
