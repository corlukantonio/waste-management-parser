﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using waste_management_parser.Data;

#nullable disable

namespace waste_management_parser.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220718123317_Edit_User_Group_Picture")]
    partial class Edit_User_Group_Picture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("waste_management_parser.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPasswordResetRequested")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PictureData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PictureName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("waste_management_parser.Models.ApplicationUser_WmOrganization", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WmOrganizationId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "WmOrganizationId");

                    b.HasIndex("WmOrganizationId");

                    b.ToTable("ApplicationUsers_WmOrganizations");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<byte[]>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("binary(36)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PictureData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PictureName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WmOrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid")
                        .HasName("UXC_WmGroups_Guid");

                    b.HasIndex("WmOrganizationId");

                    b.ToTable("WmGroups");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("ActivationCode")
                        .HasMaxLength(4)
                        .HasColumnType("binary(4)")
                        .IsFixedLength();

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<byte[]>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("binary(36)")
                        .IsFixedLength();

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<byte[]>("Mac")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("binary(6)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WmGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid")
                        .HasName("UXC_WmObjects_Guid");

                    b.HasAlternateKey("Mac")
                        .HasName("UXC_WmObjects_Mac");

                    b.HasIndex("OwnerId");

                    b.HasIndex("WmGroupId");

                    b.ToTable("WmObjects");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<byte[]>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("binary(36)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid")
                        .HasName("UXC_WmOrganizations_Guid");

                    b.ToTable("WmOrganizations");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("WmObjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WmObjectId");

                    b.ToTable("WmRecords");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmRecord_TriggerWasteBinEmptying", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("WmRecords_TriggerWasteBinEmptying");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmRecord_TriggerWasteBinEmptying_WmObject", b =>
                {
                    b.Property<int>("WmRecord_TriggerWasteBinEmptyingId")
                        .HasColumnType("int");

                    b.Property<int>("WmObjectId")
                        .HasColumnType("int");

                    b.HasKey("WmRecord_TriggerWasteBinEmptyingId", "WmObjectId");

                    b.HasIndex("WmObjectId");

                    b.ToTable("WmRecords_TriggerWasteBinEmptying_WmObjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("waste_management_parser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("waste_management_parser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("waste_management_parser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("waste_management_parser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("waste_management_parser.Models.ApplicationUser_WmOrganization", b =>
                {
                    b.HasOne("waste_management_parser.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUsers_WmOrganizations")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("waste_management_parser.Models.WmOrganization", "WmOrganization")
                        .WithMany("ApplicationUsers_WmOrganizations")
                        .HasForeignKey("WmOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("WmOrganization");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmGroup", b =>
                {
                    b.HasOne("waste_management_parser.Models.WmOrganization", "WmOrganization")
                        .WithMany("WmGroups")
                        .HasForeignKey("WmOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WmOrganization");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmObject", b =>
                {
                    b.HasOne("waste_management_parser.Models.ApplicationUser", "Owner")
                        .WithMany("WmObjects")
                        .HasForeignKey("OwnerId");

                    b.HasOne("waste_management_parser.Models.WmGroup", "WmGroup")
                        .WithMany("WmObjects")
                        .HasForeignKey("WmGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("WmGroup");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmRecord", b =>
                {
                    b.HasOne("waste_management_parser.Models.WmObject", "WmObject")
                        .WithMany("WmRecords")
                        .HasForeignKey("WmObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WmObject");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmRecord_TriggerWasteBinEmptying_WmObject", b =>
                {
                    b.HasOne("waste_management_parser.Models.WmObject", "WmObject")
                        .WithMany("WmRecords_TriggerWasteBinEmptying_WmObjects")
                        .HasForeignKey("WmObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("waste_management_parser.Models.WmRecord_TriggerWasteBinEmptying", "WmRecord_TriggerWasteBinEmptying")
                        .WithMany("WmRecords_TriggerWasteBinEmptying_WmObjects")
                        .HasForeignKey("WmRecord_TriggerWasteBinEmptyingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WmObject");

                    b.Navigation("WmRecord_TriggerWasteBinEmptying");
                });

            modelBuilder.Entity("waste_management_parser.Models.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUsers_WmOrganizations");

                    b.Navigation("WmObjects");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmGroup", b =>
                {
                    b.Navigation("WmObjects");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmObject", b =>
                {
                    b.Navigation("WmRecords");

                    b.Navigation("WmRecords_TriggerWasteBinEmptying_WmObjects");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmOrganization", b =>
                {
                    b.Navigation("ApplicationUsers_WmOrganizations");

                    b.Navigation("WmGroups");
                });

            modelBuilder.Entity("waste_management_parser.Models.WmRecord_TriggerWasteBinEmptying", b =>
                {
                    b.Navigation("WmRecords_TriggerWasteBinEmptying_WmObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
