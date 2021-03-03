using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApi.Migrations
{
    public partial class MyNewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("35bbef83-2b66-4d94-b1b6-075b5172868f"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("38560f1d-83aa-4824-a39d-f81b2ac4ae81"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("cc552a5d-a3e4-4e5e-bcb0-3ec3d249a3f9"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("cf185182-88c1-4413-969d-733cea151b1a"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("e404faa1-7a06-41d2-87b8-7ddfb9e7300c"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("eb60226c-f9a0-44fc-887c-ec98ce39f433"),
                column: "Priority",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDoItems");
        }
    }
}
