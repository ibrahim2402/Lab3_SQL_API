using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Olakunle_Ibrahim_MS_API.Models
{
    public partial class chateragent : DbContext
    {
        public chateragent()
        {
        }

        public chateragent(DbContextOptions<chateragent> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<CarRental> CarRental { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Transact> Transact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:chateragentsv.database.windows.net,1433;Initial Catalog=chateragentdb;Persist Security Info=False;User ID=adminchateragent;Password=chateragent@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.AirlineCode)
                    .HasName("PK__airline__7E7243578CEB5F2A");

                entity.Property(e => e.AirlineCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AirlineName).IsUnicode(false);

                entity.Property(e => e.Arrival).IsUnicode(false);

                entity.Property(e => e.Departure).IsUnicode(false);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.AirportCode)
                    .HasName("PK__airport__E949ADC6528D41A7");

                entity.Property(e => e.AirportCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AirportCity).IsUnicode(false);

                entity.Property(e => e.Latiitude).IsUnicode(false);

                entity.Property(e => e.Longitutude).IsUnicode(false);
            });

            modelBuilder.Entity<CarRental>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PK__car_rent__F4E508EB8CF065DD");

                entity.Property(e => e.CompanyCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CarNo).IsUnicode(false);

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.LicenceNo).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.CarRental)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__car_rental__id__619B8048");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Balance).IsUnicode(false);

                entity.Property(e => e.CardNo).IsUnicode(false);

                entity.Property(e => e.ExpireDate).IsUnicode(false);

                entity.Property(e => e.PassengerName).IsUnicode(false);

                entity.Property(e => e.PassportNo).IsUnicode(false);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightNo)
                    .HasName("PK__flight__E3700CB1609FF9CE");

                entity.Property(e => e.TicketPrice).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__flight__id__4E88ABD4");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.AirlineCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AirportCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.AirlineCodeNavigation)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.AirlineCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__airline_c__656C112C");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__airport_c__66603565");

                entity.HasOne(d => d.FlightNoNavigation)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.FlightNo)
                    .HasConstraintName("FK__route__flight_no__6477ECF3");
            });

            modelBuilder.Entity<Transact>(entity =>
            {
                entity.HasKey(e => e.TransactId)
                    .HasName("PK__transact__09A1CE8E192D5095");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Transact)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__transact__id__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
