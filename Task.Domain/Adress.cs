using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Domain
{
    public class Adress:BaseEntity
    {
        public int Governrate{ get; set; }
        public int City { get; set; }
        public string Street{ get; set; }
        public int BuildingNumber{ get; set; }
        public int FlatNumber { get; set; }
        public virtual User User { get; set; }

    }

}
