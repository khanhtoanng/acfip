﻿// <auto-generated />
using System;
using ACFIP_Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACFIP_Server.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ACFIP_Server.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_time");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnType("bit")
                        .HasColumnName("deleted_flag");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("hashed_password");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modified_time");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("binary(16)")
                        .HasColumnName("salt");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("ACFIP_Server.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_time");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnType("bit")
                        .HasColumnName("deleted_flag");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modified_time");

                    b.HasKey("Id");

                    b.ToTable("area");
                });

            modelBuilder.Entity("ACFIP_Server.Models.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int?>("AreaId")
                        .HasColumnType("int")
                        .HasColumnName("area_id");

                    b.Property<int>("ConfigId")
                        .HasColumnType("int")
                        .HasColumnName("configuration_id");

                    b.Property<string>("ConnectionString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("connection_string");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_time");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnType("bit")
                        .HasColumnName("deleted_flag");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modified_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ConfigId");

                    b.ToTable("camera");
                });

            modelBuilder.Entity("ACFIP_Server.Models.CameraConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<float>("Angle")
                        .HasColumnType("real")
                        .HasColumnName("angle");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_time");

                    b.Property<float>("Height")
                        .HasColumnType("real")
                        .HasColumnName("height");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modified_time");

                    b.HasKey("Id");

                    b.ToTable("camera_configuration");
                });

            modelBuilder.Entity("ACFIP_Server.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Monitor"
                        });
                });

            modelBuilder.Entity("ACFIP_Server.Models.ViolationCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("CameraId")
                        .HasColumnType("int")
                        .HasColumnName("camera_id");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_time");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modified_time");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("video_url");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.ToTable("violation_case");
                });

            modelBuilder.Entity("ACFIP_Server.Models.ViolationCaseType", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int")
                        .HasColumnName("case_id");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.HasKey("CaseId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("violation_case_violation_type");
                });

            modelBuilder.Entity("ACFIP_Server.Models.ViolationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

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

            modelBuilder.Entity("ACFIP_Server.Models.Account", b =>
                {
                    b.HasOne("ACFIP_Server.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ACFIP_Server.Models.Camera", b =>
                {
                    b.HasOne("ACFIP_Server.Models.Area", "Area")
                        .WithMany("Cameras")
                        .HasForeignKey("AreaId");

                    b.HasOne("ACFIP_Server.Models.CameraConfiguration", "Config")
                        .WithMany()
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Config");
                });

            modelBuilder.Entity("ACFIP_Server.Models.ViolationCase", b =>
                {
                    b.HasOne("ACFIP_Server.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");
                });

            modelBuilder.Entity("ACFIP_Server.Models.ViolationCaseType", b =>
                {
                    b.HasOne("ACFIP_Server.Models.ViolationCase", "Case")
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACFIP_Server.Models.ViolationType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ACFIP_Server.Models.Area", b =>
                {
                    b.Navigation("Cameras");
                });
#pragma warning restore 612, 618
        }
    }
}
