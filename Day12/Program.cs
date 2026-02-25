using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

CrmContext _context = new CrmContext();

// Ensure database and tables exist
_context.Database.EnsureCreated();

// Fetch customers with Age > 20
var customers = _context.Customers
    .Where(e => e.Age > 20)
    .ToList();

Console.WriteLine($"Customers Count: {customers.Count()}");

// Add new customer to database
_context.Customers.Add(new Customer { Name = "Danny Lee", Age = 30 });
_context.SaveChanges();

// Update customer
var john = _context.Customers.FirstOrDefault(c => c.Name == "John Doe");
if (john != null)
{
    john.Age = 31;
    _context.SaveChanges();
}

// Display customers
foreach (var customer in _context.Customers.ToList())
{
    Console.WriteLine($"Id: {customer.Id} Customer: {customer.Name}, Age: {customer.Age}");
}

// Dispose context
_context.Dispose();

class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "server=localhost;port=3306;database=StudentDB1;user=root;password=Vishal@2211;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Product { get; set; } = string.Empty;

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
}

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}