using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.ITodayStatusManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.ITodaysStatussectionRepository;
using DENTALMIS.DAL.Repository.TodayStatusrepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.TodaystatusManager
{
    public class TodayStatusManager : ITodayStatusManager
    {
        private ITodayStatusRepository _todayStatusRepository = null;

        public TodayStatusManager(DENTALERPDbContext context)
        {
            _todayStatusRepository = new TodayStatusRepository(context);
        }

        public List<TodaysPatientstatu> GetAllStatusByPaging(out int totalrecord, TodaysPatientstatu model)
        {
            List<TodaysPatientstatu> todaysPatientstatus;


            try
            {
                todaysPatientstatus = _todayStatusRepository.GetAllStatusByPaging(out totalrecord, model);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return todaysPatientstatus;
        }

        public TodaysPatientstatu GetStatusById(int id)
        {
            TodaysPatientstatu todaysPatientstatus;
            try
            {
                todaysPatientstatus = _todayStatusRepository.FindOne(x => x.Id == id && x.IsActive == true);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

            return todaysPatientstatus;
        }

        public int Save(TodaysPatientstatu todaysPatientstatu)
        {
            int saveIndex = 0;
            try
            {
              
                todaysPatientstatu.IsActive = true;
                saveIndex = _todayStatusRepository.Save(todaysPatientstatu);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return saveIndex;
        }

        public int Edit(TodaysPatientstatu todaysPatientstatu)
        {
            int editIndex = 0;

            try
            {
                TodaysPatientstatu _todaysPatientstatu = GetStatusById(todaysPatientstatu.Id);
               _todaysPatientstatu.Id= todaysPatientstatu.Id;
               _todaysPatientstatu.PatientName= todaysPatientstatu.PatientName ;
               _todaysPatientstatu.PatientStatus= todaysPatientstatu.PatientStatus;
               _todaysPatientstatu.SerialNo= todaysPatientstatu.SerialNo;
               _todaysPatientstatu.VisitingDate= todaysPatientstatu.VisitingDate ;
               _todaysPatientstatu.visitingtime= todaysPatientstatu.visitingtime;
               _todaysPatientstatu.contact= todaysPatientstatu.contact;
               _todaysPatientstatu.VisitingPurpose= todaysPatientstatu.VisitingPurpose;

                editIndex = _todayStatusRepository.Edit(_todaysPatientstatu);
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
                TodaysPatientstatu todaysPatientstatu = GetStatusById(id);

                todaysPatientstatu.IsActive = false;
                deleteIndex = _todayStatusRepository.Delete(todaysPatientstatu);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

            return deleteIndex;

        }
    }
}
