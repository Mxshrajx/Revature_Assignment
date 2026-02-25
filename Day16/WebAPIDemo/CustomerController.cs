using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private static readonly List<Customer> customers =
    [
        new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "", Source = "Website", Status = "New", Budget = 1000 },
        new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "", Source = "Referral", Status = "Contacted", Budget = 2000 }
    ];

    [HttpGet]
    public ActionResult<List<Customer>> GetAllCustomers()
    {
        return Ok(customers);
    }
}