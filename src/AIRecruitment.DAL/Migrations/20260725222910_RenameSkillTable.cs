using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIRecruitment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameSkillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Skill_SkillId",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skill_SkillId",
                table: "JobSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_Name",
                table: "Skills",
                newName: "IX_Skills_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Skills_SkillId",
                table: "CandidateSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skills_SkillId",
                table: "JobSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Skills_SkillId",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skills_SkillId",
                table: "JobSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_Name",
                table: "Skill",
                newName: "IX_Skill_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Skill_SkillId",
                table: "CandidateSkills",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skill_SkillId",
                table: "JobSkills",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
