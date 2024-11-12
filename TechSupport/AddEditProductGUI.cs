using System.ComponentModel;
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

            // Implementing Null coalescing operator
            // If _productCode is not null, it will be assigned the value of productCode
            // If it is null, it will be assigned an empty string.
            // The variables will never be null.
            _productCode = productCode ?? string.Empty;
            _name = name ?? string.Empty;
            _version = version ?? string.Empty;
            _releaseDate = releaseDate ?? string.Empty;
            var context = new TechSupportContext();
            _productController = new ProductController(context);

            //Implementing maximum lengths to keep textBoxes in accordance with DB constraints.
            textBox_ProductCode.MaxLength = 10;
            textBox_ProductName.MaxLength = 50;

            // Attach validating events for each TextBox
            textBox_ProductCode.Validating += TextBox_ProductCode_Validating;
            textBox_ProductName.Validating += TextBox_ProductName_Validating;
            textBox_ProductVersion.Validating += TextBox_ProductVersion_Validating;
            dtp_ReleaseDate.Validating += Dtp_ReleaseDate_Validating;
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


        // VALIDATION
        /*No error messages as all messages are handled from within ValidatorUtils_________________________________________________________________________________*/
        private void TextBox_ProductCode_Validating(object? sender, CancelEventArgs e)
        {
            if (this.ActiveControl is Button) // Check to see if cancel button is clicked
            {
                return; // Skip validation
            }
            if (!ValidatorUtils.IsPresent(textBox_ProductCode) || (!ValidatorUtils.IsAlphanumeric(textBox_ProductCode)))
            {
                e.Cancel = true; // Prevent focus from leaving the TextBox
            }
        }

        private void TextBox_ProductName_Validating(object? sender, CancelEventArgs e)
        {
            if (this.ActiveControl is Button) // Check to see if cancel button is clicked
            {
                return; // Skip validation
            }
            if (!ValidatorUtils.IsPresent(textBox_ProductName) || (!ValidatorUtils.IsAlphanumeric(textBox_ProductName)))
            {
                e.Cancel = true;
            }
        }

        private void TextBox_ProductVersion_Validating(object? sender, CancelEventArgs e)
        {
            if (this.ActiveControl is Button) // Check to see if cancel button is clicked
            {
                return; // Skip validation
            }
            if (!ValidatorUtils.IsNonNegative(textBox_ProductVersion))
            {
                e.Cancel = true;
            }
        }

        private void Dtp_ReleaseDate_Validating(object? sender, CancelEventArgs e)
        {
            if (this.ActiveControl is Button) // Check to see if cancel button is clicked
            {
                return; // Skip validation
            }
            if (!ValidatorUtils.IsValidDate(dtp_ReleaseDate))
            {
                e.Cancel = true;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


