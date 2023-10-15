using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class proc_CustomersWithPartySizeGreaterThan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"              
                                    CREATE PROCEDURE dbo.CustomersWithPartySizeGreaterThan
                                        @partySize int = 0
                                    AS
                                    BEGIN
                                        SELECT c.*
                                        FROM Reservations as r 
                                        JOIN Customers as c ON 
                                        r.CustomerId = c.CustomerId
                                        WHERE r.PartySize > @partySize;
                                    END
                                    GO
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    DROP PROCEDURE IF EXISTS  dbo.CustomersWithPartySizeGreaterThan
                                 ");
        }
    }
}
