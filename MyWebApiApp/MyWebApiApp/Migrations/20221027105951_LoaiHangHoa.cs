﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApiApp.Migrations
{
    public partial class LoaiHangHoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    GiamGia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHh);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoa");
        }
    }
}
