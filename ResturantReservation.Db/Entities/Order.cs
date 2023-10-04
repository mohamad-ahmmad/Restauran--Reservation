
namespace ResturantReservation.Db.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }
        public List<OrderItem> OrderItems { set; get; } 

        public int ReservationId { get; set; }  
        public Reservation Reservation { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
