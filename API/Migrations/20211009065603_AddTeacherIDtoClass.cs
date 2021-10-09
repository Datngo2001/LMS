using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTeacherIDtoClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "TeacherId",
            //     table: "Classes",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Classes_TeacherId",
            //     table: "Classes",
            //     column: "TeacherId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Classes_Teachers_TeacherId",
            //     table: "Classes",
            //     column: "TeacherId",
            //     principalTable: "Teachers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
            // string sql = "Update classes set TeacherId = 4 where clID = 1;Update classes set TeacherId = 1 where clID = 2;Update classes set TeacherId = 2 where clID = 3;Update classes set TeacherId = 5 where clID = 4;Update classes set TeacherId = 3 where clID = 5;Update classes set TeacherId = 1 where clID = 6;";
            // migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Classes_Teachers_TeacherId",
            //     table: "Classes");

            // migrationBuilder.DropIndex(
            //     name: "IX_Classes_TeacherId",
            //     table: "Classes");

            // migrationBuilder.DropColumn(
            //     name: "TeacherId",
            //     table: "Classes");
        }
    }
}
