using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddForgeinKeyToContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Lessons_LessonlId",
                table: "Contents");

            migrationBuilder.AlterColumn<int>(
                name: "LessonlId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Lessons_LessonlId",
                table: "Contents",
                column: "LessonlId",
                principalTable: "Lessons",
                principalColumn: "lId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Lessons_LessonlId",
                table: "Contents");

            migrationBuilder.AlterColumn<int>(
                name: "LessonlId",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Lessons_LessonlId",
                table: "Contents",
                column: "LessonlId",
                principalTable: "Lessons",
                principalColumn: "lId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
