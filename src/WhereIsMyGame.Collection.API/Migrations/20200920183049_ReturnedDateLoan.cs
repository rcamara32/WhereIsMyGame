using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhereIsMyGame.Collection.API.Migrations
{
    public partial class ReturnedDateLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnedDate",
                table: "GamesLoan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "GamesLoan");
        }
    }
}
