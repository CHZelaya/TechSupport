using TechSupport.Controllers; // Ensure you have the correct namespace for ProductController
using TechSupport.Models; // Ensure you have the correct namespace for Product


namespace TechSupport.Views
{

    public partial class ProductMaintenanceGUI : Form
    {
        private ProductController _productController;
        public ProductMaintenanceGUI()
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
            var products = _productController.GetProducts(); // Grabbing Products from DB and assigning to products.

            // Add each product to the ListBox using the overridden ToString() method
            foreach (var product in products)
            {
                listBox_Data.Items.Add(product.ToString());
            }
        }



        // Button will bring up second form with empty fields.
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //Create an instance of AddEditProductGUI form

            frm_Add_Edit addEditProductForm = new frm_Add_Edit();

            //Show second form
            addEditProductForm.Show();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modify Clicked!");
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remove Clicked!");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exit clicked!");
        }
    }
}
