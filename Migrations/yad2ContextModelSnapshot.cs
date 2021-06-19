﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using yad2.Data;

namespace yad2.Migrations
{
    [DbContext(typeof(yad2Context))]
    partial class yad2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("yad2.Models.Store", b =>
                {
                    b.Property<int>("storeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lng")
                        .HasColumnType("float");

                    b.Property<string>("storeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("storeId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("yad2.Models.Tags", b =>
                {
                    b.Property<int>("tagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tagIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("yad2.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Username");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
