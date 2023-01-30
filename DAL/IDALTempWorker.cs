using EksamenFinish.Services;
using System;
using System.Collections.Generic;

namespace EksamenFinish.DAL
{
    public interface IDAL_TempWorker
    {
        void CreateTempWorker(DTO_TempWorker dto_tempWorker);

        List<DTO_TempWorker> SearchTempWorkers(DTO_TempWorker dto_tempWorker);

        void UpdateWorker(DTO_TempWorker dto_tempWorker);

        void DeleteTempWorker(Guid id);
    }
}