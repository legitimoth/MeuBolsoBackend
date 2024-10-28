﻿// <auto-generated />
using System;
using MeuBolsoBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeuBolsoBackend
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeuBolsoBackend.CartaoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Final")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character(4)")
                        .IsFixedLength();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("MeuBolsoBackend.PagamentoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Cancelado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Local")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Parcelas")
                        .HasColumnType("integer");

                    b.Property<int>("TipoPagamentoId")
                        .HasColumnType("integer");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TipoPagamentoId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("MeuBolsoBackend.TagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cor")
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MeuBolsoBackend.TipoPagamentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposPagamento");
                });

            modelBuilder.Entity("MeuBolsoBackend.UsuarioEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Renda")
                        .HasColumnType("numeric");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PagamentoTag", b =>
                {
                    b.Property<long>("PagamentoId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("PagamentoId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PagamentoTag", (string)null);
                });

            modelBuilder.Entity("MeuBolsoBackend.CartaoEntity", b =>
                {
                    b.HasOne("MeuBolsoBackend.UsuarioEntity", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeuBolsoBackend.PagamentoEntity", b =>
                {
                    b.HasOne("MeuBolsoBackend.TipoPagamentoEntity", "TipoPagamento")
                        .WithMany()
                        .HasForeignKey("TipoPagamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoPagamento");
                });

            modelBuilder.Entity("MeuBolsoBackend.TagEntity", b =>
                {
                    b.HasOne("MeuBolsoBackend.UsuarioEntity", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PagamentoTag", b =>
                {
                    b.HasOne("MeuBolsoBackend.PagamentoEntity", null)
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PagamentoTag_Pagamento");

                    b.HasOne("MeuBolsoBackend.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PagamentoTag_Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
