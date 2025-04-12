﻿// <auto-generated />
using System;
using BiddingManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250410150430_PluralizeSomeTablesAndFixNamingConflicts")]
    partial class PluralizeSomeTablesAndFixNamingConflicts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BidId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.EvaluationCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EvaluationCriteria");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EvaluationCriteriaId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationCriteriaId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.BidDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BidId");

                    b.ToTable("BidDocuments");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EligibilityCriteria")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.TenderCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TenderCategory");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.TenderDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.ToTable("TenderDocuments");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.UserAggregate.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("TenderTenderCategory", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("TendersId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "TendersId");

                    b.HasIndex("TendersId");

                    b.ToTable("TenderCategoryMappings", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.Evaluation", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Bid", "Bid")
                        .WithMany("Evaluations")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.ScoreValue", "Score", b1 =>
                        {
                            b1.Property<int>("EvaluationId")
                                .HasColumnType("int");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("EvaluationId");

                            b1.ToTable("Evaluations");

                            b1.WithOwner()
                                .HasForeignKey("EvaluationId");
                        });

                    b.Navigation("Bid");

                    b.Navigation("Score")
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.Score", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.EvaluationCriteria", "EvaluationCriteria")
                        .WithMany("Scores")
                        .HasForeignKey("EvaluationCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.Evaluation", "Evaluation")
                        .WithMany("Scores")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluation");

                    b.Navigation("EvaluationCriteria");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Bid", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Tender", "Tender")
                        .WithMany("Bids")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.UserAggregate.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.BidDocument", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Bid", "Bid")
                        .WithMany("Documents")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bid");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Tender", b =>
                {
                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.DateTimeRange", "DateRange", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tenders");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.Money", "Budget", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tenders");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.Navigation("Budget")
                        .IsRequired();

                    b.Navigation("DateRange")
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.TenderDocument", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Tender", "Tender")
                        .WithMany("Documents")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tender");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.UserAggregate.User", b =>
                {
                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.UserAggregate.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TenderTenderCategory", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.TenderCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Tender", null)
                        .WithMany()
                        .HasForeignKey("TendersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.Evaluation", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate.EvaluationCriteria", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Bid", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.TenderAggregate.Tender", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Aggregates.UserAggregate.User", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
