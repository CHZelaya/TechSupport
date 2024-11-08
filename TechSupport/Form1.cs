using TechSupport.Controllers; // Ensure you have the correct namespace for ProductController
using TechSupport.Models; // Ensure you have the correct namespace for Product

namespace TechSupport
{

    public partial class Form1 : Form
    {
        private ProductController _productController;
        public Form1()
        {
            InitializeComponent();
            var context = new TechSupportContext();
            _productController = new ProductController(context);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Clear existing items in the ListBox
            listBox_Data.Items.Clear();

            // Retrieve products from the database
            var products = _productController.GetProducts(); // Assuming 'GetProducts' is a method in ProductController that retrieves products

            // Add each product to the ListBox using the overridden ToString() method
            foreach (var product in products)
            {
                listBox_Data.Items.Add(product.ToString());
            }
        }
    }
}
