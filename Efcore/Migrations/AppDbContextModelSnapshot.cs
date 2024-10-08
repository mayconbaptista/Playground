﻿// <auto-generated />
using System;
using Efcore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Efcore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Efcore.Entities.CustomerEntity", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("customer_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<uint>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("state");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id");

                    b.ToTable("CUSTOMER", (string)null);
                });

            modelBuilder.Entity("Efcore.Entities.OrderEntity", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("order_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<uint>("Id"));

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("approved_at");

                    b.Property<uint?>("CustomerEntityId")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("CustomerId")
                        .HasColumnType("int unsigned");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("datetime")
                        .HasColumnName("delivered_timestamp");

                    b.Property<DateTime?>("EstimatedDelivery")
                        .HasColumnType("datetime")
                        .HasColumnName("estimated_delivery");

                    b.Property<DateTime>("Pucherse")
                        .HasColumnType("datetime")
                        .HasColumnName("purchase_timestamp");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerEntityId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ORDER", (string)null);
                });

            modelBuilder.Entity("Efcore.Entities.OrderItemEntity", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("order_item_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<uint>("Id"));

                    b.Property<uint>("OrderId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<uint>("ProductId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("product_id");

                    b.Property<uint>("SellerId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("seller_id");

                    b.Property<decimal>("ShippingCharges")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("shipping_charges");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ORDER_ITEM", (string)null);
                });

            modelBuilder.Entity("Efcore.Entities.PaymentEntity", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("payment_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<uint>("Id"));

                    b.Property<ushort>("Installments")
                        .HasColumnType("smallint unsigned")
                        .HasColumnName("installments");

                    b.Property<uint>("OrderId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("order_id");

                    b.Property<uint>("PaymentFamilyId")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("type");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("PAYMENT", (string)null);
                });

            modelBuilder.Entity("Efcore.Entities.ProductEntity", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("product_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<uint>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("category_name");

                    b.Property<uint>("HeightCm")
                        .HasColumnType("int unsigned")
                        .HasColumnName("height_cm");

                    b.Property<uint>("LengthCm")
                        .HasColumnType("int unsigned")
                        .HasColumnName("length_cm");

                    b.Property<uint>("WeightG")
                        .HasColumnType("int unsigned")
                        .HasColumnName("weight_g");

                    b.Property<uint>("WidthCm")
                        .HasColumnType("int unsigned")
                        .HasColumnName("width_cm");

                    b.HasKey("Id");

                    b.ToTable("PRODUCT", (string)null);
                });

            modelBuilder.Entity("Efcore.Entities.OrderEntity", b =>
                {
                    b.HasOne("Efcore.Entities.CustomerEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerEntityId");

                    b.HasOne("Efcore.Entities.OrderEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_order_customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Efcore.Entities.OrderItemEntity", b =>
                {
                    b.HasOne("Efcore.Entities.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_order_item_order");

                    b.HasOne("Efcore.Entities.ProductEntity", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_order_item_product");

                    b.Navigation("Order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Efcore.Entities.PaymentEntity", b =>
                {
                    b.HasOne("Efcore.Entities.OrderEntity", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Efcore.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Efcore.Entities.OrderEntity", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
