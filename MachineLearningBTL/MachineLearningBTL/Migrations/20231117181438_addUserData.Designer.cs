﻿// <auto-generated />
using MachineLearningBTL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachineLearningBTL.Migrations
{
    [DbContext(typeof(MachineLearningDb))]
    [Migration("20231117181438_addUserData")]
    partial class addUserData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MachineLearningBTL.Models.DiaBetes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<float>("BMI")
                        .HasColumnType("real");

                    b.Property<int>("BloodPressure")
                        .HasColumnType("int");

                    b.Property<float>("DiabetesPedigreeFunction")
                        .HasColumnType("real");

                    b.Property<int>("Glucose")
                        .HasColumnType("int");

                    b.Property<int>("Insulin")
                        .HasColumnType("int");

                    b.Property<int>("Outcome")
                        .HasColumnType("int");

                    b.Property<int>("Pregnancies")
                        .HasColumnType("int");

                    b.Property<int>("SkinThickness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiaBetes");
                });

            modelBuilder.Entity("MachineLearningBTL.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<float>("BMI")
                        .HasColumnType("real");

                    b.Property<int>("BloodPressure")
                        .HasColumnType("int");

                    b.Property<float>("DiabetesPedigreeFunction")
                        .HasColumnType("real");

                    b.Property<int>("Glucose")
                        .HasColumnType("int");

                    b.Property<int>("Insulin")
                        .HasColumnType("int");

                    b.Property<int>("Outcome")
                        .HasColumnType("int");

                    b.Property<int>("Pregnancies")
                        .HasColumnType("int");

                    b.Property<int>("SkinThickness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("userDatas");
                });
#pragma warning restore 612, 618
        }
    }
}