using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebProjec3T.Migrations
{
    /// <inheritdoc />
    public partial class f2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "employees",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "employees");
        }
    }
}
