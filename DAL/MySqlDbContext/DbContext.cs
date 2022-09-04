using Microsoft.EntityFrameworkCore;

namespace DAL.MySqlDbContext
{
    public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext()
        {
        }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<BankInstallment> BankInstallments { get; set; } = null!;
        public virtual DbSet<Basket> Baskets { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderitem> Orderitems { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Resetpassword> Resetpasswords { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<Shipping> Shippings { get; set; } = null!;
        public virtual DbSet<Slider> Sliders { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wishlist> Wishlists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost,3306;initial catalog=shoppyjoaodias;user id=developer;password=Matheus321*;convert zero datetime=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.Cityid, "city");

                entity.HasIndex(e => e.Userid, "userid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addresname)
                    .HasMaxLength(50)
                    .HasColumnName("addresname");

                entity.Property(e => e.Address1)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(10)
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Cityid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_address_city");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_ibfk_1");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Authority)
                    .HasColumnName("authority")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Confirmation)
                    .HasColumnName("confirmation")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .HasMaxLength(12)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Iban)
                    .HasMaxLength(100)
                    .HasColumnName("iban");

                entity.Property(e => e.Installment)
                    .HasColumnName("installment")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Logo)
                    .HasMaxLength(250)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<BankInstallment>(entity =>
            {
                entity.ToTable("bank_installment");

                entity.HasIndex(e => e.Bankid, "bankid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bankid).HasColumnName("bankid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Installmentcount).HasColumnName("installmentcount");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Rate)
                    .HasPrecision(4, 2)
                    .HasColumnName("rate");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankInstallments)
                    .HasForeignKey(d => d.Bankid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bank_installment_ibfk_1");
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("basket");

                entity.HasIndex(e => e.Productid, "productid");

                entity.HasIndex(e => e.Userid, "userid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Piece)
                    .HasColumnName("piece")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_basket_products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("basket_ibfk_1");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(360)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Displayorder).HasColumnName("displayorder");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Slug)
                    .HasMaxLength(50)
                    .HasColumnName("slug");

                entity.Property(e => e.Title)
                    .HasMaxLength(320)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.Displayorder)
                    .HasColumnName("displayorder")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Homecategory).HasColumnName("homecategory");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Includeintopmenu)
                    .HasColumnName("includeintopmenu")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Metadescription)
                    .HasMaxLength(3000)
                    .HasColumnName("metadescription");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Pagetitle)
                    .HasMaxLength(255)
                    .HasColumnName("pagetitle");

                entity.Property(e => e.Parentid)
                    .HasColumnName("parentid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.Provinceid, "provinceid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Provinceid).HasColumnName("provinceid");

                entity.Property(e => e.Slug)
                    .HasMaxLength(55)
                    .HasColumnName("slug");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Provinceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_ibfk_1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.InvoiceAddressId, "FK_order_address");

                entity.HasIndex(e => e.DeliveryAddressId, "FK_order_address_2");

                entity.HasIndex(e => e.Id, "id");

                entity.HasIndex(e => e.Paymentid, "paymentid");

                entity.HasIndex(e => e.Userid, "userid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.Basketid)
                    .HasMaxLength(255)
                    .HasColumnName("basketid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CurrencyUnit).HasColumnName("currency_unit");

                entity.Property(e => e.DeliveryAddressId).HasColumnName("delivery_address_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Guid)
                    .HasMaxLength(250)
                    .HasColumnName("guid");

                entity.Property(e => e.Installment)
                    .HasColumnName("installment")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.InvoiceAddressId).HasColumnName("invoice_address_id");

                entity.Property(e => e.Orderid)
                    .HasMaxLength(255)
                    .HasColumnName("orderid");

                entity.Property(e => e.Paid)
                    .HasPrecision(10, 2)
                    .HasColumnName("paid");

                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");

                entity.Property(e => e.Paymentid).HasColumnName("paymentid");

                entity.Property(e => e.Paypalid)
                    .HasMaxLength(100)
                    .HasColumnName("paypalid");

                entity.Property(e => e.ShippingChaseNo)
                    .HasMaxLength(50)
                    .HasColumnName("shipping_chase_no");

                entity.Property(e => e.ShippingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shipping_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.DeliveryAddress)
                    .WithMany(p => p.OrderDeliveryAddresses)
                    .HasForeignKey(d => d.DeliveryAddressId)
                    .HasConstraintName("FK_order_address_2");

                entity.HasOne(d => d.InvoiceAddress)
                    .WithMany(p => p.OrderInvoiceAddresses)
                    .HasForeignKey(d => d.InvoiceAddressId)
                    .HasConstraintName("FK_order_address");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Paymentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_ibfk_1");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("orderitem");

                entity.HasIndex(e => e.UserId, "FK_orderitem_user");

                entity.HasIndex(e => e.OrderId, "OrderId");

                entity.HasIndex(e => e.ProductId, "ProductId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.OrderItemGuid)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TotalPrice)
                    .HasPrecision(10)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.WithoutDiscount)
                    .HasPrecision(10)
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitem_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderitem_products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderitem_user");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("page");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.Shippingid, "FK_payment_shipping");

                entity.HasIndex(e => e.Userid, "FK_payment_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bankid).HasColumnName("bankid");

                entity.Property(e => e.Ccsecurity)
                    .HasMaxLength(5)
                    .HasColumnName("ccsecurity");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreditCard)
                    .HasMaxLength(50)
                    .HasColumnName("credit_card");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasColumnName("guid");

                entity.Property(e => e.Lastdate)
                    .HasMaxLength(10)
                    .HasColumnName("lastdate");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Paymentstatus).HasColumnName("paymentstatus");

                entity.Property(e => e.Productprice)
                    .HasPrecision(6, 2)
                    .HasColumnName("productprice");

                entity.Property(e => e.Shippingid).HasColumnName("shippingid");

                entity.Property(e => e.Shippingprice)
                    .HasPrecision(6, 2)
                    .HasColumnName("shippingprice");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .HasColumnName("token");

                entity.Property(e => e.Totalprice)
                    .HasPrecision(10, 2)
                    .HasColumnName("totalprice");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Shippingid)
                    .HasConstraintName("FK_payment_shipping");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_user");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.Brandid, "brandid");

                entity.HasIndex(e => e.Categoryid, "categoryid");

                entity.HasIndex(e => e.Code, "code")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.Easyurl }, "idx_name")
                    .IsUnique();

                entity.HasIndex(e => e.Unitid, "unitid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .HasColumnName("barcode");

                entity.Property(e => e.Brandid).HasColumnName("brandid");

                entity.Property(e => e.Categorygold).HasColumnName("categorygold");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.Discount)
                    .HasColumnType("float(11,2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Discountlastdate)
                    .HasColumnType("datetime")
                    .HasColumnName("discountlastdate");

                entity.Property(e => e.Easyurl).HasColumnName("easyurl");

                entity.Property(e => e.Hit)
                    .HasColumnName("hit")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Homepage).HasColumnName("homepage");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Metadescription)
                    .HasMaxLength(1000)
                    .HasColumnName("metadescription");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Pagetitle)
                    .HasMaxLength(255)
                    .HasColumnName("pagetitle");

                entity.Property(e => e.Price)
                    .HasColumnType("float(11,2)")
                    .HasColumnName("price");

                entity.Property(e => e.Returnable)
                    .HasColumnName("returnable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Returnableday)
                    .HasMaxLength(50)
                    .HasColumnName("returnableday");

                entity.Property(e => e.Showcase).HasColumnName("showcase");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Unitid)
                    .HasColumnName("unitid")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Brandid)
                    .HasConstraintName("FK_products_brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("categoryid");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Unitid)
                    .HasConstraintName("FK_products_unit");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("product_images");

                entity.HasIndex(e => e.Productid, "productid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Orderby).HasColumnName("orderby");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__products");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Resetpassword>(entity =>
            {
                entity.ToTable("resetpassword");

                entity.HasIndex(e => e.Userid, "userid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("datetime")
                    .HasColumnName("createdat");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Guid)
                    .HasMaxLength(100)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastdate");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Resetpasswords)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_resetpassword_user");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("setting");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .HasColumnName("address");

                entity.Property(e => e.Analytics)
                    .HasMaxLength(500)
                    .HasColumnName("analytics");

                entity.Property(e => e.Categoryproduct).HasColumnName("categoryproduct");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Freeshippingprice)
                    .HasPrecision(8, 2)
                    .HasColumnName("freeshippingprice");

                entity.Property(e => e.Homeproductcount).HasColumnName("homeproductcount");

                entity.Property(e => e.Keywords)
                    .HasMaxLength(4000)
                    .HasColumnName("keywords");

                entity.Property(e => e.Phone)
                    .HasMaxLength(250)
                    .HasColumnName("phone");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("shipping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Desiprice)
                    .HasPrecision(4, 2)
                    .HasColumnName("desiprice");

                entity.Property(e => e.Logo)
                    .HasMaxLength(255)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasColumnName("note");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("'99'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.ToTable("slider");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title1)
                    .HasMaxLength(255)
                    .HasColumnName("title1")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title2)
                    .HasMaxLength(255)
                    .HasColumnName("title2")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .HasColumnName("url")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .HasColumnName("shortname");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Cityid, "FK_user_city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Cityid)
                    .HasColumnName("cityid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Citytext)
                    .HasMaxLength(50)
                    .HasColumnName("citytext");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Customertype).HasColumnName("customertype");

                entity.Property(e => e.District).HasColumnName("district");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Maillist).HasColumnName("maillist");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Valid)
                    .HasMaxLength(8)
                    .HasColumnName("valid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(5)
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK_user_city");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("wishlist");

                entity.HasIndex(e => e.Userid, "FK_wishlist_user");

                entity.HasIndex(e => e.Productid, "productid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("datetime")
                    .HasColumnName("createdat");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Updatedat)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedat");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishlist_products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishlist_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
