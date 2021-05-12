using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_modulTask.Migrations
{
    public partial class EditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Song",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleasedDate",
                table: "Song",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Genre",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artist",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.Sql(@"
                 insert into Supply(ArtistId, SongId) VALUES((select ArtistId from Artist where Name ='LilNasX'), (select SongId from Song where Title ='Old Town Road'))
                 insert into Supply(ArtistId, SongId) VALUES((select ArtistId from Artist where Name ='Travis Scott'), (select SongId from Song where Title ='Sicko mode'))
                 insert into Supply(ArtistId, SongId) VALUES((select ArtistId from Artist where Name ='Stromae'), (select SongId from Song where Title ='Papaoutai'))
                 insert into Supply(ArtistId, SongId) VALUES((select ArtistId from Artist where Name ='Sub Urban'), (select SongId from Song where Title ='Cradles'))
                 insert into Supply(ArtistId, SongId) VALUES((select ArtistId from Artist where Name ='Outcast'), (select SongId from Song where Title ='Hey Ya'))
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Song",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleasedDate",
                table: "Song",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Genre",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artist",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
