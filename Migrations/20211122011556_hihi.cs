using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class hihi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PeopleID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeopleName = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Adress = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PeopleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
