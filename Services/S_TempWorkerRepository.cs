using EksamenFinish.DAL;
using EksamenFinish.Models;
using System.Collections.Generic;

namespace EksamenFinish.Services
{
    public class S_TempWorkerRepository
    {
        #region Fields

        private DAL_TempWorkerRepository _dal;

        private  List<M_TempWorker> m_tempWorkers;

        #endregion Fields

        public S_TempWorkerRepository()
        {
            m_tempWorkers = new List<M_TempWorker>();
            _dal = new DAL_TempWorkerRepository();
        }

        #region CreateTempWorker

        public void CreateTempWorker(M_TempWorker tempWorker)
        {
            _dal.CreateTempWorker(tempWorker);
        }

        #endregion CreateTempWorker

        #region SearchTempWorkers

        public List<M_TempWorker> SearchWorkers(M_TempWorker tempWorker)
        {
            var TempWorkers = _dal.SearchTempWorkers(tempWorker);

            return TempWorkers;
        }

        #endregion SearchTempWorkers

        #region UpdateTempWorker
        public void UpdateTempWorker(M_TempWorker tempWorker)
        {
            _dal.UpdateWorker(tempWorker);
        }

        #endregion UpdateTempWorker
    }
}