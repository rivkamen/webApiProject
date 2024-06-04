﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(MyStore_325950947Context))]
    partial class MyStore_325950947ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repositories.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("CATEGORY_NAME")
                        .IsFixedLength();

                    b.HasKey("CategoryId");

                    b.ToTable("CATEGORIES", (string)null);
                });

            modelBuilder.Entity("Repositories.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ORDER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateOnly?>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("ORDER_DATE");

                    b.Property<int?>("OrderSum")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_SUM");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("ORDERS", (string)null);
                });

            modelBuilder.Entity("Repositories.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ORDER_ITEM_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_ID");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ORDER_ITEM", (string)null);
                });

            modelBuilder.Entity("Repositories.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY_ID");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("DESCRIPTION")
                        .IsFixedLength();

                    b.Property<double?>("Price")
                        .HasColumnType("float")
                        .HasColumnName("PRICE");

                    b.Property<string>("ProductName")
                        .HasMaxLength(40)
                        .HasColumnType("nchar(40)")
                        .HasColumnName("PRODUCT_NAME")
                        .IsFixedLength();

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("Repositories.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasColumnName("EMAIL")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .HasColumnName("FIRST_NAME")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .HasColumnName("LAST_NAME")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .HasColumnName("PASSWORD")
                        .IsFixedLength();

                    b.HasKey("UserId");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("Repositories.Order", b =>
                {
                    b.HasOne("Repositories.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__ORDERS__USER_ID__4AB81AF0");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repositories.OrderItem", b =>
                {
                    b.HasOne("Repositories.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__ORDER_ITE__ORDER__4D94879B");

                    b.HasOne("Repositories.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ORDER_ITE__PRODU__4CA06362");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Repositories.Product", b =>
                {
                    b.HasOne("Repositories.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__PRODUCTS__CATEGO__4BAC3F29");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Repositories.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Repositories.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Repositories.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Repositories.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
