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
            // Fetch products using the controller
            List<Product> products = _productController.GetProducts();

            // Clear existing items in the ListBox
            listBox_Data.Items.Clear();

            // Populate the ListBox with product names or any other property
            foreach (var product in products)
            {
                listBox_Data.Items.Add(product.Name); // Assuming 'Name' is a property of Product
            }
        }
    }
}
