﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class adjustfieldforimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Products",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
