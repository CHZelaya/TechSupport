using TechSupport.Controllers;
using TechSupport.Models;

namespace TechSupport.Views
{
    public partial class frm_Add_Edit : Form
    {
        private ProductController _productController;
        public frm_Add_Edit()
        {
            InitializeComponent();
            var context = new TechSupportContext();
            _productController = new ProductController(context);
        }


        private void button_OK_Click(object sender, EventArgs e)
        {
            //Expected variables
            /*string ProductCode
            string Name
            decimal Version
            Datetime ReleaseDate */


            string ProductCode = textBox_ProductCode.Text;
            string Name = textBox_ProductName.Text;
            decimal Version;
            DateTime ReleaseDate;

            // Parse the Version and ReleaseDate with error handling
            if (!decimal.TryParse(textBox_ProductVersion.Text, out Version))
            {
                MessageBox.Show("Please enter a valid version number.");
                return;
            }

            if (!DateTime.TryParse(textBox_ProductReleaseDate.Text, out ReleaseDate))
            {
                MessageBox.Show("Please enter a valid release date.");
                return;
            }

            //Creating a new Product instance
            Product newProduct = new Product
            {
                ProductCode = ProductCode,
                Name = Name,
                Version = Version,
                ReleaseDate = ReleaseDate
            };

            //Try to add the product to the database

            try
            {
                _productController.AddProduct(newProduct); // AddProduct method is in the controller
                MessageBox.Show("Product Added Successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured adding the product to the Database: {ex.Message}");
            }

        }



    }


}
