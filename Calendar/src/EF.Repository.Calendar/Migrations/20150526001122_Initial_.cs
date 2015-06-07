using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace EF.Repository.Calendar.Migrations
{
    public partial class Initial_ : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "Name",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false);
            migration.AlterColumn(
                name: "Release",
                table: "Game",
                type: "datetimeoffset",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "Name",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);
            migration.AlterColumn(
                name: "Release",
                table: "Game",
                type: "datetime2",
                nullable: false);
        }
    }
}
