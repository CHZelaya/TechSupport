namespace TechSupport.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using TechSupport.Models;

    public class ProductController
    {
        private readonly TechSupportContext _context;

        public ProductController(TechSupportContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // Additional methods for adding, updating, and deleting products can be added here
    }
}
