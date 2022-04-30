using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFizyo.Migrations
{
    public partial class BatuhanBir : Migration
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
                name: "Cinsiyetler",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsiyetAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyetler", x => x.CinsiyetID);
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
                name: "İller",
                columns: table => new
                {
                    İlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İlAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İller", x => x.İlID);
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
                name: "Roller",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false),
                    RolAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "İlçeler",
                columns: table => new
                {
                    İlçeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İlçeAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    İlID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İlçeler", x => x.İlçeID);
                    table.ForeignKey(
                        name: "FK_İlçeler_İller_İlID",
                        column: x => x.İlID,
                        principalTable: "İller",
                        principalColumn: "İlID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eposta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Şifre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıID);
                    table.ForeignKey(
                        name: "FK_Kullanıcılar_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresler",
                columns: table => new
                {
                    AdresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    AdresAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdresDetay = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostaKodu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    İlçeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresler", x => x.AdresID);
                    table.ForeignKey(
                        name: "FK_Adresler_İlçeler_İlçeID",
                        column: x => x.İlçeID,
                        principalTable: "İlçeler",
                        principalColumn: "İlçeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresler_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hesaplar",
                columns: table => new
                {
                    HesapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaID = table.Column<int>(type: "int", nullable: false),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    HesapSahibiTamAdı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bakiye = table.Column<double>(type: "float", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    HesapNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ŞubeKodu = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplar", x => x.HesapID);
                    table.ForeignKey(
                        name: "FK_Hesaplar_Bankalar_BankaID",
                        column: x => x.BankaID,
                        principalTable: "Bankalar",
                        principalColumn: "BankaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hesaplar_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İhtiyaçlar",
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
                    table.PrimaryKey("PK_İhtiyaçlar", x => x.İhtiyaçID);
                    table.ForeignKey(
                        name: "FK_İhtiyaçlar_İhtiyaçSıklıkları_İhtiyaçSıklığıID",
                        column: x => x.İhtiyaçSıklığıID,
                        principalTable: "İhtiyaçSıklıkları",
                        principalColumn: "İhtiyaçSıklığıID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_İhtiyaçlar_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kişiler",
                columns: table => new
                {
                    KişiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    AdVeİkinciAd = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "Date", nullable: false),
                    CinsiyetID = table.Column<int>(type: "int", nullable: false),
                    İlID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kişiler", x => x.KişiID);
                    table.ForeignKey(
                        name: "FK_Kişiler_Cinsiyetler_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetler",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kişiler_İller_İlID",
                        column: x => x.İlID,
                        principalTable: "İller",
                        principalColumn: "İlID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kişiler_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedeniBilgiler",
                columns: table => new
                {
                    MedeniBilgiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    MedeniDurumID = table.Column<int>(type: "int", nullable: false),
                    ÇocukSayısı = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedeniBilgiler", x => x.MedeniBilgiID);
                    table.ForeignKey(
                        name: "FK_MedeniBilgiler_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedeniBilgiler_MedeniDurumlar_MedeniDurumID",
                        column: x => x.MedeniDurumID,
                        principalTable: "MedeniDurumlar",
                        principalColumn: "MedeniDurumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinsiyetler",
                columns: new[] { "CinsiyetID", "CinsiyetAdı" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" },
                    { 3, "Diğer" }
                });

            migrationBuilder.InsertData(
                table: "MedeniDurumlar",
                columns: new[] { "MedeniDurumID", "MedeniDurumAdı" },
                values: new object[,]
                {
                    { 1, "Evli" },
                    { 2, "Bekar" },
                    { 3, "Dul" }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "RolID", "RolAdı" },
                values: new object[,]
                {
                    { 1, "UserCandidate" },
                    { 2, "UserNormal" },
                    { 3, "Admin" },
                    { 4, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "İhtiyaçSıklıkları",
                columns: new[] { "İhtiyaçSıklığıID", "İhtiyaçSıklığıAdı" },
                values: new object[,]
                {
                    { 1, "Tek Seferlik" },
                    { 2, "Günlük" },
                    { 3, "Haftalık" },
                    { 4, "Aylık" }
                });

            migrationBuilder.InsertData(
                table: "İller",
                columns: new[] { "İlID", "İlAdı" },
                values: new object[,]
                {
                    { 1, "ADANA" },
                    { 2, "ADIYAMAN" },
                    { 3, "AFYONKARAHİSAR" },
                    { 4, "AĞRI" },
                    { 5, "AMASYA" },
                    { 6, "ANKARA" },
                    { 7, "ANTALYA" },
                    { 8, "ARTVİN" },
                    { 9, "AYDIN" },
                    { 10, "BALIKESİR" },
                    { 11, "BİLECİK" },
                    { 12, "BİNGÖL" },
                    { 13, "BİTLİS" },
                    { 14, "BOLU" },
                    { 15, "BURDUR" },
                    { 16, "BURSA" },
                    { 17, "ÇANAKKALE" },
                    { 18, "ÇANKIRI" },
                    { 19, "ÇORUM" },
                    { 20, "DENİZLİ" },
                    { 21, "DİYARBAKIR" },
                    { 22, "EDİRNE" },
                    { 23, "ELAZIĞ" },
                    { 24, "ERZİNCAN" },
                    { 25, "ERZURUM" },
                    { 26, "ESKİŞEHİR" },
                    { 27, "GAZİANTEP" },
                    { 28, "GİRESUN" }
                });

            migrationBuilder.InsertData(
                table: "İller",
                columns: new[] { "İlID", "İlAdı" },
                values: new object[,]
                {
                    { 29, "GÜMÜŞHANE" },
                    { 30, "HAKKARİ" },
                    { 31, "HATAY" },
                    { 32, "ISPARTA" },
                    { 33, "MERSİN" },
                    { 34, "İSTANBUL" },
                    { 35, "İZMİR" },
                    { 36, "KARS" },
                    { 37, "KASTAMONU" },
                    { 38, "KAYSERİ" },
                    { 39, "KIRKLARELİ" },
                    { 40, "KIRŞEHİR" },
                    { 41, "KOCAELİ" },
                    { 42, "KONYA" },
                    { 43, "KÜTAHYA" },
                    { 44, "MALATYA" },
                    { 45, "MANİSA" },
                    { 46, "KAHRAMANMARAŞ" },
                    { 47, "MARDİN" },
                    { 48, "MUĞLA" },
                    { 49, "MUŞ" },
                    { 50, "NEVŞEHİR" },
                    { 51, "NİĞDE" },
                    { 52, "ORDU" },
                    { 53, "RİZE" },
                    { 54, "SAKARYA" },
                    { 55, "SAMSUN" },
                    { 56, "SİİRT" },
                    { 57, "SİNOP" },
                    { 58, "SİVAS" },
                    { 59, "TEKİRDAĞ" },
                    { 60, "TOKAT" },
                    { 61, "TRABZON" },
                    { 62, "TUNCELİ" },
                    { 63, "ŞANLIURFA" },
                    { 64, "UŞAK" },
                    { 65, "VAN" },
                    { 66, "YOZGAT" },
                    { 67, "ZONGULDAK" },
                    { 68, "AKSARAY" },
                    { 69, "BAYBURT" },
                    { 70, "KARAMAN" }
                });

            migrationBuilder.InsertData(
                table: "İller",
                columns: new[] { "İlID", "İlAdı" },
                values: new object[,]
                {
                    { 71, "KIRIKKALE" },
                    { 72, "BATMAN" },
                    { 73, "ŞIRNAK" },
                    { 74, "BARTIN" },
                    { 75, "ARDAHAN" },
                    { 76, "IĞDIR" },
                    { 77, "YALOVA" },
                    { 78, "KARABÜK" },
                    { 79, "KİLİS" },
                    { 80, "OSMANİYE" },
                    { 81, "DÜZCE" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "Eposta", "RolID", "Şifre" },
                values: new object[,]
                {
                    { 1, "sinan@outlook.com", 1, "Qwe123" },
                    { 2, "ali@hotmail.com", 1, "Qwe123" },
                    { 3, "mahmut@hotmail.com", 3, "Qwe123" },
                    { 4, "mansurkürşad@icloud.com", 2, "Qwe123" },
                    { 5, "gamze@gmail.com", 4, "Qwe123" },
                    { 6, "miraç@hotmail.com", 3, "Qwe123" },
                    { 7, "yücel@outlook.com", 1, "Qwe123" },
                    { 8, "kubilay@gmail.com", 4, "Qwe123" },
                    { 9, "hayati@hotmail.com", 3, "Qwe123" },
                    { 10, "bedriyemüge@hotmail.com", 2, "Qwe123" },
                    { 11, "birsen@icloud.com", 1, "Qwe123" },
                    { 12, "serdal@gmail.com", 2, "Qwe123" },
                    { 13, "bünyamin@gmail.com", 3, "Qwe123" },
                    { 14, "özgür@gmail.com", 2, "Qwe123" },
                    { 15, "ferdi@gmail.com", 1, "Qwe123" },
                    { 16, "reyhan@outlook.com", 2, "Qwe123" },
                    { 17, "ilhan@gmail.com", 2, "Qwe123" },
                    { 18, "gülşah@icloud.com", 4, "Qwe123" },
                    { 19, "nalan@outlook.com", 3, "Qwe123" },
                    { 20, "semih@outlook.com", 2, "Qwe123" },
                    { 21, "ergün@outlook.com", 1, "Qwe123" },
                    { 22, "fatih@hotmail.com", 3, "Qwe123" },
                    { 23, "şenay@gmail.com", 4, "Qwe123" },
                    { 24, "serkan@outlook.com", 4, "Qwe123" },
                    { 25, "emre@icloud.com", 4, "Qwe123" },
                    { 26, "bahattin@gmail.com", 4, "Qwe123" },
                    { 27, "irazca@gmail.com", 1, "Qwe123" },
                    { 28, "hatice@icloud.com", 3, "Qwe123" },
                    { 29, "bariş@icloud.com", 3, "Qwe123" },
                    { 30, "rezan@hotmail.com", 3, "Qwe123" },
                    { 31, "fatih@gmail.com", 2, "Qwe123" },
                    { 32, "fuat@outlook.com", 1, "Qwe123" },
                    { 33, "gökhan@icloud.com", 1, "Qwe123" },
                    { 34, "orhan@outlook.com", 4, "Qwe123" },
                    { 35, "mehmet@hotmail.com", 3, "Qwe123" },
                    { 36, "evren@hotmail.com", 3, "Qwe123" },
                    { 37, "oktay@gmail.com", 1, "Qwe123" },
                    { 38, "harun@gmail.com", 1, "Qwe123" },
                    { 39, "yavuz@hotmail.com", 4, "Qwe123" },
                    { 40, "pinar@hotmail.com", 4, "Qwe123" },
                    { 41, "mehmet@icloud.com", 2, "Qwe123" },
                    { 42, "umut@outlook.com", 2, "Qwe123" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "Eposta", "RolID", "Şifre" },
                values: new object[,]
                {
                    { 43, "mesude@hotmail.com", 4, "Qwe123" },
                    { 44, "hüseyincahit@gmail.com", 4, "Qwe123" },
                    { 45, "haşimonur@gmail.com", 2, "Qwe123" },
                    { 46, "eyyupsabri@gmail.com", 3, "Qwe123" },
                    { 47, "mustafa@icloud.com", 2, "Qwe123" },
                    { 48, "mustafa@icloud.com", 2, "Qwe123" },
                    { 49, "ufuk@icloud.com", 1, "Qwe123" },
                    { 50, "ahmetali@hotmail.com", 2, "Qwe123" },
                    { 51, "mediha@icloud.com", 2, "Qwe123" },
                    { 52, "hasan@icloud.com", 3, "Qwe123" },
                    { 53, "kamil@icloud.com", 3, "Qwe123" },
                    { 54, "nebi@icloud.com", 1, "Qwe123" },
                    { 55, "özcan@gmail.com", 4, "Qwe123" },
                    { 56, "nagihan@gmail.com", 3, "Qwe123" },
                    { 57, "ceren@gmail.com", 2, "Qwe123" },
                    { 58, "serkan@hotmail.com", 3, "Qwe123" },
                    { 59, "hasan@icloud.com", 3, "Qwe123" },
                    { 60, "yusufkenan@gmail.com", 4, "Qwe123" },
                    { 61, "çetin@icloud.com", 1, "Qwe123" },
                    { 62, "tarkan@gmail.com", 2, "Qwe123" },
                    { 63, "meralleman@hotmail.com", 2, "Qwe123" },
                    { 64, "ergün@icloud.com", 4, "Qwe123" },
                    { 65, "kenanahmet@icloud.com", 4, "Qwe123" },
                    { 66, "ural@icloud.com", 4, "Qwe123" },
                    { 67, "yahya@icloud.com", 2, "Qwe123" },
                    { 68, "bengü@outlook.com", 2, "Qwe123" },
                    { 69, "fatihnazmi@hotmail.com", 2, "Qwe123" },
                    { 70, "dilek@outlook.com", 1, "Qwe123" },
                    { 71, "mehmet@icloud.com", 1, "Qwe123" },
                    { 72, "tufanakin@hotmail.com", 4, "Qwe123" },
                    { 73, "mehmet@hotmail.com", 1, "Qwe123" },
                    { 74, "turgayyilmaz@icloud.com", 4, "Qwe123" },
                    { 75, "güldehen@icloud.com", 4, "Qwe123" },
                    { 76, "gökmen@hotmail.com", 2, "Qwe123" },
                    { 77, "bülent@gmail.com", 2, "Qwe123" },
                    { 78, "erol@icloud.com", 2, "Qwe123" },
                    { 79, "bahri@icloud.com", 1, "Qwe123" },
                    { 80, "özenözlem@gmail.com", 2, "Qwe123" },
                    { 81, "selma@icloud.com", 3, "Qwe123" },
                    { 82, "tuğsem@hotmail.com", 1, "Qwe123" },
                    { 83, "teslimenazli@gmail.com", 4, "Qwe123" },
                    { 84, "gülçin@hotmail.com", 3, "Qwe123" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "Eposta", "RolID", "Şifre" },
                values: new object[,]
                {
                    { 85, "ismail@icloud.com", 3, "Qwe123" },
                    { 86, "murat@gmail.com", 4, "Qwe123" },
                    { 87, "ebru@icloud.com", 2, "Qwe123" },
                    { 88, "tümay@gmail.com", 2, "Qwe123" },
                    { 89, "ahmet@gmail.com", 4, "Qwe123" },
                    { 90, "ebru@icloud.com", 2, "Qwe123" },
                    { 91, "hüseyinyavuz@gmail.com", 3, "Qwe123" },
                    { 92, "başak@outlook.com", 1, "Qwe123" },
                    { 93, "ayşegül@hotmail.com", 1, "Qwe123" },
                    { 94, "evrim@icloud.com", 4, "Qwe123" },
                    { 95, "yaser@hotmail.com", 3, "Qwe123" },
                    { 96, "ülkü@icloud.com", 3, "Qwe123" },
                    { 97, "özhan@icloud.com", 1, "Qwe123" },
                    { 98, "ufuk@gmail.com", 4, "Qwe123" },
                    { 99, "aksel@hotmail.com", 3, "Qwe123" },
                    { 100, "fulya@icloud.com", 3, "Qwe123" },
                    { 101, "burcu@icloud.com", 3, "Qwe123" },
                    { 102, "taylan@hotmail.com", 4, "Qwe123" },
                    { 103, "yilmaz@icloud.com", 2, "Qwe123" },
                    { 104, "zeynep@gmail.com", 4, "Qwe123" },
                    { 105, "bayram@icloud.com", 3, "Qwe123" },
                    { 106, "gülay@hotmail.com", 3, "Qwe123" },
                    { 107, "rabia@outlook.com", 1, "Qwe123" },
                    { 108, "sevda@outlook.com", 2, "Qwe123" },
                    { 109, "serhat@hotmail.com", 2, "Qwe123" },
                    { 110, "engin@icloud.com", 3, "Qwe123" },
                    { 111, "asli@hotmail.com", 2, "Qwe123" },
                    { 112, "tuba@icloud.com", 2, "Qwe123" },
                    { 113, "bariş@hotmail.com", 4, "Qwe123" },
                    { 114, "sevgi@hotmail.com", 4, "Qwe123" },
                    { 115, "kalender@outlook.com", 3, "Qwe123" },
                    { 116, "halil@icloud.com", 4, "Qwe123" },
                    { 117, "bilge@icloud.com", 1, "Qwe123" },
                    { 118, "ferda@gmail.com", 4, "Qwe123" },
                    { 119, "ezgi@hotmail.com", 2, "Qwe123" },
                    { 120, "aysun@outlook.com", 4, "Qwe123" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 1, 37, "Abana" },
                    { 2, 50, "Acıgöl" },
                    { 3, 20, "Acıpayam" },
                    { 4, 12, "Adaklı" },
                    { 5, 34, "Adalar" },
                    { 6, 54, "Adapazarı" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 7, 2, "Adıyaman" },
                    { 8, 13, "Adilcevaz" },
                    { 9, 46, "Afşin" },
                    { 10, 3, "Afyonkarahisar" },
                    { 11, 68, "Ağaçören" },
                    { 12, 23, "Ağın" },
                    { 13, 15, "Ağlasun" },
                    { 14, 37, "Ağlı" },
                    { 15, 4, "Ağrı" },
                    { 16, 42, "Ahırlı" },
                    { 17, 13, "Ahlat" },
                    { 18, 45, "Ahmetli" },
                    { 19, 61, "Akçaabat" },
                    { 20, 44, "Akçadağ" },
                    { 21, 63, "Akçakale" },
                    { 22, 40, "Akçakent" },
                    { 23, 81, "Akçakoca" },
                    { 24, 66, "Akdağmadeni" },
                    { 25, 33, "Akdeniz" },
                    { 26, 45, "Akhisar" },
                    { 27, 58, "Akıncılar" },
                    { 28, 38, "Akkışla" },
                    { 29, 52, "Akkuş" },
                    { 30, 42, "Akören" },
                    { 31, 40, "Akpınar" },
                    { 32, 68, "Aksaray" },
                    { 33, 7, "Akseki" },
                    { 34, 7, "Aksu" },
                    { 35, 32, "Aksu" },
                    { 36, 42, "Akşehir" },
                    { 37, 36, "Akyaka" },
                    { 38, 54, "Akyazı" },
                    { 39, 6, "Akyurt" },
                    { 40, 19, "Alaca" },
                    { 41, 23, "Alacakaya" },
                    { 42, 55, "Alaçam" },
                    { 43, 1, "Aladağ" },
                    { 44, 7, "Alanya" },
                    { 45, 67, "Alaplı" },
                    { 46, 45, "Alaşehir" },
                    { 47, 35, "Aliağa" },
                    { 48, 60, "Almus" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 49, 26, "Alpu" },
                    { 50, 10, "Altıeylül" },
                    { 51, 6, "Altındağ" },
                    { 52, 42, "Altınekin" },
                    { 53, 52, "Altınordu" },
                    { 54, 77, "Altınova" },
                    { 55, 31, "Altınözü" },
                    { 56, 43, "Altıntaş" },
                    { 57, 15, "Altınyayla" },
                    { 58, 58, "Altınyayla" },
                    { 59, 51, "Altunhisar" },
                    { 60, 28, "Alucra" },
                    { 61, 74, "Amasra" },
                    { 62, 5, "Amasya" },
                    { 63, 33, "Anamur" },
                    { 64, 46, "Andırın" },
                    { 65, 31, "Antakya" },
                    { 66, 27, "Araban" },
                    { 67, 37, "Araç" },
                    { 68, 61, "Araklı" },
                    { 69, 76, "Aralık" },
                    { 70, 44, "Arapgir" },
                    { 71, 75, "Ardahan" },
                    { 72, 8, "Ardanuç" },
                    { 73, 53, "Ardeşen" },
                    { 74, 44, "Arguvan" },
                    { 75, 8, "Arhavi" },
                    { 76, 23, "Arıcak" },
                    { 77, 54, "Arifiye" },
                    { 78, 77, "Armutlu" },
                    { 79, 34, "Arnavutköy" },
                    { 80, 36, "Arpaçay" },
                    { 81, 61, "Arsin" },
                    { 82, 31, "Arsuz" },
                    { 83, 60, "Artova" },
                    { 84, 47, "Artuklu" },
                    { 85, 8, "Artvin" },
                    { 86, 55, "Asarcık" },
                    { 87, 43, "Aslanapa" },
                    { 88, 25, "Aşkale" },
                    { 89, 32, "Atabey" },
                    { 90, 55, "Atakum" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 91, 34, "Ataşehir" },
                    { 92, 18, "Atkaracalar" },
                    { 93, 50, "Avanos" },
                    { 94, 34, "Avcılar" },
                    { 95, 57, "Ayancık" },
                    { 96, 6, "Ayaş" },
                    { 97, 52, "Aybastı" },
                    { 98, 33, "Aydıncık" },
                    { 99, 66, "Aydıncık" },
                    { 100, 69, "Aydıntepe" },
                    { 101, 70, "Ayrancı" },
                    { 102, 17, "Ayvacık" },
                    { 103, 55, "Ayvacık" },
                    { 104, 10, "Ayvalık" },
                    { 105, 37, "Azdavay" },
                    { 106, 25, "Aziziye" },
                    { 107, 20, "Babadağ" },
                    { 108, 39, "Babaeski" },
                    { 109, 55, "Bafra" },
                    { 110, 34, "Bağcılar" },
                    { 111, 21, "Bağlar" },
                    { 112, 80, "Bahçe" },
                    { 113, 34, "Bahçelievler" },
                    { 114, 65, "Bahçesaray" },
                    { 115, 71, "Bahşili" },
                    { 116, 34, "Bakırköy" },
                    { 117, 20, "Baklan" },
                    { 118, 6, "Bala" },
                    { 119, 35, "Balçova" },
                    { 120, 71, "Balışeyh" },
                    { 121, 10, "Balya" },
                    { 122, 64, "Banaz" },
                    { 123, 10, "Bandırma" },
                    { 124, 74, "Bartın" },
                    { 125, 23, "Baskil" },
                    { 126, 34, "Başakşehir" },
                    { 127, 60, "Başçiftlik" },
                    { 128, 41, "Başiskele" },
                    { 129, 65, "Başkale" },
                    { 130, 3, "Başmakçı" },
                    { 131, 70, "Başyayla" },
                    { 132, 72, "Batman" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 133, 44, "Battalgazi" },
                    { 134, 3, "Bayat" },
                    { 135, 19, "Bayat" },
                    { 136, 69, "Bayburt" },
                    { 137, 35, "Bayındır" },
                    { 138, 56, "Baykan" },
                    { 139, 35, "Bayraklı" },
                    { 140, 17, "Bayramiç" },
                    { 141, 18, "Bayramören" },
                    { 142, 34, "Bayrampaşa" },
                    { 143, 20, "Bekilli" },
                    { 144, 31, "Belen" },
                    { 145, 35, "Bergama" },
                    { 146, 2, "Besni" },
                    { 147, 61, "Beşikdüzü" },
                    { 148, 34, "Beşiktaş" },
                    { 149, 72, "Beşiri" },
                    { 150, 20, "Beyağaç" },
                    { 151, 35, "Beydağ" },
                    { 152, 34, "Beykoz" },
                    { 153, 34, "Beylikdüzü" },
                    { 154, 26, "Beylikova" },
                    { 155, 34, "Beyoğlu" },
                    { 156, 6, "Beypazarı" },
                    { 157, 42, "Beyşehir" },
                    { 158, 73, "Beytüşşebap" },
                    { 159, 17, "Biga" },
                    { 160, 10, "Bigadiç" },
                    { 161, 11, "Bilecik" },
                    { 162, 12, "Bingöl" },
                    { 163, 63, "Birecik" },
                    { 164, 21, "Bismil" },
                    { 165, 13, "Bitlis" },
                    { 166, 48, "Bodrum" },
                    { 167, 19, "Boğazkale" },
                    { 168, 66, "Boğazlıyan" },
                    { 169, 14, "Bolu" },
                    { 170, 3, "Bolvadin" },
                    { 171, 51, "Bor" },
                    { 172, 8, "Borçka" },
                    { 173, 35, "Bornova" },
                    { 174, 57, "Boyabat" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 175, 17, "Bozcaada" },
                    { 176, 9, "Bozdoğan" },
                    { 177, 42, "Bozkır" },
                    { 178, 20, "Bozkurt" },
                    { 179, 37, "Bozkurt" },
                    { 180, 63, "Bozova" },
                    { 181, 40, "Boztepe" },
                    { 182, 11, "Bozüyük" },
                    { 183, 33, "Bozyazı" },
                    { 184, 35, "Buca" },
                    { 185, 15, "Bucak" },
                    { 186, 9, "Buharkent" },
                    { 187, 28, "Bulancak" },
                    { 188, 49, "Bulanık" },
                    { 189, 20, "Buldan" },
                    { 190, 15, "Burdur" },
                    { 191, 10, "Burhaniye" },
                    { 192, 38, "Bünyan" },
                    { 193, 34, "Büyükçekmece" },
                    { 194, 16, "Büyükorhan" },
                    { 195, 55, "Canik" },
                    { 196, 1, "Ceyhan" },
                    { 197, 63, "Ceylanpınar" },
                    { 198, 37, "Cide" },
                    { 199, 42, "Cihanbeyli" },
                    { 200, 73, "Cizre" },
                    { 201, 81, "Cumayeri" },
                    { 202, 46, "Çağlayancerit" },
                    { 203, 20, "Çal" },
                    { 204, 65, "Çaldıran" },
                    { 205, 51, "Çamardı" },
                    { 206, 52, "Çamaş" },
                    { 207, 20, "Çameli" },
                    { 208, 6, "Çamlıdere" },
                    { 209, 53, "Çamlıhemşin" },
                    { 210, 33, "Çamlıyayla" },
                    { 211, 28, "Çamoluk" },
                    { 212, 17, "Çan" },
                    { 213, 28, "Çanakçı" },
                    { 214, 17, "Çanakkale" },
                    { 215, 66, "Çandır" },
                    { 216, 6, "Çankaya" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 217, 18, "Çankırı" },
                    { 218, 20, "Çardak" },
                    { 219, 55, "Çarşamba" },
                    { 220, 61, "Çarşıbaşı" },
                    { 221, 25, "Çat" },
                    { 222, 65, "Çatak" },
                    { 223, 34, "Çatalca" },
                    { 224, 52, "Çatalpınar" },
                    { 225, 37, "Çatalzeytin" },
                    { 226, 43, "Çavdarhisar" },
                    { 227, 15, "Çavdır" },
                    { 228, 3, "Çay" },
                    { 229, 52, "Çaybaşı" },
                    { 230, 67, "Çaycuma" },
                    { 231, 53, "Çayeli" },
                    { 232, 66, "Çayıralan" },
                    { 233, 24, "Çayırlı" },
                    { 234, 41, "Çayırova" },
                    { 235, 61, "Çaykara" },
                    { 236, 66, "Çekerek" },
                    { 237, 34, "Çekmeköy" },
                    { 238, 71, "Çelebi" },
                    { 239, 2, "Çelikhan" },
                    { 240, 42, "Çeltik" },
                    { 241, 15, "Çeltikçi" },
                    { 242, 62, "Çemişgezek" },
                    { 243, 18, "Çerkeş" },
                    { 244, 59, "Çerkezköy" },
                    { 245, 21, "Çermik" },
                    { 246, 35, "Çeşme" },
                    { 247, 75, "Çıldır" },
                    { 248, 21, "Çınar" },
                    { 249, 77, "Çınarcık" },
                    { 250, 40, "Çiçekdağı" },
                    { 251, 26, "Çifteler" },
                    { 252, 51, "Çiftlik" },
                    { 253, 77, "Çiftlikköy" },
                    { 254, 35, "Çiğli" },
                    { 255, 81, "Çilimli" },
                    { 256, 9, "Çine" },
                    { 257, 20, "Çivril" },
                    { 258, 3, "Çobanlar" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 259, 59, "Çorlu" },
                    { 260, 19, "Çorum" },
                    { 261, 6, "Çubuk" },
                    { 262, 30, "Çukurca" },
                    { 263, 1, "Çukurova" },
                    { 264, 42, "Çumra" },
                    { 265, 21, "Çüngüş" },
                    { 266, 37, "Daday" },
                    { 267, 48, "Dalaman" },
                    { 268, 75, "Damal" },
                    { 269, 44, "Darende" },
                    { 270, 47, "Dargeçit" },
                    { 271, 41, "Darıca" },
                    { 272, 48, "Datça" },
                    { 273, 3, "Dazkırı" },
                    { 274, 31, "Defne" },
                    { 275, 71, "Delice" },
                    { 276, 45, "Demirci" },
                    { 277, 39, "Demirköy" },
                    { 278, 69, "Demirözü" },
                    { 279, 7, "Demre" },
                    { 280, 42, "Derbent" },
                    { 281, 42, "Derebucak" },
                    { 282, 28, "Dereli" },
                    { 283, 53, "Derepazarı" },
                    { 284, 47, "Derik" },
                    { 285, 41, "Derince" },
                    { 286, 50, "Derinkuyu" },
                    { 287, 61, "Dernekpazarı" },
                    { 288, 38, "Develi" },
                    { 289, 67, "Devrek" },
                    { 290, 37, "Devrekani" },
                    { 291, 21, "Dicle" },
                    { 292, 9, "Didim" },
                    { 293, 36, "Digor" },
                    { 294, 35, "Dikili" },
                    { 295, 57, "Dikmen" },
                    { 296, 41, "Dilovası" },
                    { 297, 3, "Dinar" },
                    { 298, 58, "Divriği" },
                    { 299, 4, "Diyadin" },
                    { 300, 19, "Dodurga" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 301, 42, "Doğanhisar" },
                    { 302, 28, "Doğankent" },
                    { 303, 58, "Doğanşar" },
                    { 304, 44, "Doğanşehir" },
                    { 305, 44, "Doğanyol" },
                    { 306, 37, "Doğanyurt" },
                    { 307, 4, "Doğubayazıt" },
                    { 308, 43, "Domaniç" },
                    { 309, 14, "Dörtdivan" },
                    { 310, 31, "Dörtyol" },
                    { 311, 7, "Döşemealtı" },
                    { 312, 46, "Dulkadiroğlu" },
                    { 313, 43, "Dumlupınar" },
                    { 314, 57, "Durağan" },
                    { 315, 10, "Dursunbey" },
                    { 316, 81, "Düzce" },
                    { 317, 80, "Düziçi" },
                    { 318, 61, "Düzköy" },
                    { 319, 17, "Eceabat" },
                    { 320, 22, "Edirne" },
                    { 321, 10, "Edremit" },
                    { 322, 65, "Edremit" },
                    { 323, 9, "Efeler" },
                    { 324, 78, "Eflani" },
                    { 325, 21, "Eğil" },
                    { 326, 32, "Eğirdir" },
                    { 327, 46, "Ekinözü" },
                    { 328, 23, "Elazığ" },
                    { 329, 79, "Elbeyli" },
                    { 330, 46, "Elbistan" },
                    { 331, 18, "Eldivan" },
                    { 332, 4, "Eleşkirt" },
                    { 333, 6, "Elmadağ" },
                    { 334, 7, "Elmalı" },
                    { 335, 43, "Emet" },
                    { 336, 3, "Emirdağ" },
                    { 337, 42, "Emirgazi" },
                    { 338, 22, "Enez" },
                    { 339, 60, "Erbaa" },
                    { 340, 65, "Erciş" },
                    { 341, 10, "Erdek" },
                    { 342, 33, "Erdemli" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 343, 42, "Ereğli" },
                    { 344, 67, "Ereğli" },
                    { 345, 54, "Erenler" },
                    { 346, 57, "Erfelek" },
                    { 347, 21, "Ergani" },
                    { 348, 59, "Ergene" },
                    { 349, 70, "Ermenek" },
                    { 350, 56, "Eruh" },
                    { 351, 31, "Erzin" },
                    { 352, 24, "Erzincan" },
                    { 353, 34, "Esenler" },
                    { 354, 34, "Esenyurt" },
                    { 355, 68, "Eskil" },
                    { 356, 78, "Eskipazar" },
                    { 357, 28, "Espiye" },
                    { 358, 64, "Eşme" },
                    { 359, 6, "Etimesgut" },
                    { 360, 3, "Evciler" },
                    { 361, 6, "Evren" },
                    { 362, 28, "Eynesil" },
                    { 363, 34, "Eyüp" },
                    { 364, 63, "Eyyübiye" },
                    { 365, 17, "Ezine" },
                    { 366, 34, "Fatih" },
                    { 367, 52, "Fatsa" },
                    { 368, 1, "Feke" },
                    { 369, 38, "Felahiye" },
                    { 370, 54, "Ferizli" },
                    { 371, 48, "Fethiye" },
                    { 372, 53, "Fındıklı" },
                    { 373, 7, "Finike" },
                    { 374, 35, "Foça" },
                    { 375, 35, "Gaziemir" },
                    { 376, 34, "Gaziosmanpaşa" },
                    { 377, 7, "Gazipaşa" },
                    { 378, 41, "Gebze" },
                    { 379, 43, "Gediz" },
                    { 380, 32, "Gelendost" },
                    { 381, 17, "Gelibolu" },
                    { 382, 58, "Gemerek" },
                    { 383, 16, "Gemlik" },
                    { 384, 12, "Genç" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 385, 72, "Gercüş" },
                    { 386, 14, "Gerede" },
                    { 387, 2, "Gerger" },
                    { 388, 9, "Germencik" },
                    { 389, 57, "Gerze" },
                    { 390, 65, "Gevaş" },
                    { 391, 54, "Geyve" },
                    { 392, 28, "Giresun" },
                    { 393, 17, "Gökçeada" },
                    { 394, 67, "Gökçebey" },
                    { 395, 46, "Göksun" },
                    { 396, 2, "Gölbaşı" },
                    { 397, 6, "Gölbaşı" },
                    { 398, 41, "Gölcük" },
                    { 399, 75, "Göle" },
                    { 400, 15, "Gölhisar" },
                    { 401, 52, "Gölköy" },
                    { 402, 45, "Gölmarmara" },
                    { 403, 58, "Gölova" },
                    { 404, 11, "Gölpazarı" },
                    { 405, 81, "Gölyaka" },
                    { 406, 10, "Gömeç" },
                    { 407, 10, "Gönen" },
                    { 408, 32, "Gönen" },
                    { 409, 45, "Gördes" },
                    { 410, 28, "Görele" },
                    { 411, 5, "Göynücek" },
                    { 412, 14, "Göynük" },
                    { 413, 28, "Güce" },
                    { 414, 73, "Güçlükonak" },
                    { 415, 6, "Güdül" },
                    { 416, 68, "Gülağaç" },
                    { 417, 33, "Gülnar" },
                    { 418, 50, "Gülşehir" },
                    { 419, 52, "Gülyalı" },
                    { 420, 5, "Gümüşhacıköy" },
                    { 421, 29, "Gümüşhane" },
                    { 422, 81, "Gümüşova" },
                    { 423, 7, "Gündoğmuş" },
                    { 424, 20, "Güney" },
                    { 425, 42, "Güneysınır" },
                    { 426, 53, "Güneysu" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 427, 34, "Güngören" },
                    { 428, 26, "Günyüzü" },
                    { 429, 52, "Gürgentepe" },
                    { 430, 13, "Güroymak" },
                    { 431, 65, "Gürpınar" },
                    { 432, 16, "Gürsu" },
                    { 433, 58, "Gürün" },
                    { 434, 35, "Güzelbahçe" },
                    { 435, 68, "Güzelyurt" },
                    { 436, 50, "Hacıbektaş" },
                    { 437, 38, "Hacılar" },
                    { 438, 42, "Hadim" },
                    { 439, 58, "Hafik" },
                    { 440, 30, "Hakkâri" },
                    { 441, 63, "Halfeti" },
                    { 442, 63, "Haliliye" },
                    { 443, 42, "Halkapınar" },
                    { 444, 5, "Hamamözü" },
                    { 445, 4, "Hamur" },
                    { 446, 26, "Han" },
                    { 447, 75, "Hanak" },
                    { 448, 21, "Hani" },
                    { 449, 37, "Hanönü" },
                    { 450, 16, "Harmancık" },
                    { 451, 63, "Harran" },
                    { 452, 80, "Hasanbeyli" },
                    { 453, 72, "Hasankeyf" },
                    { 454, 49, "Hasköy" },
                    { 455, 31, "Hassa" },
                    { 456, 10, "Havran" },
                    { 457, 22, "Havsa" },
                    { 458, 55, "Havza" },
                    { 459, 6, "Haymana" },
                    { 460, 59, "Hayrabolu" },
                    { 461, 61, "Hayrat" },
                    { 462, 21, "Hazro" },
                    { 463, 44, "Hekimhan" },
                    { 464, 53, "Hemşin" },
                    { 465, 54, "Hendek" },
                    { 466, 25, "Hınıs" },
                    { 467, 63, "Hilvan" },
                    { 468, 43, "Hisarcık" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 469, 13, "Hizan" },
                    { 470, 3, "Hocalar" },
                    { 471, 20, "Honaz" },
                    { 472, 8, "Hopa" },
                    { 473, 25, "Horasan" },
                    { 474, 62, "Hozat" },
                    { 475, 42, "Hüyük" },
                    { 476, 76, "Iğdır" },
                    { 477, 18, "Ilgaz" },
                    { 478, 42, "Ilgın" },
                    { 479, 32, "Isparta" },
                    { 480, 7, "İbradı" },
                    { 481, 73, "İdil" },
                    { 482, 37, "İhsangazi" },
                    { 483, 3, "İhsaniye" },
                    { 484, 52, "İkizce" },
                    { 485, 53, "İkizdere" },
                    { 486, 24, "İliç" },
                    { 487, 55, "İlkadım" },
                    { 488, 1, "İmamoğlu" },
                    { 489, 58, "İmranlı" },
                    { 490, 38, "İncesu" },
                    { 491, 9, "İncirliova" },
                    { 492, 37, "İnebolu" },
                    { 493, 16, "İnegöl" },
                    { 494, 11, "İnhisar" },
                    { 495, 26, "İnönü" },
                    { 496, 65, "İpekyolu" },
                    { 497, 22, "İpsala" },
                    { 498, 3, "İscehisar" },
                    { 499, 31, "İskenderun" },
                    { 500, 19, "İskilip" },
                    { 501, 27, "İslahiye" },
                    { 502, 25, "İspir" },
                    { 503, 10, "İvrindi" },
                    { 504, 53, "İyidere" },
                    { 505, 41, "İzmit" },
                    { 506, 16, "İznik" },
                    { 507, 52, "Kabadüz" },
                    { 508, 52, "Kabataş" },
                    { 509, 34, "Kadıköy" },
                    { 510, 42, "Kadınhanı" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 511, 66, "Kadışehri" },
                    { 512, 80, "Kadirli" },
                    { 513, 34, "Kağıthane" },
                    { 514, 36, "Kağızman" },
                    { 515, 2, "Kahta" },
                    { 516, 20, "Kale" },
                    { 517, 44, "Kale" },
                    { 518, 6, "Kalecik" },
                    { 519, 53, "Kalkandere" },
                    { 520, 40, "Kaman" },
                    { 521, 41, "Kandıra" },
                    { 522, 58, "Kangal" },
                    { 523, 59, "Kapaklı" },
                    { 524, 35, "Karabağlar" },
                    { 525, 35, "Karaburun" },
                    { 526, 78, "Karabük" },
                    { 527, 16, "Karacabey" },
                    { 528, 9, "Karacasu" },
                    { 529, 25, "Karaçoban" },
                    { 530, 64, "Karahallı" },
                    { 531, 1, "Karaisalı" },
                    { 532, 71, "Karakeçili" },
                    { 533, 23, "Karakoçan" },
                    { 534, 76, "Karakoyunlu" },
                    { 535, 63, "Karaköprü" },
                    { 536, 70, "Karaman" },
                    { 537, 15, "Karamanlı" },
                    { 538, 41, "Karamürsel" },
                    { 539, 42, "Karapınar" },
                    { 540, 54, "Karapürçek" },
                    { 541, 54, "Karasu" },
                    { 542, 1, "Karataş" },
                    { 543, 42, "Karatay" },
                    { 544, 25, "Karayazı" },
                    { 545, 10, "Karesi" },
                    { 546, 19, "Kargı" },
                    { 547, 27, "Karkamış" },
                    { 548, 12, "Karlıova" },
                    { 549, 9, "Karpuzlu" },
                    { 550, 36, "Kars" },
                    { 551, 35, "Karşıyaka" },
                    { 552, 34, "Kartal" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 553, 41, "Kartepe" },
                    { 554, 37, "Kastamonu" },
                    { 555, 7, "Kaş" },
                    { 556, 55, "Kavak" },
                    { 557, 48, "Kavaklıdere" },
                    { 558, 21, "Kayapınar" },
                    { 559, 54, "Kaynarca" },
                    { 560, 81, "Kaynaşlı" },
                    { 561, 6, "Kazan" },
                    { 562, 70, "Kazımkarabekir" },
                    { 563, 23, "Keban" },
                    { 564, 32, "Keçiborlu" },
                    { 565, 6, "Keçiören" },
                    { 566, 16, "Keles" },
                    { 567, 29, "Kelkit" },
                    { 568, 24, "Kemah" },
                    { 569, 24, "Kemaliye" },
                    { 570, 35, "Kemalpaşa" },
                    { 571, 7, "Kemer" },
                    { 572, 15, "Kemer" },
                    { 573, 7, "Kepez" },
                    { 574, 10, "Kepsut" },
                    { 575, 71, "Keskin" },
                    { 576, 16, "Kestel" },
                    { 577, 22, "Keşan" },
                    { 578, 28, "Keşap" },
                    { 579, 14, "Kıbrıscık" },
                    { 580, 35, "Kınık" },
                    { 581, 31, "Kırıkhan" },
                    { 582, 71, "Kırıkkale" },
                    { 583, 45, "Kırkağaç" },
                    { 584, 39, "Kırklareli" },
                    { 585, 40, "Kırşehir" },
                    { 586, 6, "Kızılcahamam" },
                    { 587, 18, "Kızılırmak" },
                    { 588, 3, "Kızılören" },
                    { 589, 47, "Kızıltepe" },
                    { 590, 12, "Kiğı" },
                    { 591, 67, "Kilimli" },
                    { 592, 79, "Kilis" },
                    { 593, 35, "Kiraz" },
                    { 594, 54, "Kocaali" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 595, 21, "Kocaköy" },
                    { 596, 38, "Kocasinan" },
                    { 597, 9, "Koçarlı" },
                    { 598, 39, "Kofçaz" },
                    { 599, 35, "Konak" },
                    { 600, 7, "Konyaaltı" },
                    { 601, 52, "Korgan" },
                    { 602, 18, "Korgun" },
                    { 603, 49, "Korkut" },
                    { 604, 7, "Korkuteli" },
                    { 605, 23, "Kovancılar" },
                    { 606, 58, "Koyulhisar" },
                    { 607, 50, "Kozaklı" },
                    { 608, 1, "Kozan" },
                    { 609, 67, "Kozlu" },
                    { 610, 72, "Kozluk" },
                    { 611, 45, "Köprübaşı" },
                    { 612, 61, "Köprübaşı" },
                    { 613, 25, "Köprüköy" },
                    { 614, 41, "Körfez" },
                    { 615, 29, "Köse" },
                    { 616, 9, "Köşk" },
                    { 617, 48, "Köyceğiz" },
                    { 618, 45, "Kula" },
                    { 619, 21, "Kulp" },
                    { 620, 42, "Kulu" },
                    { 621, 44, "Kuluncak" },
                    { 622, 31, "Kumlu" },
                    { 623, 7, "Kumluca" },
                    { 624, 52, "Kumru" },
                    { 625, 18, "Kurşunlu" },
                    { 626, 56, "Kurtalan" },
                    { 627, 74, "Kurucaşile" },
                    { 628, 9, "Kuşadası" },
                    { 629, 9, "Kuyucak" },
                    { 630, 34, "Küçükçekmece" },
                    { 631, 37, "Küre" },
                    { 632, 29, "Kürtün" },
                    { 633, 43, "Kütahya" },
                    { 634, 19, "Laçin" },
                    { 635, 55, "Ladik" },
                    { 636, 22, "Lalapaşa" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 637, 17, "Lapseki" },
                    { 638, 21, "Lice" },
                    { 639, 39, "Lüleburgaz" },
                    { 640, 61, "Maçka" },
                    { 641, 23, "Maden" },
                    { 642, 26, "Mahmudiye" },
                    { 643, 49, "Malazgirt" },
                    { 644, 59, "Malkara" },
                    { 645, 34, "Maltepe" },
                    { 646, 6, "Mamak" },
                    { 647, 7, "Manavgat" },
                    { 648, 10, "Manyas" },
                    { 649, 10, "Marmara" },
                    { 650, 59, "Marmaraereğlisi" },
                    { 651, 48, "Marmaris" },
                    { 652, 62, "Mazgirt" },
                    { 653, 47, "Mazıdağı" },
                    { 654, 19, "Mecitözü" },
                    { 655, 38, "Melikgazi" },
                    { 656, 35, "Menderes" },
                    { 657, 35, "Menemen" },
                    { 658, 14, "Mengen" },
                    { 659, 48, "Menteşe" },
                    { 660, 42, "Meram" },
                    { 661, 22, "Meriç" },
                    { 662, 20, "Merkezefendi" },
                    { 663, 5, "Merzifon" },
                    { 664, 52, "Mesudiye" },
                    { 665, 33, "Mezitli" },
                    { 666, 47, "Midyat" },
                    { 667, 26, "Mihalgazi" },
                    { 668, 26, "Mihalıççık" },
                    { 669, 48, "Milas" },
                    { 670, 40, "Mucur" },
                    { 671, 16, "Mudanya" },
                    { 672, 14, "Mudurnu" },
                    { 673, 65, "Muradiye" },
                    { 674, 59, "Muratlı" },
                    { 675, 7, "Muratpaşa" },
                    { 676, 8, "Murgul" },
                    { 677, 79, "Musabeyli" },
                    { 678, 16, "Mustafakemalpaşa" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 679, 49, "Muş" },
                    { 680, 33, "Mut" },
                    { 681, 13, "Mutki" },
                    { 682, 6, "Nallıhan" },
                    { 683, 35, "Narlıdere" },
                    { 684, 25, "Narman" },
                    { 685, 62, "Nazımiye" },
                    { 686, 9, "Nazilli" },
                    { 687, 50, "Nevşehir" },
                    { 688, 51, "Niğde" },
                    { 689, 60, "Niksar" },
                    { 690, 16, "Nilüfer" },
                    { 691, 27, "Nizip" },
                    { 692, 27, "Nurdağı" },
                    { 693, 46, "Nurhak" },
                    { 694, 47, "Nusaybin" },
                    { 695, 26, "Odunpazarı" },
                    { 696, 61, "Of" },
                    { 697, 27, "Oğuzeli" },
                    { 698, 19, "Oğuzlar" },
                    { 699, 25, "Oltu" },
                    { 700, 25, "Olur" },
                    { 701, 55, "Ondokuzmayıs" },
                    { 702, 46, "Onikişubat" },
                    { 703, 16, "Orhaneli" },
                    { 704, 16, "Orhangazi" },
                    { 705, 18, "Orta" },
                    { 706, 48, "Ortaca" },
                    { 707, 61, "Ortahisar" },
                    { 708, 68, "Ortaköy" },
                    { 709, 19, "Ortaköy" },
                    { 710, 19, "Osmancık" },
                    { 711, 11, "Osmaneli" },
                    { 712, 16, "Osmangazi" },
                    { 713, 80, "Osmaniye" },
                    { 714, 24, "Otlukbeli" },
                    { 715, 78, "Ovacık" },
                    { 716, 62, "Ovacık" },
                    { 717, 35, "Ödemiş" },
                    { 718, 47, "Ömerli" },
                    { 719, 65, "Özalp" },
                    { 720, 38, "Özvatan" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 721, 25, "Palandöken" },
                    { 722, 23, "Palu" },
                    { 723, 20, "Pamukkale" },
                    { 724, 54, "Pamukova" },
                    { 725, 25, "Pasinler" },
                    { 726, 4, "Patnos" },
                    { 727, 31, "Payas" },
                    { 728, 53, "Pazar" },
                    { 729, 60, "Pazar" },
                    { 730, 46, "Pazarcık" },
                    { 731, 43, "Pazarlar" },
                    { 732, 11, "Pazaryeri" },
                    { 733, 25, "Pazaryolu" },
                    { 734, 39, "Pehlivanköy" },
                    { 735, 34, "Pendik" },
                    { 736, 52, "Perşembe" },
                    { 737, 62, "Pertek" },
                    { 738, 56, "Pervari" },
                    { 739, 37, "Pınarbaşı" },
                    { 740, 38, "Pınarbaşı" },
                    { 741, 39, "Pınarhisar" },
                    { 742, 28, "Piraziz" },
                    { 743, 79, "Polateli" },
                    { 744, 6, "Polatlı" },
                    { 745, 75, "Posof" },
                    { 746, 1, "Pozantı" },
                    { 747, 6, "Pursaklar" },
                    { 748, 62, "Pülümür" },
                    { 749, 44, "Pütürge" },
                    { 750, 24, "Refahiye" },
                    { 751, 60, "Reşadiye" },
                    { 752, 31, "Reyhanlı" },
                    { 753, 53, "Rize" },
                    { 754, 78, "Safranbolu" },
                    { 755, 1, "Saimbeyli" },
                    { 756, 55, "Salıpazarı" },
                    { 757, 45, "Salihli" },
                    { 758, 31, "Samandağ" },
                    { 759, 2, "Samsat" },
                    { 760, 34, "Sancaktepe" },
                    { 761, 3, "Sandıklı" },
                    { 762, 54, "Sapanca" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 763, 59, "Saray" },
                    { 764, 65, "Saray" },
                    { 765, 57, "Saraydüzü" },
                    { 766, 66, "Saraykent" },
                    { 767, 20, "Sarayköy" },
                    { 768, 42, "Sarayönü" },
                    { 769, 26, "Sarıcakaya" },
                    { 770, 1, "Sarıçam" },
                    { 771, 45, "Sarıgöl" },
                    { 772, 36, "Sarıkamış" },
                    { 773, 66, "Sarıkaya" },
                    { 774, 38, "Sarıoğlan" },
                    { 775, 70, "Sarıveliler" },
                    { 776, 68, "Sarıyahşi" },
                    { 777, 34, "Sarıyer" },
                    { 778, 38, "Sarız" },
                    { 779, 45, "Saruhanlı" },
                    { 780, 72, "Sason" },
                    { 781, 10, "Savaştepe" },
                    { 782, 47, "Savur" },
                    { 783, 14, "Seben" },
                    { 784, 35, "Seferihisar" },
                    { 785, 35, "Selçuk" },
                    { 786, 42, "Selçuklu" },
                    { 787, 45, "Selendi" },
                    { 788, 36, "Selim" },
                    { 789, 32, "Senirkent" },
                    { 790, 54, "Serdivan" },
                    { 791, 7, "Serik" },
                    { 792, 20, "Serinhisar" },
                    { 793, 48, "Seydikemer" },
                    { 794, 37, "Seydiler" },
                    { 795, 42, "Seydişehir" },
                    { 796, 1, "Seyhan" },
                    { 797, 26, "Seyitgazi" },
                    { 798, 10, "Sındırgı" },
                    { 799, 56, "Siirt" },
                    { 800, 33, "Silifke" },
                    { 801, 34, "Silivri" },
                    { 802, 73, "Silopi" },
                    { 803, 21, "Silvan" },
                    { 804, 43, "Simav" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 805, 3, "Sinanpaşa" },
                    { 806, 6, "Sincan" },
                    { 807, 2, "Sincik" },
                    { 808, 57, "Sinop" },
                    { 809, 58, "Sivas" },
                    { 810, 64, "Sivaslı" },
                    { 811, 63, "Siverek" },
                    { 812, 23, "Sivrice" },
                    { 813, 26, "Sivrihisar" },
                    { 814, 12, "Solhan" },
                    { 815, 45, "Soma" },
                    { 816, 66, "Sorgun" },
                    { 817, 11, "Söğüt" },
                    { 818, 54, "Söğütlü" },
                    { 819, 9, "Söke" },
                    { 820, 71, "Sulakyurt" },
                    { 821, 34, "Sultanbeyli" },
                    { 822, 3, "Sultandağı" },
                    { 823, 34, "Sultangazi" },
                    { 824, 9, "Sultanhisar" },
                    { 825, 5, "Suluova" },
                    { 826, 60, "Sulusaray" },
                    { 827, 80, "Sumbas" },
                    { 828, 19, "Sungurlu" },
                    { 829, 21, "Sur" },
                    { 830, 63, "Suruç" },
                    { 831, 10, "Susurluk" },
                    { 832, 36, "Susuz" },
                    { 833, 58, "Suşehri" },
                    { 834, 59, "Süleymanpaşa" },
                    { 835, 22, "Süloğlu" },
                    { 836, 61, "Sürmene" },
                    { 837, 32, "Sütçüler" },
                    { 838, 18, "Şabanözü" },
                    { 839, 27, "Şahinbey" },
                    { 840, 61, "Şalpazarı" },
                    { 841, 43, "Şaphane" },
                    { 842, 58, "Şarkışla" },
                    { 843, 32, "Şarkikaraağaç" },
                    { 844, 59, "Şarköy" },
                    { 845, 8, "Şavşat" },
                    { 846, 28, "Şebinkarahisar" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 847, 66, "Şefaatli" },
                    { 848, 27, "Şehitkamil" },
                    { 849, 45, "Şehzadeler" },
                    { 850, 30, "Şemdinli" },
                    { 851, 25, "Şenkaya" },
                    { 852, 37, "Şenpazar" },
                    { 853, 6, "Şereflikoçhisar" },
                    { 854, 73, "Şırnak" },
                    { 855, 34, "Şile" },
                    { 856, 29, "Şiran" },
                    { 857, 56, "Şirvan" },
                    { 858, 34, "Şişli" },
                    { 859, 3, "Şuhut" },
                    { 860, 38, "Talas" },
                    { 861, 54, "Taraklı" },
                    { 862, 33, "Tarsus" },
                    { 863, 42, "Taşkent" },
                    { 864, 37, "Taşköprü" },
                    { 865, 4, "Taşlıçay" },
                    { 866, 5, "Taşova" },
                    { 867, 13, "Tatvan" },
                    { 868, 20, "Tavas" },
                    { 869, 43, "Tavşanlı" },
                    { 870, 15, "Tefenni" },
                    { 871, 55, "Tekkeköy" },
                    { 872, 25, "Tekman" },
                    { 873, 26, "Tepebaşı" },
                    { 874, 24, "Tercan" },
                    { 875, 77, "Termal" },
                    { 876, 55, "Terme" },
                    { 877, 56, "Tillo" },
                    { 878, 35, "Tire" },
                    { 879, 28, "Tirebolu" },
                    { 880, 60, "Tokat" },
                    { 881, 38, "Tomarza" },
                    { 882, 61, "Tonya" },
                    { 883, 80, "Toprakkale" },
                    { 884, 35, "Torbalı" },
                    { 885, 33, "Toroslar" },
                    { 886, 25, "Tortum" },
                    { 887, 29, "Torul" },
                    { 888, 37, "Tosya" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 889, 1, "Tufanbeyli" },
                    { 890, 62, "Tunceli" },
                    { 891, 45, "Turgutlu" },
                    { 892, 60, "Turhal" },
                    { 893, 65, "Tuşba" },
                    { 894, 2, "Tut" },
                    { 895, 4, "Tutak" },
                    { 896, 34, "Tuzla" },
                    { 897, 76, "Tuzluca" },
                    { 898, 42, "Tuzlukçu" },
                    { 899, 57, "Türkeli" },
                    { 900, 46, "Türkoğlu" },
                    { 901, 19, "Uğurludağ" },
                    { 902, 48, "Ula" },
                    { 903, 58, "Ulaş" },
                    { 904, 52, "Ulubey" },
                    { 905, 64, "Ulubey" },
                    { 906, 32, "Uluborlu" },
                    { 907, 73, "Uludere" },
                    { 908, 51, "Ulukışla" },
                    { 909, 74, "Ulus" },
                    { 910, 35, "Urla" },
                    { 911, 64, "Uşak" },
                    { 912, 25, "Uzundere" },
                    { 913, 22, "Uzunköprü" },
                    { 914, 34, "Ümraniye" },
                    { 915, 52, "Ünye" },
                    { 916, 50, "Ürgüp" },
                    { 917, 34, "Üsküdar" },
                    { 918, 24, "Üzümlü" },
                    { 919, 61, "Vakfıkebir" },
                    { 920, 49, "Varto" },
                    { 921, 55, "Vezirköprü" },
                    { 922, 63, "Viranşehir" },
                    { 923, 39, "Vize" },
                    { 924, 28, "Yağlıdere" },
                    { 925, 71, "Yahşihan" },
                    { 926, 38, "Yahyalı" },
                    { 927, 55, "Yakakent" },
                    { 928, 25, "Yakutiye" },
                    { 929, 42, "Yalıhüyük" },
                    { 930, 77, "Yalova" }
                });

            migrationBuilder.InsertData(
                table: "İlçeler",
                columns: new[] { "İlçeID", "İlID", "İlçeAdı" },
                values: new object[,]
                {
                    { 931, 32, "Yalvaç" },
                    { 932, 18, "Yapraklı" },
                    { 933, 48, "Yatağan" },
                    { 934, 27, "Yavuzeli" },
                    { 935, 31, "Yayladağı" },
                    { 936, 12, "Yayladere" },
                    { 937, 44, "Yazıhan" },
                    { 938, 12, "Yedisu" },
                    { 939, 17, "Yenice" },
                    { 940, 78, "Yenice" },
                    { 941, 14, "Yeniçağa" },
                    { 942, 66, "Yenifakılı" },
                    { 943, 6, "Yenimahalle" },
                    { 944, 9, "Yenipazar" },
                    { 945, 11, "Yenipazar" },
                    { 946, 32, "Yenişarbademli" },
                    { 947, 16, "Yenişehir" },
                    { 948, 21, "Yenişehir" },
                    { 949, 33, "Yenişehir" },
                    { 950, 66, "Yerköy" },
                    { 951, 38, "Yeşilhisar" },
                    { 952, 47, "Yeşilli" },
                    { 953, 15, "Yeşilova" },
                    { 954, 44, "Yeşilyurt" },
                    { 955, 60, "Yeşilyurt" },
                    { 956, 81, "Yığılca" },
                    { 957, 16, "Yıldırım" },
                    { 958, 58, "Yıldızeli" },
                    { 959, 61, "Yomra" },
                    { 960, 66, "Yozgat" },
                    { 961, 1, "Yumurtalık" },
                    { 962, 42, "Yunak" },
                    { 963, 45, "Yunusemre" },
                    { 964, 8, "Yusufeli" },
                    { 965, 30, "Yüksekova" },
                    { 966, 1, "Yüreğir" },
                    { 967, 58, "Zara" },
                    { 968, 34, "Zeytinburnu" },
                    { 969, 60, "Zile" },
                    { 970, 67, "Zonguldak" },
                    { 971, 8, " Kemalpaşa" },
                    { 972, 68, " Sultanhanı" }
                });

            migrationBuilder.InsertData(
                table: "Adresler",
                columns: new[] { "AdresID", "AdresAdı", "AdresDetay", "KullanıcıID", "PostaKodu", "İlçeID" },
                values: new object[,]
                {
                    { 1, "Evim", "Menekşe Mah. Petek Sk. No:31 Kat:3 Daire:6", 12, "09200", 1 },
                    { 2, "Annemim Ev", "Küpçüler Mah. Sema Sk. No:28 Kat:2 Daire:2", 17, "09200", 1 },
                    { 3, "Evim", "Menekşe Mah. Petek Sk. No:31 Kat:3 Daire:6", 12, "09200", 1 },
                    { 4, "Annemim Ev", "Küpçüler Mah. Sema Sk. No:28 Kat:2 Daire:2", 17, "09200", 46 },
                    { 5, "Ofisim", "Eskiler Cad. Fırın Sk. No:38 Pendik", 17, "09200", 1 },
                    { 6, "Kendi Evim", "Çakmak Cad. Turgut Özal Sk. No:16 Kat:1 Daire:13", 16, "09200", 1 },
                    { 7, "Kardeşim", "Yedi İklim Mah. Güngören Cad. Lacivert Sk. No:45 Kat:3 Daire:7", 57, "09200", 1 },
                    { 8, "Kendi Evim", "Çakmak Cad. Turgut Özal Sk. No:16 Kat:1 Daire:13", 16, "09200", 10 },
                    { 9, "Kardeşim", "Yedi İklim Mah. Güngören Cad. Lacivert Sk. No:45 Kat:3 Daire:7", 57, null, 77 }
                });

            migrationBuilder.InsertData(
                table: "Kişiler",
                columns: new[] { "KişiID", "AdVeİkinciAd", "CinsiyetID", "DogumTarihi", "KullanıcıID", "Soyad", "İlID" },
                values: new object[,]
                {
                    { 1, "Serdal", 1, new DateTime(1996, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Güler", 14 },
                    { 2, "İlhan", 1, new DateTime(1998, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Saglam", 14 },
                    { 3, "Sinan", 1, new DateTime(2005, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülmez", 14 }
                });

            migrationBuilder.InsertData(
                table: "MedeniBilgiler",
                columns: new[] { "MedeniBilgiID", "KullanıcıID", "MedeniDurumID", "ÇocukSayısı" },
                values: new object[] { 1, 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "İhtiyaçlar",
                columns: new[] { "İhtiyaçID", "Açıklama", "KullanıcıID", "İhtiyaçAdı", "İhtiyaçSıklığıID" },
                values: new object[,]
                {
                    { 1, "Mutfak masraflarım için paraya ihtiyacım var.", 12, "Mutfak", 1 },
                    { 2, "2 cocuğum var eğitimleri için maddi desteğe ihtiyacım var.", 12, "Eğitim", 2 },
                    { 3, "Sokak hayvanları için mama yardımı için para lazım", 12, "Mama", 2 },
                    { 4, "zamlardan sonra faturalamı ödemekte güçlük çekiyorum", 12, "fatura", 1 },
                    { 5, "Nişanlım düğün yapmassak beni terkedecek acil para lazım", 17, "Düğün", 2 },
                    { 6, "Cocuğum kanser hastası tedavisi için maddi desteğe ihtiyacım var", 17, "Hastalık", 1 },
                    { 7, "Kış şartlarından dolayı monta ihtiyacım var", 12, "Giyim", 2 },
                    { 8, "Evdeki koltuk takımının yenisine ihtiyacım var", 17, "Mobilya", 1 },
                    { 9, "Telefonum eskidi yenisine ihtiyacım var", 17, "Telefon", 1 },
                    { 10, "Çocuğumun online dersleri için Laptopa ihtiyacım var", 17, "Laptop", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_İlçeID",
                table: "Adresler",
                column: "İlçeID");

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_KullanıcıID",
                table: "Adresler",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_BankaID",
                table: "Hesaplar",
                column: "BankaID");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_KullanıcıID",
                table: "Hesaplar",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_İhtiyaçlar_İhtiyaçSıklığıID",
                table: "İhtiyaçlar",
                column: "İhtiyaçSıklığıID");

            migrationBuilder.CreateIndex(
                name: "IX_İhtiyaçlar_KullanıcıID",
                table: "İhtiyaçlar",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_İlçeler_İlID",
                table: "İlçeler",
                column: "İlID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_CinsiyetID",
                table: "Kişiler",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_İlID",
                table: "Kişiler",
                column: "İlID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_KullanıcıID",
                table: "Kişiler",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_RolID",
                table: "Kullanıcılar",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_MedeniBilgiler_KullanıcıID",
                table: "MedeniBilgiler",
                column: "KullanıcıID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedeniBilgiler_MedeniDurumID",
                table: "MedeniBilgiler",
                column: "MedeniDurumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresler");

            migrationBuilder.DropTable(
                name: "Hesaplar");

            migrationBuilder.DropTable(
                name: "İhtiyaçlar");

            migrationBuilder.DropTable(
                name: "Kişiler");

            migrationBuilder.DropTable(
                name: "MedeniBilgiler");

            migrationBuilder.DropTable(
                name: "İlçeler");

            migrationBuilder.DropTable(
                name: "Bankalar");

            migrationBuilder.DropTable(
                name: "İhtiyaçSıklıkları");

            migrationBuilder.DropTable(
                name: "Cinsiyetler");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "MedeniDurumlar");

            migrationBuilder.DropTable(
                name: "İller");

            migrationBuilder.DropTable(
                name: "Roller");
        }
    }
}
