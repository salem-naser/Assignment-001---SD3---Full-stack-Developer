using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Domain
{
    public class User:BaseEntity
    {
        public string FirstName{ get; set; }
        public string MiddleName { get; set; }
        public string LasTName { get; set; }
        public DateTime BirthDate{ get; set; }
        public  string MoblieNumber{ get; set; }
        public string Email { get; set; }
        public virtual Adress Adress { get; set; }
                
    }
}
