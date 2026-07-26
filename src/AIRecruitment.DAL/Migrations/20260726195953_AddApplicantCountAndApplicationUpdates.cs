using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIRecruitment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantCountAndApplicationUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIAnalyses_Application_ApplicationId",
                table: "AIAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_CandidateProfiles_CandidateProfileId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Jobs_JobId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Resumes_ResumeId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Application_ApplicationId",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_ResumeId",
                table: "Applications",
                newName: "IX_Applications_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_JobId",
                table: "Applications",
                newName: "IX_Applications_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_CandidateProfileId",
                table: "Applications",
                newName: "IX_Applications_CandidateProfileId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantCount",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CoverNote",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AIAnalyses_Applications_ApplicationId",
                table: "AIAnalyses",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_CandidateProfiles_CandidateProfileId",
                table: "Applications",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Resumes_ResumeId",
                table: "Applications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIAnalyses_Applications_ApplicationId",
                table: "AIAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_CandidateProfiles_CandidateProfileId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Resumes_ResumeId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantCount",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CoverNote",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ResumeId",
                table: "Application",
                newName: "IX_Application_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobId",
                table: "Application",
                newName: "IX_Application_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_CandidateProfileId",
                table: "Application",
                newName: "IX_Application_CandidateProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AIAnalyses_Application_ApplicationId",
                table: "AIAnalyses",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_CandidateProfiles_CandidateProfileId",
                table: "Application",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Jobs_JobId",
                table: "Application",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Resumes_ResumeId",
                table: "Application",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Application_ApplicationId",
                table: "Interviews",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
