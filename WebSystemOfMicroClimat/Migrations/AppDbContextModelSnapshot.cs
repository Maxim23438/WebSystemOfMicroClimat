﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSystemOfMicroClimat.Data;

#nullable disable

namespace WebSystemOfMicroClimat.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Humidity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Dehydrator")
                        .HasColumnType("bit");

                    b.Property<bool>("Fan")
                        .HasColumnType("bit");

                    b.Property<bool>("Humidifier")
                        .HasColumnType("bit");

                    b.Property<bool>("Hygrometer")
                        .HasColumnType("bit");

                    b.Property<bool>("Protector")
                        .HasColumnType("bit");

                    b.Property<bool>("Regulator")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Humidities");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Light", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Curtains")
                        .HasColumnType("bit");

                    b.Property<bool>("Dimmer")
                        .HasColumnType("bit");

                    b.Property<bool>("Jalousie")
                        .HasColumnType("bit");

                    b.Property<bool>("LampLight")
                        .HasColumnType("bit");

                    b.Property<bool>("LedLamp")
                        .HasColumnType("bit");

                    b.Property<bool>("Reflector")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Lights");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Temp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Battery")
                        .HasColumnType("bit");

                    b.Property<bool>("Bottom")
                        .HasColumnType("bit");

                    b.Property<bool>("Cond")
                        .HasColumnType("bit");

                    b.Property<bool>("Kamin")
                        .HasColumnType("bit");

                    b.Property<bool>("Kotel")
                        .HasColumnType("bit");

                    b.Property<bool>("Lamp")
                        .HasColumnType("bit");

                    b.Property<bool>("Obigriv")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Temps");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.TempTimeOff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BatteryOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BottomOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CondOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KaminOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KotelOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LampOff")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ObigrivOff")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TempsTimeOffs");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.TempTimeOn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BatteryOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BottomOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CondOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KaminOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KotelOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LampOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ObigrivOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TempsTimeOns");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Flat")
                        .HasColumnType("bit");

                    b.Property<bool>("GreenHouse")
                        .HasColumnType("bit");

                    b.Property<bool>("House")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPayment")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Value", b =>
                {
                    b.Property<int>("ValueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ValueID"));

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<int>("Light")
                        .HasColumnType("int");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ValueID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Values");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Humidity", b =>
                {
                    b.HasOne("WebSystemOfMicroClimat.Models.User", "User")
                        .WithOne("Humidity")
                        .HasForeignKey("WebSystemOfMicroClimat.Models.Humidity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Light", b =>
                {
                    b.HasOne("WebSystemOfMicroClimat.Models.User", "User")
                        .WithOne("Light")
                        .HasForeignKey("WebSystemOfMicroClimat.Models.Light", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Temp", b =>
                {
                    b.HasOne("WebSystemOfMicroClimat.Models.User", "User")
                        .WithOne("Temp")
                        .HasForeignKey("WebSystemOfMicroClimat.Models.Temp", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.TempTimeOff", b =>
                {
                    b.HasOne("WebSystemOfMicroClimat.Models.User", "User")
                        .WithOne("TempTimeOff")
                        .HasForeignKey("WebSystemOfMicroClimat.Models.TempTimeOff", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.TempTimeOn", b =>
                {
                    b.HasOne("WebSystemOfMicroClimat.Models.User", "User")
                        .WithOne("TempTimeOn")
                        .HasForeignKey("WebSystemOfMicroClimat.Models.TempTimeOn", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.Value", b =>
                {
                    b.HasOne("WebSystemOfMicroClimat.Models.User", "User")
                        .WithOne("Value")
                        .HasForeignKey("WebSystemOfMicroClimat.Models.Value", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebSystemOfMicroClimat.Models.User", b =>
                {
                    b.Navigation("Humidity");

                    b.Navigation("Light");

                    b.Navigation("Temp");

                    b.Navigation("TempTimeOff");

                    b.Navigation("TempTimeOn");

                    b.Navigation("Value");
                });
#pragma warning restore 612, 618
        }
    }
}
