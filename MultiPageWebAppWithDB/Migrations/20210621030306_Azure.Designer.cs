﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiPageWebAppWithDB.Models;

namespace MultiPageWebAppWithDB.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20210621030306_Azure")]
    partial class Azure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MultiPageWebAppWithDB.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactId");

                    b.HasIndex("RelationshipId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Address = "123 N. Road St.",
                            Name = "Ted Lamp",
                            Note = "Neighbor with a dog",
                            PhoneNumber = "712-292-0000",
                            RelationshipId = "N"
                        },
                        new
                        {
                            ContactId = 2,
                            Address = "111 Grand Ave.",
                            Name = "Mary Sue",
                            Note = "HTML and CSS class",
                            PhoneNumber = "712-292-0001",
                            RelationshipId = "CM"
                        },
                        new
                        {
                            ContactId = 3,
                            Address = "888 Hotdog St.",
                            Name = "Jon Jon",
                            Note = "Cousin",
                            PhoneNumber = "712-292-1043",
                            RelationshipId = "R"
                        });
                });

            modelBuilder.Entity("MultiPageWebAppWithDB.Models.Relationship", b =>
                {
                    b.Property<string>("RelationshipId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelationshipId");

                    b.ToTable("Relationships");

                    b.HasData(
                        new
                        {
                            RelationshipId = "R",
                            Type = "Realitive"
                        },
                        new
                        {
                            RelationshipId = "F",
                            Type = "Friend"
                        },
                        new
                        {
                            RelationshipId = "C",
                            Type = "Coworker"
                        },
                        new
                        {
                            RelationshipId = "A",
                            Type = "Acquaintance"
                        },
                        new
                        {
                            RelationshipId = "CM",
                            Type = "Classmate"
                        },
                        new
                        {
                            RelationshipId = "S",
                            Type = "Services"
                        },
                        new
                        {
                            RelationshipId = "N",
                            Type = "Neighbor"
                        });
                });

            modelBuilder.Entity("MultiPageWebAppWithDB.Models.Contact", b =>
                {
                    b.HasOne("MultiPageWebAppWithDB.Models.Relationship", "Relationship")
                        .WithMany()
                        .HasForeignKey("RelationshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Relationship");
                });
#pragma warning restore 612, 618
        }
    }
}
