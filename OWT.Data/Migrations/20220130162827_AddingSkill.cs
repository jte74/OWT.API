using Microsoft.EntityFrameworkCore.Migrations;

namespace OWT.Data.Migrations
{
    public partial class AddingSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactSkill",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSkill", x => new { x.SkillId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_ContactSkill_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Address", "Email", "FirstName", "FullName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "13 rue des pinsons", "julien.tellier74@mail.com", "Julien", "JulienTellier", "Tellier", "0672222667" },
                    { 2, "13 rue des lilas", "Alfred.tellier74@mail.com", "Alfred", "AlfredTellier", "Tellier", "0672222668" },
                    { 3, "13 rue du stade", "Jean.tellier74@mail.com", "Jean", "JeanTellier", "Tellier", "0672222669" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Level", "Name" },
                values: new object[,]
                {
                    { 1, "senior", "C#" },
                    { 2, "junior", "C#" },
                    { 3, "intermediate", "C#" }
                });

            migrationBuilder.InsertData(
                table: "ContactSkill",
                columns: new[] { "ContactId", "SkillId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ContactSkill",
                columns: new[] { "ContactId", "SkillId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "ContactSkill",
                columns: new[] { "ContactId", "SkillId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ContactSkill_ContactId",
                table: "ContactSkill",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSkill");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
