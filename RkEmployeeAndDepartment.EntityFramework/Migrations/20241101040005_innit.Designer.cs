﻿// <auto-generated />
using System;
using JpEmployeeAndDepartment.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RkEmployeeAndDepartment.EntityFramework.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20241101040005_innit")]
    partial class innit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RkEmployeeAndDepartment.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = new Guid("54b652d0-0a8a-420e-993d-aac716a1b169"),
                            Location = "Head Office",
                            Name = "Human Resources"
                        },
                        new
                        {
                            DepartmentId = new Guid("7769503c-c301-4dcc-85d7-2387255b82d2"),
                            Location = "Tech Park",
                            Name = "IT Department"
                        });
                });

            modelBuilder.Entity("RkEmployeeAndDepartment.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = new Guid("4adda45e-fef9-41f3-ba16-f81504c4d96a"),
                            FirstName = "John",
                            LastName = "Doe",
                            Position = "Manager"
                        },
                        new
                        {
                            EmployeeId = new Guid("0b62652e-c451-4694-8a13-fff65209f7e0"),
                            FirstName = "Jane",
                            LastName = "Smith",
                            Position = "Developer"
                        });
                });

            modelBuilder.Entity("RkEmployeeAndDepartment.Models.Employee", b =>
                {
                    b.HasOne("RkEmployeeAndDepartment.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("RkEmployeeAndDepartment.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
