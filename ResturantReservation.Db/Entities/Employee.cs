using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Entities
{
    public class Employee
    {
        public Employee() 
        {
            Orders = new List<Order>();
        }   
        public int EmployeeId { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public List<Order> Orders { get; set; }
    }
}
