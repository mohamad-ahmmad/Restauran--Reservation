using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class customers_with_reservations_details_view : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE VIEW dbo.CustomerWithReservationDetailsView
                                    AS
                                    SELECT c.CustomerId,
                                            c.Email,
                                            c.FirstName,
                                            c.LastName,
                                            c.PhoneNumber,
                                            re.Name as RestaurantName,
                                            re.Address as RestaurantAddress,
                                            re.PhoneNumber as RestaurantPhoneNumber,
                                            re.OpeningHours,
                                            r.TableId,
                                            r.PartySize,
                                            r.ReservationDate
                                    FROM Reservations as r
                                    INNER JOIN Customers as c
                                    ON r.ReservationId = c.CustomerId
                                    INNER JOIN Restaurants as re
                                    ON r.RestaurantId =  re.RestaurantId
                                    ");
                                    
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW CustomerWithReservationDetailsView");
        }
    }
}
