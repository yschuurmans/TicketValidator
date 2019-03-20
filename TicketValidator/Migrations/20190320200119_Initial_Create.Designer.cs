﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketValidator.Persistence;

namespace TicketValidator.Migrations
{
    [DbContext(typeof(ValidatorDbContext))]
    [Migration("20190320200119_Initial_Create")]
    partial class Initial_Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TicketValidator.Domain.Ticket", b =>
                {
                    b.Property<string>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ClaimedDateTime");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
