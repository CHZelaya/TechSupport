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

using System.ComponentModel;
using TechSupport.Controllers;
using TechSupport.Models;

namespace TechSupport.Views
{
    public partial class frm_Add_Edit : Form
    {
        // Private fields to store product information passed from the previous form
        private string _productCode;
        private string _name;
        private string _version;
        private string _releaseDate;

        // Controller instance to handle product-related operations
        private ProductController _productController;

        // Constructor accepts product details and initializes the form
        public frm_Add_Edit(string? productCode, string? name, string? version, string? releaseDate)
        {
            InitializeComponent();

            // Using the null-coalescing operator to ensure that fields are never null
            _productCode = productCode ?? string.Empty;
            _name = name ?? string.Empty;
            _version = version ?? string.Empty;
            _releaseDate = releaseDate ?? string.Empty;

            var context = new TechSupportContext();
            _productController = new ProductController(context);

            // Set maximum lengths for text boxes according to database constraints
            textBox_ProductCode.MaxLength = 10;
            textBox_ProductName.MaxLength = 50;
            textBox_ProductVersion.MaxLength = 16;

            //Subscribe to textBox changes to enable OK button

            textBox_ProductCode.TextChanged += TextBox_TextChanged;
            textBox_ProductName.TextChanged += TextBox_TextChanged;
            textBox_ProductVersion.TextChanged += TextBox_TextChanged;

            // Attach validating events for each TextBox to ensure valid input
            //Used this method to avoid having to attach event handlers via toolbox/properties.
            textBox_ProductCode.Validating += TextBox_ProductCode_Validating;
            textBox_ProductName.Validating += TextBox_ProductName_Validating;

        }

        // Utility method watching the textboxes for changes
        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            checkTextBoxes();
        }

        // Helper method being called whenever change in the textboxes is detected.
        //Enables OK button when all textboxes are filled.
        private void checkTextBoxes()
        {
            bool AllFilled = !string.IsNullOrWhiteSpace(textBox_ProductCode.Text) &&
                             !string.IsNullOrWhiteSpace(textBox_ProductName.Text) &&
                             !string.IsNullOrWhiteSpace(textBox_ProductVersion.Text);

            button_OK.Enabled = AllFilled;
        }

        // Event handler for form load to set up the form based on the title
        private void frm_Add_Edit_Load(object sender, EventArgs e)
        {

            button_OK.Enabled = false;
            if (this.Text == "Modify Product")
            {
                // Populate text boxes with existing product data
                textBox_ProductCode.Text = _productCode;
                textBox_ProductName.Text = _name;
                textBox_ProductVersion.Text = _version;
                dtp_ReleaseDate.Text = _releaseDate;
                // Disable the ProductCode TextBox to prevent modification
                textBox_ProductCode.Enabled = false;
            }
            else
            {
                // Clear text boxes for adding a new product
                textBox_ProductCode.Enabled = true;
                textBox_ProductCode.Clear();
                textBox_ProductName.Clear();
                dtp_ReleaseDate.ResetText();
                textBox_ProductVersion.Clear();
            }
        }






        private void button_OK_Click(object sender, EventArgs e)
        {
            // Determine if user is adding or modifying a product
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
            DateTime ReleaseDate = dtp_ReleaseDate.Value.Date;

            // Call utiility method to see if the product already exists in the DB before attempting to add.
            bool productCodeExists = CheckProductCodeExists(ProductCode);

            if (!productCodeExists)
            {

                // Attempt to parse the Version input with error handling
                if (!decimal.TryParse(textBox_ProductVersion.Text, out Version))
                {
                    errorProvider3.SetError(textBox_ProductVersion, "Must be a decimal");
                    //MessageBox.Show("Please enter a valid version number.");
                    return; // Exit if parsing fails
                }
                else if (Version < 0)
                {
                    errorProvider3.SetError(textBox_ProductVersion, "Cannot be a negative number");
                    //MessageBox.Show("Cannot be a negative number");
                    return;
                }
                else errorProvider3.SetError(textBox_ProductVersion, string.Empty);
                if (!ValidatorUtils.IsValidDate(dtp_ReleaseDate))
                {
                    return;
                }

                Product newProduct = new Product
                {
                    ProductCode = ProductCode,
                    Name = Name,
                    Version = Version,
                    ReleaseDate = ReleaseDate
                };

                // Try to add the product to the database and handle any exceptions
                try
                {
                    _productController.AddProduct(newProduct); // Call to controller to add product
                    this.Close(); // Close the form after successful addition
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred adding the product to the Database: {ex.Message}");
                }
            }
        }



        //Utility method checking to see if the Product Code already exists in the DB before attempting to add.
        private bool CheckProductCodeExists(string ProductCode)
        {
            var productToCheck = _productController.GetProductByCode(ProductCode);
            if (productToCheck != null)
            {
                MessageBox.Show($"Product Code already exists in the DB, please update the existing entry ({ProductCode}) or change the Product Code");
                return true;
            }
            else return false;

        }




        private void HandleModifyProduct()
        {
            string ProductCode = textBox_ProductCode.Text;
            string Name = textBox_ProductName.Text;
            decimal Version;
            DateTime ReleaseDate = dtp_ReleaseDate.Value.Date;

            // Attempt to parse the Version input with error handling
            if (!decimal.TryParse(textBox_ProductVersion.Text, out Version))
            {
                MessageBox.Show("Please enter a valid version number.");
                return; // Exit if parsing fails
            }
            else if (Version < 0)
            {
                MessageBox.Show("Cannot be a negative number");
                return;
            }
            if (ValidatorUtils.IsValidDate(dtp_ReleaseDate))
            {
                return;
            }


            // Create a new Product instance for updating
            Product productToUpdate = new Product
            {
                ProductCode = ProductCode,
                Name = Name,
                Version = Version,
                ReleaseDate = ReleaseDate
            };

            // Try to update the product in the database and handle any exceptions
            try
            {
                _productController.UpdateProduct(productToUpdate); // Call to controller to update product
                this.Close(); // Close the form after successful update
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error updating the selected item to the database: {ex}");
            }
        }








        // VALIDATION METHODS
        /* All validation messages are handled within ValidatorUtils */
        /*_____________________________________________________________________________________________________________ */

        // Validate the Product Code TextBox input
        private void TextBox_ProductCode_Validating(object? sender, CancelEventArgs e)
        {
            // Skip validation if the cancel button is clicked
            if (this.ActiveControl is Button)
            {
                return; // Skip validation
            }
            // Validate presence and alphanumeric characters
            if (!ValidatorUtils.IsPresent(textBox_ProductCode) || (!ValidatorUtils.IsAlphanumeric(textBox_ProductCode)))
            {
                errorProvider1.SetError(textBox_ProductCode, "Input cannot be empty and can only be AlphaNumeric");
                e.Cancel = true; // Prevent focus from leaving the TextBox if validation fails
            }

        }

        // Validate the Product Name TextBox input
        private void TextBox_ProductName_Validating(object? sender, CancelEventArgs e)
        {
            if (this.ActiveControl is Button)
            {
                return;
            }
            // Validate presence and alphanumeric characters
            if (!ValidatorUtils.IsPresent(textBox_ProductName) || (!ValidatorUtils.IsAlphanumeric(textBox_ProductName)))
            {
                errorProvider2.SetError(textBox_ProductName, "Input cannot be empty and can only be AlphaNumeric");
                e.Cancel = true; // Prevent focus from leaving the TextBox if validation fails
            }
            else
            {
                errorProvider2.SetError(textBox_ProductName, string.Empty);
            }
        }



        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when cancel is clicked
        }
    }
}


