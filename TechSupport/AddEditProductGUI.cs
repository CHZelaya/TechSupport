using TechSupport.Controllers;
using TechSupport.Models;

namespace TechSupport.Views
{
    public partial class frm_Add_Edit : Form
    {
        // Setting up public variables to grab the values from the first form and set them to the text boxes.

        private string _productCode;
        private string _name;
        private string _version;
        private string _releaseDate;

        private ProductController _productController;



        public frm_Add_Edit(string? productCode, string? name, string? version, string? releaseDate)
        {
            InitializeComponent();
            _productCode = productCode;
            _name = name;
            _version = version;
            _releaseDate = releaseDate;
            var context = new TechSupportContext();
            _productController = new ProductController(context);

        }
        //Set the Form depending on Form title
        private void frm_Add_Edit_Load(object sender, EventArgs e)
        {
            if (this.Text == "Modify Product")
            {
                // Set variables to text boxes
                textBox_ProductCode.Text = _productCode;
                textBox_ProductName.Text = _name;
                textBox_ProductVersion.Text = _version;
                textBox_ProductReleaseDate.Text = _releaseDate;
                //disable ProductCode Textbox
                textBox_ProductCode.Enabled = false;
            }
            else
            {
                textBox_ProductCode.Clear();
                textBox_ProductName.Clear();
                textBox_ProductReleaseDate.Clear();
                textBox_ProductVersion.Clear();
            }
        }




        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.Text == "Add Product")
            {
                HandleAddProduct();
            }
            else if (this.Text == "Modify Product")
            {
                HandleModifyProduct();
            }

        }

        private void HandleAddProduct()
        {

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

        private void HandleModifyProduct()
        {

        }


    }
}


