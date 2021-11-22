using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class heheee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haha",
                columns: table => new
                {
                    HahaID = table.Column<string>(nullable: false),
                    HahaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haha", x => x.HahaID);
                });

            migrationBuilder.CreateTable(
                name: "Hehes",
                columns: table => new
                {
                    HeheID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeheName = table.Column<string>(nullable: true),
                    HahaID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hehes", x => x.HeheID);
                    table.ForeignKey(
                        name: "FK_Hehes_Haha_HahaID",
                        column: x => x.HahaID,
                        principalTable: "Haha",
                        principalColumn: "HahaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hehes_HahaID",
                table: "Hehes",
                column: "HahaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hehes");

            migrationBuilder.DropTable(
                name: "Haha");
        }
    }
}
