﻿// <auto-generated />
using BernadosBakery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace BernadosBakery.Migrations
{
    [DbContext(typeof(BakeryContext))]
    [Migration("20180520230906_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("BernadosBakery.Models.Cake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsCakeOfWeek");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("ShortDesc");

                    b.HasKey("Id");

                    b.ToTable("Cake");
                });

            modelBuilder.Entity("BernadosBakery.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsDrinkOfWeek");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("ShortDesc");

                    b.HasKey("Id");

                    b.ToTable("Drink");
                });

            modelBuilder.Entity("BernadosBakery.Models.Pie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsPieOfWeek");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("ShortDesc");

                    b.HasKey("Id");

                    b.ToTable("Pie");
                });

            modelBuilder.Entity("BernadosBakery.Models.Sandwich", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsSandwichOfWeek");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("ShortDesc");

                    b.HasKey("Id");

                    b.ToTable("Sandwich");
                });
#pragma warning restore 612, 618
        }
    }
}