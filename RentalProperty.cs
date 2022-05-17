using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisCurran_S00210475_Final_Exam
{
    public class RentalProperty
    {
        public enum RentalType { Flat, House, Share }
        public int ID { get; set; }
        public string TypeOfRental { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public void RentIncrease(decimal pcIncrease)
        {
            Price = Price + (Price * pcIncrease/100);
        }
        public override string ToString()
        {
            return Location + " €" + Price;
        }
        public class PropertyDetails : DbContext
        {
            public PropertyDetails() : base("MyPropertyDetails") { }
            public DbSet<RentalProperty> Properties { get; set; }
        }
    }
}
