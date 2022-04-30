using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFizyo.Migrations
{
    public partial class aleynauc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankalar",
                columns: table => new
                {
                    BankaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankalar", x => x.BankaID);
                });

            migrationBuilder.CreateTable(
                name: "İhtiyaçSıklıkları",
                columns: table => new
                {
                    İhtiyaçSıklığıID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İhtiyaçSıklığıAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İhtiyaçSıklıkları", x => x.İhtiyaçSıklığıID);
                });

            migrationBuilder.CreateTable(
                name: "MedeniDurumlar",
                columns: table => new
                {
                    MedeniDurumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedeniDurumAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedeniDurumlar", x => x.MedeniDurumID);
                });

            migrationBuilder.CreateTable(
                name: "İhtiyaç",
                columns: table => new
                {
                    İhtiyaçID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İhtiyaçAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    İhtiyaçSıklığıID = table.Column<int>(type: "int", nullable: false),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İhtiyaç", x => x.İhtiyaçID);
                    table.ForeignKey(
                        name: "FK_İhtiyaç_İhtiyaçSıklıkları_İhtiyaçSıklığıID",
                        column: x => x.İhtiyaçSıklığıID,
                        principalTable: "İhtiyaçSıklıkları",
                        principalColumn: "İhtiyaçSıklığıID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_İhtiyaç_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İhtiyaç_İhtiyaçSıklığıID",
                table: "İhtiyaç",
                column: "İhtiyaçSıklığıID");

            migrationBuilder.CreateIndex(
                name: "IX_İhtiyaç_KullanıcıID",
                table: "İhtiyaç",
                column: "KullanıcıID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bankalar");

            migrationBuilder.DropTable(
                name: "İhtiyaç");

            migrationBuilder.DropTable(
                name: "MedeniDurumlar");

            migrationBuilder.DropTable(
                name: "İhtiyaçSıklıkları");
        }
    }
}
