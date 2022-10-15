using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioGranto.Migrations
{
    public partial class cofiguracao_usuarioid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oportunidade_Usuario_UsuarioId",
                table: "Oportunidade");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Oportunidade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Oportunidade_Usuario_UsuarioId",
                table: "Oportunidade",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oportunidade_Usuario_UsuarioId",
                table: "Oportunidade");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Oportunidade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Oportunidade_Usuario_UsuarioId",
                table: "Oportunidade",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
