using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneForum.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CollectionListRelease",
                columns: table => new
                {
                    CollectionListsCollectionList_Id = table.Column<int>(type: "int", nullable: false),
                    ReleasesRelease_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionListRelease", x => new { x.CollectionListsCollectionList_Id, x.ReleasesRelease_Id });
                    table.ForeignKey(
                        name: "FK_CollectionListRelease_CollectionLists_CollectionListsCollectionList_Id",
                        column: x => x.CollectionListsCollectionList_Id,
                        principalTable: "CollectionLists",
                        principalColumn: "CollectionList_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionListRelease_Releases_ReleasesRelease_Id",
                        column: x => x.ReleasesRelease_Id,
                        principalTable: "Releases",
                        principalColumn: "Release_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseWantList",
                columns: table => new
                {
                    ReleasesRelease_Id = table.Column<int>(type: "int", nullable: false),
                    WantListsWantList_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseWantList", x => new { x.ReleasesRelease_Id, x.WantListsWantList_Id });
                    table.ForeignKey(
                        name: "FK_ReleaseWantList_Releases_ReleasesRelease_Id",
                        column: x => x.ReleasesRelease_Id,
                        principalTable: "Releases",
                        principalColumn: "Release_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleaseWantList_WantLists_WantListsWantList_Id",
                        column: x => x.WantListsWantList_Id,
                        principalTable: "WantLists",
                        principalColumn: "WantList_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionListRelease_ReleasesRelease_Id",
                table: "CollectionListRelease",
                column: "ReleasesRelease_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseWantList_WantListsWantList_Id",
                table: "ReleaseWantList",
                column: "WantListsWantList_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionListRelease");

            migrationBuilder.DropTable(
                name: "ReleaseWantList");

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
    }
}
