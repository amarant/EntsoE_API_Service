﻿// <auto-generated />
using System;
using EntsoE_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntsoE_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntsoE_DataModel.Data.GenForecastLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("HasData");

                    b.Property<DateTime>("InsertedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Message");

                    b.Property<string>("RequestType");

                    b.Property<int>("RetryCount");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("GenForecastRequestLogs");
                });

            modelBuilder.Entity("EntsoE_DataModel.Data.GenForecastMeta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode");

                    b.Property<string>("DocumentType");

                    b.Property<DateTime>("EndPeriod");

                    b.Property<long>("GenForecastRequestLogId");

                    b.Property<DateTime>("InsertedOn");

                    b.Property<int>("IntervalMins");

                    b.Property<string>("ProcessType");

                    b.Property<int>("RowCount");

                    b.Property<DateTime>("StartPeriod");

                    b.Property<int>("mRID");

                    b.HasKey("Id");

                    b.HasIndex("GenForecastRequestLogId");

                    b.ToTable("GenForecastMeta","entsoe");
                });

            modelBuilder.Entity("EntsoE_DataModel.Data.GenForecastTimeSeries", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MetaId");

                    b.Property<int>("Position");

                    b.Property<double>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("MetaId");

                    b.ToTable("GenForecastTimeSeries","entsoe");
                });

            modelBuilder.Entity("EntsoE_DataModel.Data.GenForecastMeta", b =>
                {
                    b.HasOne("EntsoE_DataModel.Data.GenForecastLog", "GenForecastRequestLog")
                        .WithMany("GenForecastMeta")
                        .HasForeignKey("GenForecastRequestLogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntsoE_DataModel.Data.GenForecastTimeSeries", b =>
                {
                    b.HasOne("EntsoE_DataModel.Data.GenForecastMeta", "GenForecastMeta")
                        .WithMany("TimeSeries")
                        .HasForeignKey("MetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
