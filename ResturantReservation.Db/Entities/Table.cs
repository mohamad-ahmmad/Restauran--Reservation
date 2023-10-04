using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public List<Reservation> Reservation { get; set; }
        public int Capacity { get; set; }
    }
}
