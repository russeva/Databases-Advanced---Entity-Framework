﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinic.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalAids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalAids", x => x.Id);
                    table.UniqueConstraint("AK_AnimalAids_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Passprts",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    OwnerPhoneNumber = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(maxLength: 30, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passprts", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Vets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Proffesion = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    PassportSerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Passprts_PassportSerialNumber",
                        column: x => x.PassportSerialNumber,
                        principalTable: "Passprts",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimalId = table.Column<int>(nullable: false),
                    VetId = table.Column<int>(nullable: false),
                    DateAndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Vets_VetId",
                        column: x => x.VetId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureAnimalAid",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(nullable: false),
                    AnimalAidId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureAnimalAid", x => new { x.ProcedureId, x.AnimalAidId });
                    table.ForeignKey(
                        name: "FK_ProcedureAnimalAid_AnimalAids_AnimalAidId",
                        column: x => x.AnimalAidId,
                        principalTable: "AnimalAids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcedureAnimalAid_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_PassportSerialNumber",
                table: "Animals",
                column: "PassportSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureAnimalAid_AnimalAidId",
                table: "ProcedureAnimalAid",
                column: "AnimalAidId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_AnimalId",
                table: "Procedures",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_VetId",
                table: "Procedures",
                column: "VetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedureAnimalAid");

            migrationBuilder.DropTable(
                name: "AnimalAids");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "Passprts");
        }
    }
}
