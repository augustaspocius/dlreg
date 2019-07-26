using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLRegIdentity.Data.Migrations
{
    public partial class Migrations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "devicereg",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    RECID = table.Column<int>(nullable: true),
                    WORKERID = table.Column<int>(nullable: true),
                    DEVICEID = table.Column<int>(nullable: true),
                    TIME = table.Column<DateTime>(type: "datetime", nullable: true),
                    INOUT = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devicereg", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    USERNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FULLNAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LASTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SHIFTID = table.Column<int>(nullable: true),
                    DEPARTMENTID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "monthreg",
                columns: table => new
                {
                    ROWID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MONTHID = table.Column<int>(nullable: false),
                    WORKERID = table.Column<int>(nullable: false),
                    DP1 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D1 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP2 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D2 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP3 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D3 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP4 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D4 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP5 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D5 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP6 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D6 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP7 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D7 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP8 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D8 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP9 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D9 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP10 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D10 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP11 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D11 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP12 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D12 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP13 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D13 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP14 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D14 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP15 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D15 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP16 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D16 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP17 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D17 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP18 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D18 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP19 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D19 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP20 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D20 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP21 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D21 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP22 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D22 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP23 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D23 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP24 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D24 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP25 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D25 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP26 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D26 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP27 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D27 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP28 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D28 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP29 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D29 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP30 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D30 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    DP31 = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    D31 = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
                    COMMENT = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monthreg", x => x.ROWID);
                    table.ForeignKey(
                        name: "FK_monthreg_workers_WORKERID",
                        column: x => x.WORKERID,
                        principalTable: "workers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_monthreg_WORKERID",
                table: "monthreg",
                column: "WORKERID");

            migrationBuilder.CreateIndex(
                name: "IX_Table_1",
                table: "monthreg",
                columns: new[] { "MONTHID", "WORKERID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fullname",
                table: "workers",
                column: "FULLNAME",
                unique: true,
                filter: "[FULLNAME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_username",
                table: "workers",
                column: "USERNAME",
                unique: true,
                filter: "[USERNAME] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devicereg");

            migrationBuilder.DropTable(
                name: "monthreg");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
