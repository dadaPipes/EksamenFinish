using EksamenFinish.ViewModels;
using System.Collections.Generic;

namespace EksamenFinish.Services
{
    // Service class that maps between the DTO_TempWorker data transfer object and the VM_TempWorker view model.
    // S_TempWorkerMapper class is responsible for converting data between the data layer and the presentation layer,
    // which is a necessary task in order to properly separate the concerns of each layer (!)

    public class S_TempWorkerMapper
    {
        
        #region Map DTO to ViewModel

        /// <summary>
        /// Takes a DTO_TempWorker object as its input and returns a new VM_TempWorker object
        /// that is populated with the properties from the input DTO_TempWorker.
        /// This method is used to convert data from the data layer to the presentation layer.
        /// </summary>

        public VM_TempWorker MapDtoToViewModel(DTO_TempWorker dto)
        {
            return new VM_TempWorker()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                City = dto.City,
                ZipCode = dto.ZipCode,
                PersonalNumber = dto.PersonalNumber,
                IsActive = dto.IsActive
            };
        }

        #endregion

        #region Map ViewModel to DTO

        /// <summary>
        /// Takes a VM_TempWorker object as its input and returns a new DTO_TempWorker object
        /// that is populated with the properties from the input VM_TempWorker.
        /// This method is used to convert data from the presentation layer to the data layer.
        /// </summary>

        public DTO_TempWorker MapViewModelToDto(VM_TempWorker vm)
        {
            return new DTO_TempWorker
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Address = vm.Address,
                City = vm.City,
                ZipCode = vm.ZipCode,
                PersonalNumber = vm.PersonalNumber,
                IsActive = vm.IsActive
            };
        }


        // Maps a list of DTOs to a list of VMs
        public List<VM_TempWorker> MapDtoListToViewModelList(List<DTO_TempWorker> dtoList)
        {
            var vmList = new List<VM_TempWorker>();
            foreach (var dto in dtoList)
            {
                var vm = MapDtoToViewModel(dto);
                vmList.Add(vm);
            }
            return vmList;
        }

        // Maps a list of VMs to a list of DTOs
        public List<DTO_TempWorker> MapViewModelListToDtoList(List<VM_TempWorker> vmList)
        {
            var dtoList = new List<DTO_TempWorker>();
            foreach (var vm in vmList)
            {
                var dto = MapViewModelToDto(vm);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        #endregion
    }


}