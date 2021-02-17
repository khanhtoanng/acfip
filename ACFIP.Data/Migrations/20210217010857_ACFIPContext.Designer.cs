﻿// <auto-generated />
using System;
using ACFIP.Data.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACFIP.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210217010857_ACFIPContext")]
    partial class ACFIPContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ACFIP.Data.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("created_time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnName("deleted_flag")
                        .HasColumnType("bit");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnName("hashed_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnName("last_modified_time")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnName("salt")
                        .HasColumnType("binary(16)");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("ACFIP.Data.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("created_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnName("last_modified_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("area");
                });

            modelBuilder.Entity("ACFIP.Data.Models.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnName("area_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("created_time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnName("deleted_flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnName("last_modified_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("camera");
                });

            modelBuilder.Entity("ACFIP.Data.Models.CameraCamConfig", b =>
                {
                    b.Property<int>("CameraId")
                        .HasColumnName("camera_id")
                        .HasColumnType("int");

                    b.Property<int>("ConfigId")
                        .HasColumnName("configuration_id")
                        .HasColumnType("int");

                    b.Property<string>("ConnectionString")
                        .HasColumnName("connection_string")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CameraId", "ConfigId");

                    b.HasIndex("ConfigId");

                    b.ToTable("camera_camera_configuration");
                });

            modelBuilder.Entity("ACFIP.Data.Models.CameraConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Angle")
                        .HasColumnName("angle")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("created_time")
                        .HasColumnType("datetime2");

                    b.Property<float>("Height")
                        .HasColumnName("height")
                        .HasColumnType("real");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnName("last_modified_time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("camera_configuration");
                });

            modelBuilder.Entity("ACFIP.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monitor"
                        });
                });

            modelBuilder.Entity("ACFIP.Data.Models.ViolationCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CameraId")
                        .HasColumnName("camera_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("created_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgUrl")
                        .HasColumnName("image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnName("last_modified_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoUrl")
                        .HasColumnName("video_url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.ToTable("violation_case");
                });

            modelBuilder.Entity("ACFIP.Data.Models.ViolationCaseType", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnName("case_id")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.HasKey("CaseId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("violation_case_violation_type");
                });

            modelBuilder.Entity("ACFIP.Data.Models.ViolationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("violation_type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vest"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Helmet"
                        });
                });

            modelBuilder.Entity("ACFIP.Data.Models.Account", b =>
                {
                    b.HasOne("ACFIP.Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ACFIP.Data.Models.Camera", b =>
                {
                    b.HasOne("ACFIP.Data.Models.Area", "Area")
                        .WithMany("Cameras")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ACFIP.Data.Models.CameraCamConfig", b =>
                {
                    b.HasOne("ACFIP.Data.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACFIP.Data.Models.CameraConfiguration", "Config")
                        .WithMany()
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ACFIP.Data.Models.ViolationCase", b =>
                {
                    b.HasOne("ACFIP.Data.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ACFIP.Data.Models.ViolationCaseType", b =>
                {
                    b.HasOne("ACFIP.Data.Models.ViolationCase", "Case")
                        .WithMany("ViolationCaseTypes")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACFIP.Data.Models.ViolationType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
