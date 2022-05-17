using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisCurran_S00210475_Final_Exam
{
    class RentalProperty
    {
        public int ID { get; set; }
        public Enum RentalType { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public void RentIncrease(decimal pcIncrease)
        {
            Price = Price + (Price * pcIncrease/100);
        }
    }
}
