using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingEnemies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblEnemy",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Tuberculosis (TB) is caused by bacteria (Mycobacterium tuberculosis) that most often affect the lungs. Tuberculosis is curable and preventable.", "Tuberculosis" },
                    { 2, "Plague is an infectious disease caused by the bacteria Yersinia pestis, a zoonotic bacteria, usually found in small mammals and their fleas. It is transmitted between animals through fleas.", "Plague" },
                    { 3, "Smallpox is an ancient disease caused by the variola virus. Early symptoms include high fever and fatigue. The virus then produces a characteristic rash, particularly on the face, arms and legs. The resulting spots become filled with clear fluid and later, pus, and then form a crust, which eventually dries up and falls off. Smallpox was fatal in up to 30% of cases", "Smallpox" },
                    { 4, "A viral infection causing nerve injury which leads to partial or full paralysis. Many of the infected people do not show any symptoms.", "Poliomyelitis" },
                    { 5, "A bacterial infection which spreads through contaminated food and water.", "Cholera" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblEnemy",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblEnemy",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblEnemy",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblEnemy",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblEnemy",
                keyColumn: "EnemyId",
                keyValue: 5);
        }
    }
}
