using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInsurances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuredPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    FirstName = table.Column<string>(
                        type: "nvarchar(max)", nullable: false),

                    LastName = table.Column<string>(
                        type: "nvarchar(max)", nullable: false),

                    Age = table.Column<int>(
                        type: "int", nullable: false),

                    Phone = table.Column<string>(
                        type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuredPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    InsuredPersonId = table.Column<int>(
                        type: "int", nullable: false),

                    InsuranceCategory = table.Column<int>(
                        type: "int", nullable: false),

                    Name = table.Column<string>(
                        type: "nvarchar(max)", nullable: true),

                    ContractNumber = table.Column<string>(
                        type: "nvarchar(max)", nullable: true),

                    ValidFrom = table.Column<DateTime>(
                        type: "datetime2", nullable: false),

                    ValidTo = table.Column<DateTime>(
                        type: "datetime2", nullable: true),

                    Price = table.Column<decimal>(
                        type: "decimal(18,2)", nullable: false),

                    Description = table.Column<string>(
                        type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);

                    table.ForeignKey(
                        name: "FK_Insurances_InsuredPersons_InsuredPersonId",
                        column: x => x.InsuredPersonId,
                        principalTable: "InsuredPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuredPersonId",
                table: "Insurances",
                column: "InsuredPersonId");
            }
        }
    }
