using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

public partial class RubyContext : DbContext
{
    public RubyContext()
    {
    }

    public RubyContext(DbContextOptions<RubyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiCoreBill> ApiCoreBill { get; set; }

    public virtual DbSet<ApiCoreBillDetail> ApiCoreBillDetail { get; set; }

    public virtual DbSet<ApiCoreBillState> ApiCoreBillState { get; set; }

    public virtual DbSet<ApiCoreCategory> ApiCoreCategory { get; set; }

    public virtual DbSet<ApiCoreCurrencytype> ApiCoreCurrencytype { get; set; }

    public virtual DbSet<ApiCoreCustomer> ApiCoreCustomer { get; set; }

    public virtual DbSet<ApiCoreEquipment> ApiCoreEquipment { get; set; }

    public virtual DbSet<ApiCoreEquipmentCategory> ApiCoreEquipmentCategory { get; set; }

    public virtual DbSet<ApiCorePaymenttype> ApiCorePaymenttype { get; set; }

    public virtual DbSet<ApiCoreProduct> ApiCoreProduct { get; set; }

    public virtual DbSet<ApiCoreProductPriceCost> ApiCoreProductPriceCost { get; set; }

    public virtual DbSet<ApiCoreTypecustomer> ApiCoreTypecustomer { get; set; }

    public virtual DbSet<AuthGroup> AuthGroup { get; set; }

    public virtual DbSet<AuthGroupPermissions> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermission { get; set; }

    public virtual DbSet<AuthUser> AuthUser { get; set; }

    public virtual DbSet<AuthUserGroups> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserUserPermissions> AuthUserUserPermissions { get; set; }

    public virtual DbSet<AuthtokenToken> AuthtokenToken { get; set; }

    public virtual DbSet<CurrencyExchange> CurrencyExchange { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLog { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentType { get; set; }

    public virtual DbSet<DjangoMigrations> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSession { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=inventariarte;User=SA;Password=1234;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiCoreBill>(entity =>
        {
            entity.HasKey(e => e.IdBill).HasName("PK__API_core__3213E83FC607936D");

            entity.HasOne(d => d.BillState).WithMany(p => p.ApiCoreBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_API_core_bill_state");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.ApiCoreBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_API_core_customer");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.ApiCoreBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_API_core_paymenttype");
        });

        modelBuilder.Entity<ApiCoreBillDetail>(entity =>
        {
            entity.HasKey(e => e.IdBillDetail).HasName("PK__API_core__3213E83FCA26CCF5");

            entity.Property(e => e.Total).HasComputedColumnSql("([amount_products]*[price])", false);

            entity.HasOne(d => d.IdBillNavigation).WithMany(p => p.ApiCoreBillDetail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_detail_API_core_bill");

            entity.HasOne(d => d.ProductName).WithMany(p => p.ApiCoreBillDetail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_sale_productName_id_ecc56941_fk_API_core_products_id");
        });

        modelBuilder.Entity<ApiCoreBillState>(entity =>
        {
            entity.HasKey(e => e.BillStateId).HasName("PK__API_core__3213E83F51ACCB09");
        });

        modelBuilder.Entity<ApiCoreCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__API_core__3213E83F6024D3F9");
        });

        modelBuilder.Entity<ApiCoreCurrencytype>(entity =>
        {
            entity.HasKey(e => e.IdCurrency).HasName("PK__API_core__3213E83FD61B8488");
        });

        modelBuilder.Entity<ApiCoreCustomer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__API_core__3213E83FD18A6D0A");

            entity.HasOne(d => d.TypeCustomer).WithMany(p => p.ApiCoreCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_customer_customer_Type_id_1b9694ba_fk_API_core_typecustomer_id");
        });

        modelBuilder.Entity<ApiCoreEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__API_core__3213E83F4C018CCB");

            entity.HasOne(d => d.IdEquipmentCategory).WithMany(p => p.ApiCoreEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_equipment_id_equipment_category_id_d8c8e3f5_fk_API_core_equipment_category_id");
        });

        modelBuilder.Entity<ApiCoreEquipmentCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__API_core__3213E83FFE727595");
        });

        modelBuilder.Entity<ApiCorePaymenttype>(entity =>
        {
            entity.HasKey(e => e.PaymentTypeId).HasName("PK__API_core__3213E83FB0B6A937");
        });

        modelBuilder.Entity<ApiCoreProduct>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__API_core__3213E83F175F6043");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ApiCoreProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_products_category_id_4adb675a_fk_API_core_category_id");
        });

        modelBuilder.Entity<ApiCoreProductPriceCost>(entity =>
        {
            entity.HasKey(e => e.IdProductPrice).HasName("pk_Api_core_product_price");

            entity.Property(e => e.IdProductPrice).ValueGeneratedNever();

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.ApiCoreProductPriceCost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Api_core_product_price_API_core_currencytype");

            entity.HasOne(d => d.IdProductNavigation).WithOne(p => p.ApiCoreProductPriceCost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Api_core_product_price_API_core_product");
        });

        modelBuilder.Entity<ApiCoreTypecustomer>(entity =>
        {
            entity.HasKey(e => e.TypeCustomerId).HasName("PK__API_core__3213E83FC5E3B933");
        });

        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83FE8A4C558");
        });

        modelBuilder.Entity<AuthGroupPermissions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83F7EB64EB5");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                .IsUnique()
                .HasFilter("([group_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_per__3213E83F552088C8");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                .IsUnique()
                .HasFilter("([content_type_id] IS NOT NULL AND [codename] IS NOT NULL)");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83FF785D14C");
        });

        modelBuilder.Entity<AuthUserGroups>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83FA6E3049D");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL AND [group_id] IS NOT NULL)");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermissions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F4E644CFE");

            entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_permission_id_1fbb5f2c_fk_auth_permission_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserUserPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthtokenToken>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__authtoke__DFD83CAECCDB8F3A");

            entity.HasOne(d => d.User).WithOne(p => p.AuthtokenToken)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("authtoken_token_user_id_35299eff_fk_auth_user_id");
        });

        modelBuilder.Entity<CurrencyExchange>(entity =>
        {
            entity.HasKey(e => e.IdCurrencyExchange).HasName("pk_CurrencyExchange");

            entity.Property(e => e.IdCurrencyExchange).ValueGeneratedNever();

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.CurrencyExchange)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CurrencyExchange_API_core_currencytype");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_a__3213E83F3FED33E9");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLog).HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLog)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_c__3213E83FEB9FDD66");

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                .IsUnique()
                .HasFilter("([app_label] IS NOT NULL AND [model] IS NOT NULL)");
        });

        modelBuilder.Entity<DjangoMigrations>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_m__3213E83F4E65064F");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("PK__django_s__B3BA0F1F09954992");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
