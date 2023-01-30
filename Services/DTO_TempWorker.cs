using System;

namespace EksamenFinish.Services
{
    // In the constructor, the class initializes all properties to default values this way.
    // This will avoid null references and crashing the program.
    // Ensuring that the object will always have a valid state and can be used without null reference exceptions.

    // Data transfer object (DTO) that holds data about a temporary worker.
    // Responsibility of this class is to hold the data in a structured way and allow easy data transfer between different layers of the application.

    public class DTO_TempWorker
    {
        //public DTO_TempWorker()
        //{
        //    Id = Guid.Empty;
        //    FirstName = "";
        //    LastName = "";
        //    Address = "";
        //    City = "";
        //    ZipCode = 0;
        //    PersonalNumber = "";
        //    IsActive = false;
        //}

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string PersonalNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
