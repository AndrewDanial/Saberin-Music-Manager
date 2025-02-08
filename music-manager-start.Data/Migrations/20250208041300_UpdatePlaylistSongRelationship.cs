using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace music_manager_starter.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlaylistSongRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_PlaylistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Songs");

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    PlaylistId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SongsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => new { x.PlaylistId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_SongsId",
                table: "PlaylistSong",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.AddColumn<Guid>(
                name: "PlaylistId",
                table: "Songs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                column: "PlaylistId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_PlaylistId",
                table: "Songs",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }
    }
}
