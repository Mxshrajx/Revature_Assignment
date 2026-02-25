using Microsoft.EntityFrameworkCore;

// ----------------------------
// MAIN PROGRAM
// ----------------------------

using var context = new CrmContext();

// Apply migrations automatically
context.Database.Migrate();

// Seed initial data
SeedData(context);

Console.WriteLine("=================================");
Console.WriteLine("ALL CUSTOMERS");
Console.WriteLine("=================================");

var customers = context.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}");
}


// =================================
// PROJECTION + ANONYMOUS TYPES
// =================================

Console.WriteLine("\nFILTER -> SORT -> SELECT");

var resultsA = context.Customers
    .Where(c => c.Email.Contains("@example.com"))
    .OrderBy(c => c.Name)
    .Select(c => new { c.CustomerId, c.Name, c.Email })
    .ToList();

foreach (var item in resultsA)
{
    Console.WriteLine($"Id: {item.CustomerId}, Name: {item.Name}, Email: {item.Email}");
}

Console.WriteLine("\nFILTER -> SELECT -> SORT");

var resultsB = context.Customers
    .Where(c => c.Name.Length >= 4)
    .Select(c => new { c.Name, c.Email })
    .OrderBy(c => c.Name)
    .ToList();

foreach (var item in resultsB)
{
    Console.WriteLine($"Name: {item.Name}, Email: {item.Email}");
}


// =================================
// EAGER LOADING
// =================================

Console.WriteLine("\n=================================");
Console.WriteLine("EAGER LOADING");
Console.WriteLine("=================================");

var eagerCustomers = context.Customers
    .Include(c => c.Orders)
    .ToList();

foreach (var customer in eagerCustomers)
{
    Console.WriteLine($"Customer: {customer.Name}");

    foreach (var order in customer.Orders)
    {
        Console.WriteLine($"   Order Amount: {order.TotalAmount}");
    }
}


// =================================
// LAZY LOADING
// =================================

Console.WriteLine("\n=================================");
Console.WriteLine("LAZY LOADING");
Console.WriteLine("=================================");

var lazyCustomer = context.Customers.First();

Console.WriteLine($"Customer: {lazyCustomer.Name}");

// Orders load automatically here
foreach (var order in lazyCustomer.Orders)
{
    Console.WriteLine($"   Order Amount: {order.TotalAmount}");
}


// =================================
// EXPLICIT LOADING
// =================================

Console.WriteLine("\n=================================");
Console.WriteLine("EXPLICIT LOADING");
Console.WriteLine("=================================");

var explicitCustomer = context.Customers.First();

context.Entry(explicitCustomer)
       .Collection(c => c.Orders)
       .Load();

Console.WriteLine($"Customer: {explicitCustomer.Name}");

foreach (var order in explicitCustomer.Orders)
{
    Console.WriteLine($"   Order Amount: {order.TotalAmount}");
}



// ----------------------------
// SEED METHOD
// ----------------------------

static void SeedData(CrmContext context)
{
    if (!context.Customers.Any())
    {
        var alice = new Customer { Name = "Alice", Email = "alice@example.com" };
        var bob = new Customer { Name = "Bob", Email = "bob@example.com" };

        context.Customers.AddRange(alice, bob);
        context.SaveChanges();

        context.Orders.AddRange(
            new Order { CustomerId = alice.CustomerId, OrderDate = DateTime.Now, TotalAmount = 500 },
            new Order { CustomerId = alice.CustomerId, OrderDate = DateTime.Now, TotalAmount = 800 },
            new Order { CustomerId = bob.CustomerId, OrderDate = DateTime.Now, TotalAmount = 300 }
        );

        context.SaveChanges();
    }
}



// ----------------------------
// DB CONTEXT (MYSQL VERSION)
// ----------------------------

public class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;database=crmDemo;user=root;password=Vishal@2211";

        optionsBuilder
            .UseLazyLoadingProxies()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerType>()
            .HasData(
                new CustomerType { Id = 1, TypeName = "Regular" },
                new CustomerType { Id = 2, TypeName = "Premium" }
            );

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);
    }
}



// ----------------------------
// ENTITIES
// ----------------------------

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public virtual List<Order> Orders { get; set; } = new();
}

public class CustomerType
{
    public int Id { get; set; }
    public string TypeName { get; set; } = string.Empty;

    public virtual List<Customer> Customers { get; set; } = new();
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
}