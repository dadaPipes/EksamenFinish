using System;

namespace EksamenFinish.Models
{
    public class M_TempWorker
    {
        public Guid Id               { get; set; }
        public string FirstName      { get; set; }
        public string LastName       { get; set; }
        public string Address        { get; set; }
        public string City           { get; set; }
        public int ZipCode           { get; set; }
        public string PersonalNumber { get; set; }
        public bool IsActive         { get; set; }
    }
}