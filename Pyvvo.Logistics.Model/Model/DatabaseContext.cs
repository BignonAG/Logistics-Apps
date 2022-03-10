using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Pyvvo.Logistics.Model
{
    public class DatabaseContext : DbContext
    {
        // public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        // {
        // }

        public DbSet<AccountLogin> AccountLogins { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CarrierService> CarrierServices { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<LinkedVariant> LinkedVariants { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<MeasurementUnitSystem> MeasurementUnitSystems { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Processing> Processings { get; set; }
        public DbSet<ProcessingLineItem> ProcessingLineItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
        public DbSet<PurchaseOrderReceive> PurchaseOrderReceives { get; set; }
        public DbSet<PurchaseOrderReceiveLineItem> PurchaseOrderReceiveLineItems { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<RefundLineItem> RefundLineItems { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<ReturnLineItem> ReturnLineItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentLineItem> ShipmentLineItems { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StatusCategory> StatusCategories { get; set; }
        public DbSet<StockAdjustement> StockAdjustements { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<StockLevel> StockLevels { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }
        public DbSet<StockTransferLineItem> StockTransferLineItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Taxe> Taxes { get; set; }
        public DbSet<TaxLineItem> TaxLineItems { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<DatabaseEntity> DatabaseEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Properties.Resources.AzureConnexionString)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Customer>()
                .HasOne(p => p.BillingAddress)
                .WithMany();

            builder.Entity<Customer>()
                .HasOne(p => p.ShippingAddress)
                .WithMany();

            builder.Entity<LinkedVariant>()
                .HasOne(p => p.Variant)
                .WithMany(x => x.LinkedVariants);

            builder.Entity<Order>()
                .HasOne(p => p.Status)
                .WithMany();

            builder.Entity<Order>()
                .HasOne(p => p.FulfillmentStatus)
                .WithMany();
            //builder.Entity<Order>()
            //   .HasMany(p => p.Refunds)
            //   .WithOne()
            //   .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Order>()
            //   .HasMany(p => p.Refunds)
            //   .WithOne()
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Order>().HasMany(x => x.Invoices).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Invoice>()
                .HasMany(x => x.InvoiceLineItems)
                .WithOne(x => x.Invoice)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<InvoiceLineItem>()
                .HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLineItems);


            builder.Entity<Order>()
                .HasOne(p => p.ShippingAddress)
                .WithMany();

            builder.Entity<Order>()
                .HasOne(p => p.BillingAddress)
                .WithMany();

            builder.Entity<Parameter>()
                .HasOne(p => p.WeightUnit)
                .WithMany();

            builder.Entity<Parameter>()
                .HasOne(p => p.DimensionUnit)
                .WithMany();

            builder.Entity<PurchaseOrder>()
                .HasOne(p => p.BillingAddress)
                .WithMany();

            builder.Entity<PurchaseOrder>()
                .HasOne(p => p.ShippingAddress)
                .WithMany();

            builder.Entity<PurchaseOrderReceive>()
                .HasOne(p => p.Agent)
                .WithMany();

            builder.Entity<PurchaseOrderReceive>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<Shipment>()
                .HasOne(p => p.Agent)
                .WithMany();

            builder.Entity<Shipment>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<Processing>()
                .HasOne(p => p.Agent)
                .WithMany();

            builder.Entity<Processing>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<Return>()
                .HasOne(p => p.Agent)
                .WithMany();

            builder.Entity<Return>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<ShippingMethod>()
                .HasOne(p => p.MinParameter)
                .WithMany();

            builder.Entity<ShippingMethod>()
                .HasOne(p => p.MaxParameter)
                .WithMany();

            builder.Entity<StockTransfer>()
                .HasOne(p => p.NewWarehouse)
                .WithMany();

            builder.Entity<StockTransfer>()
                .HasOne(p => p.OldWarehouse)
                .WithMany();

            builder.Entity<Supplier>()
                .HasOne(p => p.RefUser)
                .WithMany();

            builder.Entity<Supplier>()
                .HasOne(p => p.Contact)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Supplier>()
                .HasOne(p => p.Address)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Supplier>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<Task>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<Task>()
                .HasOne(p => p.Agent)
                .WithMany();

            builder.Entity<Tenant>()
                .HasOne(p => p.BillingAddress)
                .WithMany();

            builder.Entity<Tenant>()
                .HasOne(p => p.ShippingAddress)
                .WithMany();

            builder.Entity<User>()
                .HasOne(p => p.Location)
                .WithMany();

            builder.Entity<Warehouse>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<Warehouse>()
                .HasOne(p => p.Users)
                .WithMany();

            builder.Entity<User>()
                .HasOne(p => p.Role)
                .WithMany();

            builder.Entity<Role>()
                .HasOne(p => p.CreatedBy)
                .WithMany();

            builder.Entity<User>()
               .HasOne(p => p.CreatedBy)
               .WithMany();

            builder.Entity<Refund>()
               .HasOne(p => p.Status)
               .WithMany();

            builder.Entity<List<User>>(x => x.HasNoKey());

            base.OnModelCreating(builder);

        }
    }
}
