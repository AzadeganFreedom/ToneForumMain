using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneForum.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Band_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    StartYear = table.Column<double>(type: "float", nullable: false),
                    EndYear = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Band_Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Format_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Format_Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentGenre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre_Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptTermsAndPolicy = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionLists",
                columns: table => new
                {
                    CollectionList_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionLists", x => x.CollectionList_Id);
                    table.ForeignKey(
                        name: "FK_CollectionLists_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WantLists",
                columns: table => new
                {
                    WantList_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantLists", x => x.WantList_Id);
                    table.ForeignKey(
                        name: "FK_WantLists_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Release_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<double>(type: "float", nullable: false),
                    Band_Id = table.Column<int>(type: "int", nullable: false),
                    Type_Id = table.Column<int>(type: "int", nullable: false),
                    Genre_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionList_Id = table.Column<int>(type: "int", nullable: true),
                    WantList_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Release_Id);
                    table.ForeignKey(
                        name: "FK_Releases_Bands_Band_Id",
                        column: x => x.Band_Id,
                        principalTable: "Bands",
                        principalColumn: "Band_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Releases_CollectionLists_CollectionList_Id",
                        column: x => x.CollectionList_Id,
                        principalTable: "CollectionLists",
                        principalColumn: "CollectionList_Id");
                    table.ForeignKey(
                        name: "FK_Releases_Types_Type_Id",
                        column: x => x.Type_Id,
                        principalTable: "Types",
                        principalColumn: "Type_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Releases_WantLists_WantList_Id",
                        column: x => x.WantList_Id,
                        principalTable: "WantLists",
                        principalColumn: "WantList_Id");
                });

            migrationBuilder.CreateTable(
                name: "GenreRelease",
                columns: table => new
                {
                    GenresGenre_Id = table.Column<int>(type: "int", nullable: false),
                    ReleasesRelease_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreRelease", x => new { x.GenresGenre_Id, x.ReleasesRelease_Id });
                    table.ForeignKey(
                        name: "FK_GenreRelease_Genres_GenresGenre_Id",
                        column: x => x.GenresGenre_Id,
                        principalTable: "Genres",
                        principalColumn: "Genre_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreRelease_Releases_ReleasesRelease_Id",
                        column: x => x.ReleasesRelease_Id,
                        principalTable: "Releases",
                        principalColumn: "Release_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionLists_User_Id",
                table: "CollectionLists",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GenreRelease_ReleasesRelease_Id",
                table: "GenreRelease",
                column: "ReleasesRelease_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_Band_Id",
                table: "Releases",
                column: "Band_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_CollectionList_Id",
                table: "Releases",
                column: "CollectionList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_Type_Id",
                table: "Releases",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_WantList_Id",
                table: "Releases",
                column: "WantList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WantLists_User_Id",
                table: "WantLists",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "GenreRelease");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "CollectionLists");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "WantLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
