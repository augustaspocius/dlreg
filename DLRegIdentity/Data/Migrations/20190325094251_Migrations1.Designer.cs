﻿// <auto-generated />
using System;
using DLRegIdentity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DLRegIdentity.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190325094251_Migrations1")]
    partial class Migrations1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DLRegIdentity.Models.Devicereg", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<int?>("Deviceid")
                        .HasColumnName("DEVICEID");

                    b.Property<byte?>("Inout")
                        .HasColumnName("INOUT");

                    b.Property<int?>("Recid")
                        .HasColumnName("RECID");

                    b.Property<DateTime?>("Time")
                        .HasColumnName("TIME")
                        .HasColumnType("datetime");

                    b.Property<int?>("Workerid")
                        .HasColumnName("WORKERID");

                    b.HasKey("Id");

                    b.ToTable("devicereg");
                });

            modelBuilder.Entity("DLRegIdentity.Models.Monthreg", b =>
                {
                    b.Property<int>("Rowid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ROWID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnName("COMMENT")
                        .IsUnicode(false);

                    b.Property<decimal?>("D1")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D10")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D11")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D12")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D13")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D14")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D15")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D16")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D17")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D18")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D19")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D2")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D20")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D21")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D22")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D23")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D24")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D25")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D26")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D27")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D28")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D29")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D3")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D30")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D31")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D4")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D5")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D6")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D7")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D8")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<decimal?>("D9")
                        .HasColumnType("numeric(18, 6)");

                    b.Property<string>("Dp1")
                        .HasColumnName("DP1")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp10")
                        .HasColumnName("DP10")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp11")
                        .HasColumnName("DP11")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp12")
                        .HasColumnName("DP12")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp13")
                        .HasColumnName("DP13")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp14")
                        .HasColumnName("DP14")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp15")
                        .HasColumnName("DP15")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp16")
                        .HasColumnName("DP16")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp17")
                        .HasColumnName("DP17")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp18")
                        .HasColumnName("DP18")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp19")
                        .HasColumnName("DP19")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp2")
                        .HasColumnName("DP2")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp20")
                        .HasColumnName("DP20")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp21")
                        .HasColumnName("DP21")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp22")
                        .HasColumnName("DP22")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp23")
                        .HasColumnName("DP23")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp24")
                        .HasColumnName("DP24")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp25")
                        .HasColumnName("DP25")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp26")
                        .HasColumnName("DP26")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp27")
                        .HasColumnName("DP27")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp28")
                        .HasColumnName("DP28")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp29")
                        .HasColumnName("DP29")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp3")
                        .HasColumnName("DP3")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp30")
                        .HasColumnName("DP30")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp31")
                        .HasColumnName("DP31")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp4")
                        .HasColumnName("DP4")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp5")
                        .HasColumnName("DP5")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp6")
                        .HasColumnName("DP6")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp7")
                        .HasColumnName("DP7")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp8")
                        .HasColumnName("DP8")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Dp9")
                        .HasColumnName("DP9")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int>("Monthid")
                        .HasColumnName("MONTHID");

                    b.Property<int>("Workerid")
                        .HasColumnName("WORKERID");

                    b.HasKey("Rowid");

                    b.HasIndex("Workerid");

                    b.HasIndex("Monthid", "Workerid")
                        .IsUnique()
                        .HasName("IX_Table_1");

                    b.ToTable("monthreg");
                });

            modelBuilder.Entity("DLRegIdentity.Models.Workers", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<int?>("Departmentid")
                        .HasColumnName("DEPARTMENTID");

                    b.Property<string>("Fullname")
                        .HasColumnName("FULLNAME")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Lastname")
                        .HasColumnName("LASTNAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("Shiftid")
                        .HasColumnName("SHIFTID");

                    b.Property<string>("Username")
                        .HasColumnName("USERNAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Fullname")
                        .IsUnique()
                        .HasName("IX_fullname")
                        .HasFilter("[FULLNAME] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("IX_username")
                        .HasFilter("[USERNAME] IS NOT NULL");

                    b.ToTable("workers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DLRegIdentity.Models.Monthreg", b =>
                {
                    b.HasOne("DLRegIdentity.Models.Workers", "Worker")
                        .WithMany()
                        .HasForeignKey("Workerid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
