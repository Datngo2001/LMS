using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EditScoreModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "ClassesIds",
            //     table: "Scores",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddColumn<int>(
            //     name: "ClassesclId",
            //     table: "Scores",
            //     type: "int",
            //     nullable: true);

            // migrationBuilder.AddColumn<int>(
            //     name: "StudentId",
            //     table: "Scores",
            //     type: "int",
            //     nullable: true);

            // migrationBuilder.AddColumn<int>(
            //     name: "StudentIds",
            //     table: "Scores",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Scores_ClassesclId",
            //     table: "Scores",
            //     column: "ClassesclId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Scores_StudentId",
            //     table: "Scores",
            //     column: "StudentId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Scores_Classes_ClassesclId",
            //     table: "Scores",
            //     column: "ClassesclId",
            //     principalTable: "Classes",
            //     principalColumn: "clId",
            //     onDelete: ReferentialAction.Restrict);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Scores_Students_StudentId",
            //     table: "Scores",
            //     column: "StudentId",
            //     principalTable: "Students",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Scores_Classes_ClassesclId",
            //     table: "Scores");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Scores_Students_StudentId",
            //     table: "Scores");

            // migrationBuilder.DropIndex(
            //     name: "IX_Scores_ClassesclId",
            //     table: "Scores");

            // migrationBuilder.DropIndex(
            //     name: "IX_Scores_StudentId",
            //     table: "Scores");

            // migrationBuilder.DropColumn(
            //     name: "ClassesIds",
            //     table: "Scores");

            // migrationBuilder.DropColumn(
            //     name: "ClassesclId",
            //     table: "Scores");

            // migrationBuilder.DropColumn(
            //     name: "StudentId",
            //     table: "Scores");

            // migrationBuilder.DropColumn(
            //     name: "StudentIds",
            //     table: "Scores");
        }
    }
}
