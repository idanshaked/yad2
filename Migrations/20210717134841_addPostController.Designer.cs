﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using yad2.Data;

namespace yad2.Migrations
{
    [DbContext(typeof(yad2Context))]
    [Migration("20210717134841_addPostController")]
    partial class addPostController
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("yad2.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PicUrls")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublisherUsername")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PostID");

                    b.HasIndex("PublisherUsername");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("yad2.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("PostID")
                        .IsUnique();

                    b.ToTable("Products");
                });

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

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("tagIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tagId");

                    b.HasIndex("PostID");

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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("yad2.Models.Post", b =>
                {
                    b.HasOne("yad2.Models.User", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherUsername");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("yad2.Models.Product", b =>
                {
                    b.HasOne("yad2.Models.Post", "Post")
                        .WithOne("Product")
                        .HasForeignKey("yad2.Models.Product", "PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("yad2.Models.Tags", b =>
                {
                    b.HasOne("yad2.Models.Post", null)
                        .WithMany("Tags")
                        .HasForeignKey("PostID");
                });

            modelBuilder.Entity("yad2.Models.Post", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}