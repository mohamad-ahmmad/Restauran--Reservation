using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class functions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE FUNCTION fn_RestaurantTotalRevenue(@RestaurantId INT)
                                    RETURNS DECIMAL(19,4)
                                    AS
                                    BEGIN
                                    DECLARE @TotalRevenue DECIMAL(19,4);

                                    WITH OrderItemTotalPrice AS
                                    (
                                    SELECT oi.Quantity * m.Price as TotalPrice
                                    FROM Reservations as r
                                    INNER JOIN Orders as o 
                                    ON r.ReservationId = o.ReservationId
                                    INNER JOIN OrderItems as oi 
                                    ON o.OrderId = oi.OrderId
                                    INNER JOIN MenuItems as m 
                                    ON oi.MenuItemId = m.ItemId
                                    Where r.RestaurantId = @RestaurantId
                                    )
                                    SELECT @TotalRevenue = SUM(TotalPrice) FROM OrderItemTotalPrice;

                                    RETURN @TotalRevenue;
                                    END
                                   ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION fn_RestaurantTotalRevenue");
        }
    }
}
