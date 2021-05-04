using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_modulTask.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_Supply_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Hip-hop" },
                    { 3, "Country" },
                    { 4, "Rap" },
                    { 5, "Rock" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreID",
                table: "Song",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_SongId",
                table: "Supply",
                column: "SongId");

            migrationBuilder.Sql(@"
                 insert into Artist(Name,DateOfBirth,Phone,Email, InstagramUrl) VALUES('LilNasX','1999-04-09', '0302321','nas_a@gmail.com', 'https://www.instagram.com/lilnasx/')
                 insert into Artist(Name,DateOfBirth,Phone,Email, InstagramUrl) VALUES('Travis Scott','1992-04-30','travis_sct@gmail.com', 'https://www.instagram.com/travisscott/')
                 insert into Artist(Name,DateOfBirth,Phone,Email, InstagramUrl) VALUES('Stromae','1995-03-12','stromae@gmail.com', 'https://www.instagram.com/stromae/')
                 insert into Artist(Name,DateOfBirth,Phone,Email, InstagramUrl) VALUES('Sub Urban','1999-10-22','suburban@gmail.com', 'https://www.instagram.com/suburban/')
                 insert into Artist(Name,DateOfBirth,Phone,Email, InstagramUrl) VALUES('Outcast','1975-05-27','outcast@gmail.com','https://www.instagram.com/outkast/')

                 insert into Song(Title, Duration, ReleasedDate, GenreID) Values('Old Town Road','00:03:32','2019-06-04', (select GenreID from Genre where Title = 'Country'))
                 insert into Song(Title, Duration, ReleasedDate, GenreID) Values('Sicko mode','00:04:01','2018-02-11',(select GenreID from Genre where Title = 'Rap'))
                 insert into Song(Title, Duration, ReleasedDate, GenreID) Values('Papaoutai','00:03:17','2013-11-06',(select GenreID from Genre where Title = 'Pop'))
                 insert into Song(Title, Duration, ReleasedDate, GenreID) Values('Cradles','00:03:11','2019-10-02',(select GenreID from Genre where Title = 'Pop'))
                 insert into Song(Title, Duration, ReleasedDate, GenreID) Values('Hey Ya','00:04:17','2004-04-17',(select GenreID from Genre where Title = 'Rap'))
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
