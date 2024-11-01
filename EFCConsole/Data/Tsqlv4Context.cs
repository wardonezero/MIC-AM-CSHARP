﻿using System;
using System.Collections.Generic;
using EFCConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCConsole.Data;

public partial class Tsqlv4Context : DbContext
{


#pragma warning disable IDE0044 // Add readonly modifier
    private string connetionstring = "Data Source=DESKTOP-S9KHPNV\\WARDONEZERO;Initial Catalog=TSQLV4;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
#pragma warning restore IDE0044 // Add readonly modifier
    public Tsqlv4Context()
    {
    }

    public Tsqlv4Context(DbContextOptions<Tsqlv4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustOrder> CustOrders { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Digit> Digits { get; set; }

    public virtual DbSet<EmpOrder> EmpOrders { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<Num> Nums { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderTotalsByYear> OrderTotalsByYears { get; set; }

    public virtual DbSet<OrderValue> OrderValues { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connetionstring);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories", "Production");

            entity.HasIndex(e => e.Categoryname, "idx_nc_categoryname");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(15)
                .HasColumnName("categoryname");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
        });

        modelBuilder.Entity<CustOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CustOrders", "Sales");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Ordermonth).HasColumnName("ordermonth");
            entity.Property(e => e.Qty).HasColumnName("qty");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid);

            entity.ToTable("Customers", "Sales");

            entity.HasIndex(e => e.City, "idx_nc_city");

            entity.HasIndex(e => e.Companyname, "idx_nc_companyname");

            entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            entity.HasIndex(e => e.Region, "idx_nc_region");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactname)
                .HasMaxLength(30)
                .HasColumnName("contactname");
            entity.Property(e => e.Contacttitle)
                .HasMaxLength(30)
                .HasColumnName("contacttitle");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Digit>(entity =>
        {
            entity.HasKey(e => e.Digit1).HasName("PK__Digits__70DB446903FFB1FC");

            entity.Property(e => e.Digit1)
                .ValueGeneratedNever()
                .HasColumnName("digit");
        });

        modelBuilder.Entity<EmpOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmpOrders", "Sales");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Numorders).HasColumnName("numorders");
            entity.Property(e => e.Ordermonth).HasColumnName("ordermonth");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Val)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("val");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate).HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Mgrid).HasColumnName("mgrid");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Ssn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ssn");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("Employees", "HR");

            entity.HasIndex(e => e.Lastname, "idx_nc_lastname");

            entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate).HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Mgrid).HasColumnName("mgrid");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.Titleofcourtesy)
                .HasMaxLength(25)
                .HasColumnName("titleofcourtesy");

            entity.HasOne(d => d.Mgr).WithMany(p => p.InverseMgr)
                .HasForeignKey(d => d.Mgrid)
                .HasConstraintName("FK_Employees_Employees");
        });

        modelBuilder.Entity<Num>(entity =>
        {
            entity.HasKey(e => e.N);

            entity.Property(e => e.N)
                .ValueGeneratedNever()
                .HasColumnName("n");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Orders", "Sales");

            entity.HasIndex(e => e.Custid, "idx_nc_custid");

            entity.HasIndex(e => e.Empid, "idx_nc_empid");

            entity.HasIndex(e => e.Orderdate, "idx_nc_orderdate");

            entity.HasIndex(e => e.Shippeddate, "idx_nc_shippeddate");

            entity.HasIndex(e => e.Shipperid, "idx_nc_shipperid");

            entity.HasIndex(e => e.Shippostalcode, "idx_nc_shippostalcode");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Freight)
                .HasColumnType("money")
                .HasColumnName("freight");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Requireddate).HasColumnName("requireddate");
            entity.Property(e => e.Shipaddress)
                .HasMaxLength(60)
                .HasColumnName("shipaddress");
            entity.Property(e => e.Shipcity)
                .HasMaxLength(15)
                .HasColumnName("shipcity");
            entity.Property(e => e.Shipcountry)
                .HasMaxLength(15)
                .HasColumnName("shipcountry");
            entity.Property(e => e.Shipname)
                .HasMaxLength(40)
                .HasColumnName("shipname");
            entity.Property(e => e.Shippeddate).HasColumnName("shippeddate");
            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Shippostalcode)
                .HasMaxLength(10)
                .HasColumnName("shippostalcode");
            entity.Property(e => e.Shipregion)
                .HasMaxLength(15)
                .HasColumnName("shipregion");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Emp).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Empid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.Shipper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Shipperid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Shippers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.Orderid, e.Productid });

            entity.ToTable("OrderDetails", "Sales");

            entity.HasIndex(e => e.Orderid, "idx_nc_orderid");

            entity.HasIndex(e => e.Productid, "idx_nc_productid");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(4, 3)")
                .HasColumnName("discount");
            entity.Property(e => e.Qty)
                .HasDefaultValue((short)1)
                .HasColumnName("qty");
            entity.Property(e => e.Unitprice)
                .HasColumnType("money")
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<OrderTotalsByYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderTotalsByYear", "Sales");

            entity.Property(e => e.Orderyear).HasColumnName("orderyear");
            entity.Property(e => e.Qty).HasColumnName("qty");
        });

        modelBuilder.Entity<OrderValue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderValues", "Sales");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Requireddate).HasColumnName("requireddate");
            entity.Property(e => e.Shippeddate).HasColumnName("shippeddate");
            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Val)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("val");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products", "Production");

            entity.HasIndex(e => e.Categoryid, "idx_nc_categoryid");

            entity.HasIndex(e => e.Productname, "idx_nc_productname");

            entity.HasIndex(e => e.Supplierid, "idx_nc_supplierid");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Discontinued).HasColumnName("discontinued");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .HasColumnName("productname");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Unitprice)
                .HasColumnType("money")
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplierid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => new { e.Testid, e.Studentid });

            entity.ToTable("Scores", "Stats");

            entity.HasIndex(e => new { e.Testid, e.Score1 }, "idx_nc_testid_score");

            entity.Property(e => e.Testid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("testid");
            entity.Property(e => e.Studentid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("studentid");
            entity.Property(e => e.Score1).HasColumnName("score");

            entity.HasOne(d => d.Test).WithMany(p => p.Scores)
                .HasForeignKey(d => d.Testid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scores_Tests");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.ToTable("Shippers", "Sales");

            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Suppliers", "Production");

            entity.HasIndex(e => e.Companyname, "idx_nc_companyname");

            entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactname)
                .HasMaxLength(30)
                .HasColumnName("contactname");
            entity.Property(e => e.Contacttitle)
                .HasMaxLength(30)
                .HasColumnName("contacttitle");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("Tests", "Stats");

            entity.Property(e => e.Testid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("testid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
