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
            _productCode = productCode ?? string.Empty;
            _name = name ?? string.Empty;
            _version = version ?? string.Empty;
            _releaseDate = releaseDate ?? string.Empty;
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
                dtp_ReleaseDate.Text = _releaseDate;
                //disable ProductCode Textbox
                textBox_ProductCode.Enabled = false;
            }
            else
            {
                textBox_ProductCode.Enabled = true;
                textBox_ProductCode.Clear();
                textBox_ProductName.Clear();
                dtp_ReleaseDate.ResetText();
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
            DateTime ReleaseDate = dtp_ReleaseDate.Value;

            // Parse the Version and ReleaseDate with error handling
            if (!decimal.TryParse(textBox_ProductVersion.Text, out Version))
            {
                MessageBox.Show("Please enter a valid version number.");
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured adding the product to the Database: {ex.Message}");
            }
        }

        private void HandleModifyProduct()
        {
            string ProductCode = textBox_ProductCode.Text;
            string Name = textBox_ProductName.Text;
            decimal Version;
            DateTime ReleaseDate = dtp_ReleaseDate.Value;

            // Parse the Version and ReleaseDate with error handling
            if (!decimal.TryParse(textBox_ProductVersion.Text, out Version))
            {
                MessageBox.Show("Please enter a valid version number.");
                return;
            }

            //Creating a new Product instance
            Product productToUpdate = new Product
            {
                ProductCode = ProductCode,
                Name = Name,
                Version = Version,
                ReleaseDate = ReleaseDate
            };

            try
            {
                _productController.UpdateProduct(productToUpdate);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error updating the selected item to the database: {ex}");
            }
        }


    }
}


