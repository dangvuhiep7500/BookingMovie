using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingMovie.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    IdPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoGheToiDa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.IdPhong);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    IdTheLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTheLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.IdTheLoai);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    TaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Phim",
                columns: table => new
                {
                    IdPhim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTheLoai = table.Column<int>(type: "int", nullable: true),
                    TenPhim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThoiLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim", x => x.IdPhim);
                    table.ForeignKey(
                        name: "FK_Phim_TheLoai",
                        column: x => x.IdTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "IdTheLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChieu",
                columns: table => new
                {
                    IdChiTietChieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhim = table.Column<int>(type: "int", nullable: true),
                    IdPhong = table.Column<int>(type: "int", nullable: true),
                    NgayChieu = table.Column<DateTime>(type: "datetime", nullable: true),
                    GioBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    GiaVe = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietChieu", x => x.IdChiTietChieu);
                    table.ForeignKey(
                        name: "FK_ChiTietChieu_Phim",
                        column: x => x.IdPhim,
                        principalTable: "Phim",
                        principalColumn: "IdPhim",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietChieu_Phong",
                        column: x => x.IdPhong,
                        principalTable: "Phong",
                        principalColumn: "IdPhong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    MaVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdChiTietChieu = table.Column<int>(type: "int", nullable: true),
                    SoGhe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ve", x => x.MaVe);
                    table.ForeignKey(
                        name: "FK_Ve_ChiTietChieu",
                        column: x => x.IdChiTietChieu,
                        principalTable: "ChiTietChieu",
                        principalColumn: "IdChiTietChieu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChieu_IdPhim",
                table: "ChiTietChieu",
                column: "IdPhim");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChieu_IdPhong",
                table: "ChiTietChieu",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Phim_IdTheLoai",
                table: "Phim",
                column: "IdTheLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdChiTietChieu",
                table: "Ve",
                column: "IdChiTietChieu");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdUser",
                table: "Ve",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "ChiTietChieu");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Phim");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}
