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

using TechSupport.Controllers;
using TechSupport.Models;


namespace TechSupport.Views
{

    public partial class ProductMaintenanceGUI : Form
    {
        // Controller instance to manage product-related operations
        private ProductController _productController;

        // Constructor initializes the form and controller
        public ProductMaintenanceGUI()
        {
            InitializeComponent();
            var context = new TechSupportContext(); // Initialize database context
            _productController = new ProductController(context); // Initialize the product controller with context
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateListBox();
        }

        // ON LOAD METHOD
        /*___________________________________________________________________________________________________________ */

        private void PopulateListBox()
        {
            // Clear existing items in the ListBox to avoid duplicates
            listBox_Data.Items.Clear();

            // Retrieve products from the database via the controller
            var products = ProductController.GetProducts();

            // Add each product to the ListBox using the overridden ToString() method for display
            foreach (var product in products)
            {
                listBox_Data.Items.Add(product.ToString());
            }
        }

        // EVENT HANDLERS
        /*___________________________________________________________________________________________________________ */

        // Event handler for the Add button click
        private void btn_Add_Click(object sender, EventArgs e)
        {
            HandleAddBtnClick();
        }

        // Event handler for the Modify button click
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            HandleModifyBtnClick();
        }

        // Event handler for the Remove button click
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            HandleRemoveBtnClick();
        }

        // Event handler for the Exit button click
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            HandleExitButton();
        }

        // EVENT HANDLER LOGIC
        /*___________________________________________________________________________________________________________ */


        private void HandleAddBtnClick()
        {
            // Create an instance of the add/edit form with no initial data (for adding)
            frm_Add_Edit addEditProductForm = new frm_Add_Edit(null, null, null, null);
            // Subscribe to the FormClosed event to refresh data when the form is closed
            addEditProductForm.FormClosed += AddEditProductForm_FormClosed;

            // Set the form title to indicate adding a product
            addEditProductForm.Text = "Add Product";

            // Display the add/edit form
            addEditProductForm.Show();
        }

        private void HandleModifyBtnClick()
        {
            string? selectedItem = listBox_Data.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                string productCode, name, version, releaseDate;
                // Extract product details from the selected item
                TrimWhiteSpace(selectedItem, out productCode, out name, out version, out releaseDate);

                // Create an instance of the add/edit form with existing data (for modification)
                frm_Add_Edit addEditProductForm = new frm_Add_Edit(productCode, name, version, releaseDate);

                addEditProductForm.FormClosed += AddEditProductForm_FormClosed;
                addEditProductForm.Text = "Modify Product";

                addEditProductForm.Show();
            }
            else
            {
                // Show a message if no item is selected
                MessageBox.Show("Please select an item from the list to continue.");
            }
        }

        // Utility method to trim whitespace from product details in the selected item
        private static void TrimWhiteSpace(string? selectedItem, out string productCode, out string name, out string version, out string releaseDate)
        {
            int codeWidth = 15;
            int nameWidth = 40;
            int versionWidth = 11;
            int dateWidth = 15;

            // Extract and trim each component from the selected item based on predefined widths
            productCode = selectedItem.Substring(0, codeWidth).Trim();
            name = selectedItem.Substring(codeWidth, nameWidth).Trim();
            version = selectedItem.Substring(codeWidth + nameWidth, versionWidth).Trim();
            releaseDate = selectedItem.Substring(codeWidth + nameWidth + versionWidth, dateWidth).Trim();
        }

        private static void HandleExitButton()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?",
                                                  "Exit Confirmation",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            // Exit the application if the user confirms
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HandleRemoveBtnClick()
        {
            string? selectedItem = listBox_Data.SelectedItem?.ToString();
            string productCode;

            if (selectedItem != null)
            {
                int codeWidth = 15;
                productCode = selectedItem.Substring(0, codeWidth).Trim();

                try
                {
                    // Show a confirmation dialog before removing the item
                    DialogResult result = MessageBox.Show("Are you sure you wish to delete this item?", "Delete Confirmation",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Exclamation);

                    if (result == DialogResult.Yes)
                    {
                        // Retrieve the product to be deleted using the product code
                        Product itemToBeDeleted = _productController.GetProductByCode(productCode);
                        if (itemToBeDeleted != null)
                        {
                            // Delete the product and refresh the ListBox
                            _productController.DeleteProduct(itemToBeDeleted);
                            MessageBox.Show("Selected Item Deleted", "Item Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateListBox(); // Refresh the ListBox
                        }
                        else
                        {
                            // Show a message if the product was not found
                            MessageBox.Show("Product not Found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Show an error message if an exception occurs
                    MessageBox.Show($"An error occurred: {ex}");
                }
            }
            else
            {
                // Show a message if no item is selected
                MessageBox.Show("Please select an item before attempting to remove it from the list");
            }
        }

        private void AddEditProductForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Clear and refresh the ListBox with updated product data
            listBox_Data.Items.Clear();
            var products = ProductController.GetProducts();
            foreach (var product in products)
            {
                listBox_Data.Items.Add(product.ToString());
            }
        }
    }
}