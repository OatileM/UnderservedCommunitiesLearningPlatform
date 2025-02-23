﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UnderservedCommunitiesLearningPlatform.Data;

#nullable disable

namespace UnderservedCommunitiesLearningPlatform.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250223172504_AddMarkToStudentModule")]
    partial class AddMarkToStudentModule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Module", b =>
                {
                    b.Property<string>("ModuleID")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Mark")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("TeacherID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ModuleID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Student", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.StudentModule", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("text");

                    b.Property<string>("ModuleID")
                        .HasColumnType("text");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StudentID", "ModuleID");

                    b.HasIndex("ModuleID");

                    b.ToTable("StudentModules");
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Teacher", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("TeacherID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Module", b =>
                {
                    b.HasOne("UnderservedCommunitiesLearningPlatform.Models.Teacher", "Teacher")
                        .WithMany("Modules")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.StudentModule", b =>
                {
                    b.HasOne("UnderservedCommunitiesLearningPlatform.Models.Module", "Module")
                        .WithMany("StudentModules")
                        .HasForeignKey("ModuleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnderservedCommunitiesLearningPlatform.Models.Student", "Student")
                        .WithMany("StudentModules")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Module", b =>
                {
                    b.Navigation("StudentModules");
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Student", b =>
                {
                    b.Navigation("StudentModules");
                });

            modelBuilder.Entity("UnderservedCommunitiesLearningPlatform.Models.Teacher", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
