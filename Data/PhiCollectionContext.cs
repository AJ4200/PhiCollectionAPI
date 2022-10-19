#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PhiCollectionAPI.Models;

namespace PhiCollectionAPI.Data
{
    public partial class PhiCollectionContext : DbContext
    {
        public PhiCollectionContext(DbContextOptions<PhiCollectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Bin> Bins { get; set; }
        public virtual DbSet<BinView> BinViews { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<CollectionLog> CollectionLogs { get; set; }
        public virtual DbSet<ControlStation> ControlStations { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<GardenSite> GardenSites { get; set; }
        public virtual DbSet<Landfill> Landfills { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Recycler> Recyclers { get; set; }
        public virtual DbSet<RequestBuffer> RequestBuffers { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestLog> RequestLogs { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<TruckIssue> TruckIssues { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<TruckQueue> TruckQueues { get; set; }
        public virtual DbSet<TruckView> TruckViews { get; set; }
        public virtual DbSet<Waste> Wastes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Admin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("StaffID")
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Bin>(entity =>
            {
                entity.ToTable("Bin");

                entity.Property(e => e.BinId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BinID")
                    .IsFixedLength();

                entity.Property(e => e.Qrcode)
                    .IsRequired()
                    .HasColumnName("QRCode");
            });

            modelBuilder.Entity<BinView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BinView");

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Waste).HasMaxLength(50);
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasKey(e => e.CollectionNumber)
                    .HasName("PK__Collecti__3217FA37E0F36AEE");

                entity.ToTable("Collection");

                entity.Property(e => e.ArrivedAtControlStation).HasColumnType("datetime");

                entity.Property(e => e.ArrivedAtGardenSite).HasColumnType("datetime");

                entity.Property(e => e.ArrivedAtLandfill).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Driver)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Truck)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DestinationNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.Destination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Collectio__Desti__68487DD7");

                entity.HasOne(d => d.DriverNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.Driver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Collectio__Drive__66603565");

                entity.HasOne(d => d.RequestNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.Request)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Collectio__Reque__693CA210");

                entity.HasOne(d => d.TruckNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.Truck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Collectio__Truck__6754599E");
            });

            modelBuilder.Entity<CollectionLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CollectionLog");

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.Driver)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.GardenSite)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.SentTo).HasMaxLength(150);

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.Truck)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Waste)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ControlStation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ControlStation");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("LocationID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Driver");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LicenceNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("StaffID")
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<GardenSite>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GardenSite");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("LocationID")
                    .IsFixedLength();

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(101);
            });

            modelBuilder.Entity<Landfill>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Landfill");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("LocationID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("LocationID")
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Dtype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("dtype");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.SupervisorNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.Supervisor)
                    .HasConstraintName("FK__Location__Superv__6A30C649");
            });

            modelBuilder.Entity<Recycler>(entity =>
            {
                entity.ToTable("Recycler");

                entity.Property(e => e.RecyclerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("RecyclerID")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RecyclerNavigation)
                    .WithOne(p => p.Recycler)
                    .HasForeignKey<Recycler>(d => d.RecyclerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recycler__Recycl__6B24EA82");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.RequestNumber)
                    .HasName("PK__Request__9ADA6BE19F5ED8AB");

                entity.ToTable("Request");

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GardenSite)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.BinNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Bin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__Bin__6D0D32F4");

                entity.HasOne(d => d.GardenSiteNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.GardenSite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__GardenS__6FE99F9F");

                entity.HasOne(d => d.SupervisorNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Supervisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__Supervi__6E01572D");

                entity.HasOne(d => d.WasteNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Waste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__Waste__6EF57B66");
            });

            modelBuilder.Entity<RequestBuffer>(entity =>
            {
                entity.ToTable("RequestBuffer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GardenSite)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.BinNavigation)
                    .WithMany(p => p.RequestBuffers)
                    .HasForeignKey(d => d.Bin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestBuff__Bin__70DDC3D8");

                entity.HasOne(d => d.GardenSiteNavigation)
                    .WithMany(p => p.RequestBuffers)
                    .HasForeignKey(d => d.GardenSite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestBu__Garde__72C60C4A");

                entity.HasOne(d => d.SupervisorNavigation)
                    .WithMany(p => p.RequestBuffers)
                    .HasForeignKey(d => d.Supervisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestBu__Super__73BA3083");

                entity.HasOne(d => d.WasteNavigation)
                    .WithMany(p => p.RequestBuffers)
                    .HasForeignKey(d => d.Waste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestBu__Waste__71D1E811");
            });

            modelBuilder.Entity<RequestLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RequestLog");

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GardenSite)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.Waste)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("StaffID")
                    .IsFixedLength();

                entity.Property(e => e.Dtype)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("dtype");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LicenceNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Supervisor");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("StaffID")
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("Truck");

                entity.Property(e => e.TruckId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TruckID")
                    .IsFixedLength();

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Driver)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumberPlate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.BinNavigation)
                    .WithMany(p => p.Trucks)
                    .HasForeignKey(d => d.Bin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Truck__Bin__74AE54BC");

                entity.HasOne(d => d.DriverNavigation)
                    .WithMany(p => p.Trucks)
                    .HasForeignKey(d => d.Driver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Truck__Driver__75A278F5");
            });

            modelBuilder.Entity<TruckIssue>(entity =>
            {
                entity.ToTable("TruckIssue");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ReportedAt).HasColumnType("datetime");

                entity.Property(e => e.FixedAt).HasColumnType("datetime");

                entity.Property(e => e.Truck)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Driver)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.DriverNavigation)
                    .WithMany(p => p.TruckIssues)
                    .HasForeignKey(d => d.Driver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TruckIssu__Drive__7D439ABD");

                entity.HasOne(d => d.RequestNavigation)
                    .WithMany(p => p.TruckIssues)
                    .HasForeignKey(d => d.Request)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TruckIssu__Reque__7E37BEF6");

                entity.HasOne(d => d.TruckNavigation)
                    .WithMany(p => p.TruckIssues)
                    .HasForeignKey(d => d.Truck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TruckIssu__Truck__7C4F7684");
            });

            modelBuilder.Entity<TruckQueue>(entity =>
            {
                entity.ToTable("TruckQueue");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Truck)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.TruckNavigation)
                    .WithMany(p => p.TruckQueues)
                    .HasForeignKey(d => d.Truck)
                    .HasConstraintName("FK__TruckQueu__Truck__76969D2E");
            });

            modelBuilder.Entity<TruckView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TruckView");

                entity.Property(e => e.Bin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Driver)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.NumberPlate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TruckId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TruckID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Waste>(entity =>
            {
                entity.HasKey(e => e.WasteNumber)
                    .HasName("PK__Waste__143B2C88DDBE83EC");

                entity.ToTable("Waste");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 5)");
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}