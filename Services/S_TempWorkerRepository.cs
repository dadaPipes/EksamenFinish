using EksamenFinish.DAL;
using EksamenFinish.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EksamenFinish.Services
{
    // Responsible for interacting with the DAL_TempWorkerRepository class for data access and CRUD operations on TempWorker data.

    public class S_TempWorkerRepository
    {
        #region Fields

        private DAL_TempWorkerRepository _dal;
        private DTO_TempWorker dto_tempWorker;

        private S_TempWorkerMapper s_tempWorkerMapper;

        #endregion Fields

        public S_TempWorkerRepository()
        {
            _dal = new DAL_TempWorkerRepository();
            s_tempWorkerMapper = new S_TempWorkerMapper();
        }

        #region SearchTempWorkers

        public List<VM_TempWorker> SearchTempWorkers(VM_TempWorker vm_tempWorker)
        {
            dto_tempWorker = s_tempWorkerMapper.MapViewModelToDto(vm_tempWorker);

            // Search for temp workers using the dto_tempWorker
            List<DTO_TempWorker> dto_tempWorkers = _dal.SearchTempWorkers(dto_tempWorker);

            // Map the dto_tempWorkers to a list of vm_tempWorkers
            List<VM_TempWorker> vm_tempWorkers = s_tempWorkerMapper.MapDtoListToViewModelList(dto_tempWorkers);

            return vm_tempWorkers;
        }


        #endregion SearchTempWorkers

        #region CreateTempWorker

        /// <summary>
        /// Takes an object of type DTO_TempWorker as an input and creates a new TempWorker record in the database
        /// using the _dal object's CreateTempWorker method.
        /// </summary>

        public void CreateTempWorker(VM_TempWorker vm_tempWorker)
        {
            // Map the TempWorkerViewModel properties to the tempWorkerDTO object
            dto_tempWorker = s_tempWorkerMapper.MapViewModelToDto(vm_tempWorker);

            _dal.CreateTempWorker(dto_tempWorker);
        }

        #endregion CreateTempWorker

        #region UpdateTempWorker

        /// <summary>
        /// Takes an object of type DTO_TempWorker as an input and
        /// updates an existing TempWorker record in the database using the _dal object's UpdateWorker method.
        /// </summary>

        public void UpdateTempWorker(VM_TempWorker vm_tempWorker)
        {
            // Map the TempWorkerViewModel properties to the tempWorkerDTO object
            dto_tempWorker = s_tempWorkerMapper.MapViewModelToDto(vm_tempWorker);

            _dal.UpdateWorker(dto_tempWorker);
        }

        #endregion UpdateTempWorker

        #region DeleteTempWorker

        /// <summary>
        /// Takes the id of a TempWorker as an input and deletes the corresponding worker record from the database
        /// using the _dal object's DeleteTempWorker method.
        /// </summary>

        public void DeleteTempWorker(Guid id)
        {
            _dal.DeleteTempWorker(id);
        }

        #endregion DeleteTempWorker
    }
}