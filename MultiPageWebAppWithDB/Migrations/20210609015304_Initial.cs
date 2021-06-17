using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiPageWebAppWithDB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    RelationshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.RelationshipId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "RelationshipId", "Type" },
                values: new object[,]
                {
                    { "R", "Realitive" },
                    { "F", "Friend" },
                    { "C", "Coworker" },
                    { "A", "Acquaintance" },
                    { "CM", "Classmate" },
                    { "S", "Services" },
                    { "N", "Neighbor" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Name", "Note", "PhoneNumber", "RelationshipId" },
                values: new object[] { 3, "888 Hotdog St.", "Jon Jon", "Cousin", "712-292-1043", "R" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Name", "Note", "PhoneNumber", "RelationshipId" },
                values: new object[] { 2, "111 Grand Ave.", "Mary Sue", "HTML and CSS class", "712-292-0001", "CM" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Name", "Note", "PhoneNumber", "RelationshipId" },
                values: new object[] { 1, "123 N. Road St.", "Ted Lamp", "Neighbor with a dog", "712-292-0000", "N" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_RelationshipId",
                table: "Contacts",
                column: "RelationshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Relationships");
        }
    }
}
