using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace API.Migrations
{
    public partial class UpdateTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // string sql = "Update classes set TeacherId = 4 where clID = 1;Update classes set TeacherId = 1 where clID = 2;Update classes set TeacherId = 2 where clID = 3;Update classes set TeacherId = 5 where clID = 4;Update classes set TeacherId = 3 where clID = 5;Update classes set TeacherId = 1 where clID = 6;";
            // migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
