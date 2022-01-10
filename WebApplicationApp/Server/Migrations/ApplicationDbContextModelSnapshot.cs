﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationApp.Server.Data;

namespace WebApplicationApp.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<Guid>("EmployeesemployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectsprojectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeesemployeeId", "ProjectsprojectId");

                    b.HasIndex("ProjectsprojectId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("EmployeeTicket", b =>
                {
                    b.Property<Guid>("EmployeesemployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketsticketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeesemployeeId", "TicketsticketId");

                    b.HasIndex("TicketsticketId");

                    b.ToTable("EmployeeTicket");
                });

            modelBuilder.Entity("ProjectTicket", b =>
                {
                    b.Property<Guid>("ProjectsprojectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketsticketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectsprojectId", "TicketsticketId");

                    b.HasIndex("TicketsticketId");

                    b.ToTable("ProjectTicket");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.Company", b =>
                {
                    b.Property<Guid>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("companyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.Employee", b =>
                {
                    b.Property<Guid>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("employeeFirstName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("employeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("employeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.PredictionReport", b =>
                {
                    b.Property<Guid>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("predictionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("reportDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reportId");

                    b.ToTable("PredictionReports");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PredictionReport");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.Project", b =>
                {
                    b.Property<Guid>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("companyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("employeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("projectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("projectId");

                    b.HasIndex("companyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.Ticket", b =>
                {
                    b.Property<Guid>("ticketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("employeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("projectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.Property<string>("ticketDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ticketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.DevelopmentReport", b =>
                {
                    b.HasBaseType("WebApplicationApp.Shared.PredictionReport");

                    b.Property<string>("performance")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DevelopmentReport");
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("WebApplicationApp.Shared.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesemployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationApp.Shared.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsprojectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeTicket", b =>
                {
                    b.HasOne("WebApplicationApp.Shared.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesemployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationApp.Shared.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsticketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTicket", b =>
                {
                    b.HasOne("WebApplicationApp.Shared.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsprojectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationApp.Shared.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsticketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationApp.Shared.Project", b =>
                {
                    b.HasOne("WebApplicationApp.Shared.Company", null)
                        .WithMany("Projects")
                        .HasForeignKey("companyId");
                });

            modelBuilder.Entity("WebApplicationApp.Shared.Company", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
