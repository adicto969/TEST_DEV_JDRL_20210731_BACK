using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEST_DEV_JRL_20210731.Migrations
{
    public partial class create_table_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateIndex(name: "IX_PersonasFisicas_User_UsuarioAgrega", table: "Tb_PersonasFisicas", column: "UsuarioAgrega");
            migrationBuilder.AddForeignKey(
                name: "FK_Tb_PersonasFisicas_User_UsuarioAgrega",
                table: "Tb_PersonasFisicas",
                column: "UsuarioAgrega",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_PersonasFisicas_User_UsuarioAgrega", table: "Tb_PersonasFisicas");
            migrationBuilder.DropForeignKey(name: "FK_Tb_PersonasFisicas_User_UsuarioAgrega", table: "Tb_PersonasFisicas");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
