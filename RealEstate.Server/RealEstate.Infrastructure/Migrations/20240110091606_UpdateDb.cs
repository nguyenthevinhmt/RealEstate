using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "UserIdentification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(3512),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 280, DateTimeKind.Local).AddTicks(728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 101, DateTimeKind.Local).AddTicks(4256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.AddColumn<string>(
                name: "Otp",
                schema: "dbo",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(2205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "RealEstateType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(1620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PostType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Post",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Media",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(2867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 280, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Otp", "Password", "Username" },
                values: new object[] { new DateTime(2024, 1, 10, 16, 16, 6, 101, DateTimeKind.Local).AddTicks(4256), null, "pW8/ZCs/obaPP+O+7b9zAqduS/lTlXk1AhpJ2hDaTQn534sq", "admin" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Otp", "Password", "Username" },
                values: new object[] { new DateTime(2024, 1, 10, 16, 16, 6, 101, DateTimeKind.Local).AddTicks(4256), null, "p7z1yFrsNCi4mkkcYg3+hR06szQtEPq20q+mJq9M9H1HPe9W", "customer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Otp",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "dbo",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "UserIdentification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 280, DateTimeKind.Local).AddTicks(728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 101, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(9350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "RealEstateType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(8700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PostType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(7727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Post",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(6763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Media",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 9, 17, 29, 23, 280, DateTimeKind.Local).AddTicks(41),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 16, 6, 102, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(207), "i4ZVtgh2ZbesdIwr1kVgvmMmxIDUICgKiNotI1ssTMK8WeFE" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 1, 9, 17, 29, 23, 279, DateTimeKind.Local).AddTicks(207), "/iFmp0tBAYdts5MXzoezK474eehemoOPGV22GvNbBKTyCvRI" });
        }
    }
}
