/*
 * Course: Rapid Application Development
 * Class Code: CPRG 200
 * Assignment Name: Lab 3 - Tech Support WinForms App
 * Date: Thursday, November 14, 2024
 * Author: Carlos Hernandez-Zelaya
 * 
 * Lab Purpose: 
 * This lab focuses on using Entity Framework Database First to retrieve data 
 * and perform DML operations in a Windows Forms application for managing 
 * products in a tech support database.
 */

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

        /// <summary>
        /// Fetch's products from the database
        /// </summary>
        /// <returns>Returns a list of of the Products from the DB.</returns>
        public static List<Product> GetProducts()
        {
            using (var context = new TechSupportContext())
            {
                return context.Products.ToList();
            }
        }

        /// <summary>
        /// Method used to Add products to the Database
        /// </summary>
        /// <param name="product">The product to be added</param>
        /// <exception cref="ArgumentNullException">Thrown when the product is null</exception>
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            //Add the product to the context
            _context.Products.Add(product);
            //Save the changes to the database.
            _context.SaveChanges();
        }

        /// <summary>
        /// Update the product selected and save changes into the DB
        /// </summary>
        /// <param name="product">The product to be updated</param>
        /// <exception cref="ArgumentNullException">Thrown when the product is null</exception>
        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            //Update the product to the context
            _context.Products.Update(product);
            //Save the changes to the database.
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete the product from the Database.
        /// </summary>
        /// <param name="product">The product to be deleted.</param>
        /// <exception cref="ArgumentNullException">Thrown when the product is null.</exception>
        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            //Delete the product from the context
            _context.Products.Remove(product);
            //Save the changes to the database.
            _context.SaveChanges();
        }

        public Product GetProductByCode(string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                throw new ArgumentNullException(nameof(productCode), "Product Code cannot be null or empty");
            }
            else
            {
                // Retrieve the product from the database
                var product = _context.Products.FirstOrDefault(p => p.ProductCode == productCode);

                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with code '{productCode}' not found.");
                }

                return product;
            }

        }
    }
}
