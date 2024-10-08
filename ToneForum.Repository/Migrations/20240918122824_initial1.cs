using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneForum.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Releases_CollectionLists_CollectionList_Id",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_WantLists_WantList_Id",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_CollectionList_Id",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_WantList_Id",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "CollectionList_Id",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "WantList_Id",
                table: "Releases");

            migrationBuilder.AddColumn<int>(
                name: "Release_Id",
                table: "WantLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Release_Id",
                table: "CollectionLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WantLists_Release_Id",
                table: "WantLists",
                column: "Release_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionLists_Release_Id",
                table: "CollectionLists",
                column: "Release_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionLists_Releases_Release_Id",
                table: "CollectionLists",
                column: "Release_Id",
                principalTable: "Releases",
                principalColumn: "Release_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WantLists_Releases_Release_Id",
                table: "WantLists",
                column: "Release_Id",
                principalTable: "Releases",
                principalColumn: "Release_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionLists_Releases_Release_Id",
                table: "CollectionLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WantLists_Releases_Release_Id",
                table: "WantLists");

            migrationBuilder.DropIndex(
                name: "IX_WantLists_Release_Id",
                table: "WantLists");

            migrationBuilder.DropIndex(
                name: "IX_CollectionLists_Release_Id",
                table: "CollectionLists");

            migrationBuilder.DropColumn(
                name: "Release_Id",
                table: "WantLists");

            migrationBuilder.DropColumn(
                name: "Release_Id",
                table: "CollectionLists");

            migrationBuilder.AddColumn<int>(
                name: "CollectionList_Id",
                table: "Releases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WantList_Id",
                table: "Releases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Releases_CollectionList_Id",
                table: "Releases",
                column: "CollectionList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_WantList_Id",
                table: "Releases",
                column: "WantList_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_CollectionLists_CollectionList_Id",
                table: "Releases",
                column: "CollectionList_Id",
                principalTable: "CollectionLists",
                principalColumn: "CollectionList_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_WantLists_WantList_Id",
                table: "Releases",
                column: "WantList_Id",
                principalTable: "WantLists",
                principalColumn: "WantList_Id");
        }
    }
}
