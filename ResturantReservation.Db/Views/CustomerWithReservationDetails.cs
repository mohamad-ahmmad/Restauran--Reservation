using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Views
{
    public class CustomerWithReservationDetails
    {
        public int CustomerId {set; get;}
        public string Email { set; get;}
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }
        public string RestaurantName { set; get; }
        public string RestaurantAddress { set; get; }
        public string RestaurantPhoneNumber { set; get; }
        public string OpeningHours { set; get; }
        public int TableId { set; get; }
        public int PartySize { set; get; }
        public DateTime ReservationDate { set; get; }


    }
}
