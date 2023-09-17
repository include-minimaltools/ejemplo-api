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

    public virtual DbSet<ApiCoreBill> ApiCoreBills { get; set; }

    public virtual DbSet<ApiCoreBillDetail> ApiCoreBillDetails { get; set; }

    public virtual DbSet<ApiCoreBillState> ApiCoreBillStates { get; set; }

    public virtual DbSet<ApiCoreCategory> ApiCoreCategories { get; set; }

    public virtual DbSet<ApiCoreCurrencyExchange> ApiCoreCurrencyExchanges { get; set; }

    public virtual DbSet<ApiCoreCurrencyType> ApiCoreCurrencyTypes { get; set; }

    public virtual DbSet<ApiCoreCustomer> ApiCoreCustomers { get; set; }

    public virtual DbSet<ApiCoreEquipment> ApiCoreEquipments { get; set; }

    public virtual DbSet<ApiCoreEquipmentCategory> ApiCoreEquipmentCategories { get; set; }

    public virtual DbSet<ApiCorePaymenttype> ApiCorePaymenttypes { get; set; }

    public virtual DbSet<ApiCoreProduct> ApiCoreProducts { get; set; }

    public virtual DbSet<ApiCoreProductPriceCost> ApiCoreProductPriceCosts { get; set; }

    public virtual DbSet<ApiCoreTypecustomer> ApiCoreTypecustomers { get; set; }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }

    public virtual DbSet<AuthtokenToken> AuthtokenTokens { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiCoreBill>(entity =>
        {
            entity.HasKey(e => e.IdBill).HasName("PK__API_core__3213E83FC607936D");

            entity.ToTable("API_core_bill");

            entity.HasIndex(e => e.BillNumber, "UQ__API_core__8C43111113BF09D5").IsUnique();

            entity.Property(e => e.IdBill).HasColumnName("idBill");
            entity.Property(e => e.BillNumber)
                .HasMaxLength(20)
                .HasColumnName("billNumber");
            entity.Property(e => e.BillStateId).HasColumnName("billStateId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(500)
                .HasColumnName("customerName");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.IvaDolar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ivaDolar");
            entity.Property(e => e.IvaLocal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ivaLocal");
            entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeId");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(9)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.SubTotalDolar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subTotalDolar");
            entity.Property(e => e.SubTotalLocal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subTotalLocal");
            entity.Property(e => e.TotalDolar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalDolar");
            entity.Property(e => e.TotalLocal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalLocal");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("updated_by");

            entity.HasOne(d => d.BillState).WithMany(p => p.ApiCoreBills)
                .HasForeignKey(d => d.BillStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_API_core_bill_state");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.ApiCoreBills)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_API_core_customer");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.ApiCoreBills)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_API_core_paymenttype");
        });

        modelBuilder.Entity<ApiCoreBillDetail>(entity =>
        {
            entity.HasKey(e => e.IdBillDetail).HasName("PK__API_core__3213E83FCA26CCF5");

            entity.ToTable("API_core_bill_detail");

            entity.HasIndex(e => e.ProductNameId, "API_core_sale_productName_id_ecc56941");

            entity.Property(e => e.IdBillDetail).HasColumnName("idBillDetail");
            entity.Property(e => e.AmountProducts).HasColumnName("amount_products");
            entity.Property(e => e.IdBill).HasColumnName("idBill");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PriceDolar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("priceDolar");
            entity.Property(e => e.ProductNameId).HasColumnName("productName_id");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([amount_products]*[price])", false)
                .HasColumnType("decimal(27, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TotalSale)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("total_sale");

            entity.HasOne(d => d.IdBillNavigation).WithMany(p => p.ApiCoreBillDetails)
                .HasForeignKey(d => d.IdBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_API_core_bill_detail_API_core_bill");

            entity.HasOne(d => d.ProductName).WithMany(p => p.ApiCoreBillDetails)
                .HasForeignKey(d => d.ProductNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_sale_productName_id_ecc56941_fk_API_core_products_id");
        });

        modelBuilder.Entity<ApiCoreBillState>(entity =>
        {
            entity.HasKey(e => e.BillStateId).HasName("PK__API_core__3213E83F51ACCB09");

            entity.ToTable("API_core_bill_state");

            entity.Property(e => e.BillStateId).HasColumnName("billStateId");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ApiCoreCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__API_core__3213E83F6024D3F9");

            entity.ToTable("API_core_category");

            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ApiCoreCurrencyExchange>(entity =>
        {
            entity.HasKey(e => e.IdCurrencyExchange).HasName("pk_CurrencyExchange");

            entity.ToTable("API_core_currency_exchange");

            entity.Property(e => e.IdCurrencyExchange).ValueGeneratedNever();
            entity.Property(e => e.ExchangeRateDolar).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ExchangeRateLocal).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.ApiCoreCurrencyExchanges)
                .HasForeignKey(d => d.IdCurrency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CurrencyExchange_API_core_currencytype");
        });

        modelBuilder.Entity<ApiCoreCurrencyType>(entity =>
        {
            entity.HasKey(e => e.IdCurrency).HasName("PK__API_core__3213E83FD61B8488");

            entity.ToTable("API_core_currency_type");

            entity.Property(e => e.Currency).HasMaxLength(50);
        });

        modelBuilder.Entity<ApiCoreCustomer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__API_core__3213E83FD18A6D0A");

            entity.ToTable("API_core_customer");

            entity.HasIndex(e => e.TypeCustomerId, "API_core_customer_customer_Type_id_1b9694ba");

            entity.Property(e => e.FullName)
                .HasMaxLength(500)
                .HasColumnName("fullName");
            entity.Property(e => e.TypeCustomerId).HasColumnName("typeCustomerId");

            entity.HasOne(d => d.TypeCustomer).WithMany(p => p.ApiCoreCustomers)
                .HasForeignKey(d => d.TypeCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_customer_customer_Type_id_1b9694ba_fk_API_core_typecustomer_id");
        });

        modelBuilder.Entity<ApiCoreEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__API_core__3213E83F4C018CCB");

            entity.ToTable("API_core_equipment");

            entity.HasIndex(e => e.IdEquipmentCategoryId, "API_core_equipment_id_equipment_category_id_d8c8e3f5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEquipmentCategoryId).HasColumnName("id_equipment_category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");

            entity.HasOne(d => d.IdEquipmentCategory).WithMany(p => p.ApiCoreEquipments)
                .HasForeignKey(d => d.IdEquipmentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_equipment_id_equipment_category_id_d8c8e3f5_fk_API_core_equipment_category_id");
        });

        modelBuilder.Entity<ApiCoreEquipmentCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__API_core__3213E83FFE727595");

            entity.ToTable("API_core_equipment_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ApiCorePaymenttype>(entity =>
        {
            entity.HasKey(e => e.PaymentTypeId).HasName("PK__API_core__3213E83FB0B6A937");

            entity.ToTable("API_core_paymenttype");

            entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeId");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(100)
                .HasColumnName("paymentType");
        });

        modelBuilder.Entity<ApiCoreProduct>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__API_core__3213E83F175F6043");

            entity.ToTable("API_core_product");

            entity.HasIndex(e => e.ProductCategoryId, "API_core_products_category_id_4adb675a");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ApiCoreProducts)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("API_core_products_category_id_4adb675a_fk_API_core_category_id");
        });

        modelBuilder.Entity<ApiCoreProductPriceCost>(entity =>
        {
            entity.HasKey(e => e.IdProductPrice).HasName("pk_Api_core_product_price");

            entity.ToTable("Api_core_product_price_cost");

            entity.HasIndex(e => e.IdProduct, "unq_Api_core_product_price").IsUnique();

            entity.Property(e => e.IdProductPrice).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.ApiCoreProductPriceCosts)
                .HasForeignKey(d => d.IdCurrency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Api_core_product_price_API_core_currencytype");

            entity.HasOne(d => d.IdProductNavigation).WithOne(p => p.ApiCoreProductPriceCost)
                .HasForeignKey<ApiCoreProductPriceCost>(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Api_core_product_price_API_core_product");
        });

        modelBuilder.Entity<ApiCoreTypecustomer>(entity =>
        {
            entity.HasKey(e => e.TypeCustomerId).HasName("PK__API_core__3213E83FC5E3B933");

            entity.ToTable("API_core_typecustomer");

            entity.Property(e => e.TypeCustomerId).HasColumnName("typeCustomerId");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(500)
                .HasColumnName("customerType");
        });

        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83FE8A4C558");

            entity.ToTable("auth_group");

            entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83F7EB64EB5");

            entity.ToTable("auth_group_permissions");

            entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                .IsUnique()
                .HasFilter("([group_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_per__3213E83F552088C8");

            entity.ToTable("auth_permission");

            entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                .IsUnique()
                .HasFilter("([content_type_id] IS NOT NULL AND [codename] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codename)
                .HasMaxLength(100)
                .HasColumnName("codename");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83FF785D14C");

            entity.ToTable("auth_user");

            entity.HasIndex(e => e.Username, "auth_user_username_6821ab7c_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateJoined).HasColumnName("date_joined");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsStaff).HasColumnName("is_staff");
            entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AuthUserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83FA6E3049D");

            entity.ToTable("auth_user_groups");

            entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544");

            entity.HasIndex(e => e.UserId, "auth_user_groups_user_id_6a12ed8b");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL AND [group_id] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F4E644CFE");

            entity.ToTable("auth_user_user_permissions");

            entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_permission_id_1fbb5f2c");

            entity.HasIndex(e => e.UserId, "auth_user_user_permissions_user_id_a95ead1b");

            entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_permission_id_1fbb5f2c_fk_auth_permission_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthtokenToken>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__authtoke__DFD83CAECCDB8F3A");

            entity.ToTable("authtoken_token");

            entity.HasIndex(e => e.UserId, "UQ__authtoke__B9BE370E4D26DFED").IsUnique();

            entity.Property(e => e.Key)
                .HasMaxLength(40)
                .HasColumnName("key");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.AuthtokenToken)
                .HasForeignKey<AuthtokenToken>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("authtoken_token_user_id_35299eff_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_a__3213E83F3FED33E9");

            entity.ToTable("django_admin_log");

            entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

            entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionFlag).HasColumnName("action_flag");
            entity.Property(e => e.ActionTime).HasColumnName("action_time");
            entity.Property(e => e.ChangeMessage).HasColumnName("change_message");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectRepr)
                .HasMaxLength(200)
                .HasColumnName("object_repr");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_c__3213E83FEB9FDD66");

            entity.ToTable("django_content_type");

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                .IsUnique()
                .HasFilter("([app_label] IS NOT NULL AND [model] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppLabel)
                .HasMaxLength(100)
                .HasColumnName("app_label");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_m__3213E83F4E65064F");

            entity.ToTable("django_migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.App)
                .HasMaxLength(255)
                .HasColumnName("app");
            entity.Property(e => e.Applied).HasColumnName("applied");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("PK__django_s__B3BA0F1F09954992");

            entity.ToTable("django_session");

            entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

            entity.Property(e => e.SessionKey)
                .HasMaxLength(40)
                .HasColumnName("session_key");
            entity.Property(e => e.ExpireDate).HasColumnName("expire_date");
            entity.Property(e => e.SessionData).HasColumnName("session_data");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
