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
            PopulateListBox();
        }



        // EVENT HANDLERS
        /*___________________________________________________________________________________________________________ */

        private void btn_Add_Click(object sender, EventArgs e)
        {
            HandleAddBtnClick();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            HandleModifyBtnClick();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            HandleRemoveBtnClick();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            HandlgeExitBtnClick();
        }



        /// <summary>
        /// Method being called on Load
        /// </summary>

        private void PopulateListBox()
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

        /// <summary>
        /// Refresh the main page when the second form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditProductForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Refresh the product list in the ListBox
            listBox_Data.Items.Clear();
            var products = _productController.GetProducts();
            foreach (var product in products)
            {
                listBox_Data.Items.Add(product.ToString());
            }
            MessageBox.Show("ListBox refreshed with updated data!");
        }




        // EVENT HANDLER LOGIC  
        /*___________________________________________________________________________________________________________ */
        private void HandleAddBtnClick()
        {
            //Create an instance of AddEditProductGUI form
            frm_Add_Edit addEditProductForm = new frm_Add_Edit(null, null, null, null);
            // Subscribe to the FormClosed event
            addEditProductForm.FormClosed += AddEditProductForm_FormClosed;

            // Set the title of the form
            addEditProductForm.Text = "Add Product";

            //Show second form
            addEditProductForm.Show();
        }


        private void HandleModifyBtnClick()
        {
            //Turn value into a string to pass on to second form
            string? selectedItem = listBox_Data.SelectedItem?.ToString();

            if (selectedItem != null)
            {



                // Define the total widths for each field
                int codeWidth = 15;    // Width for ProductCode
                int nameWidth = 40;    // Width for Name
                int versionWidth = 11;  // Width for Version
                int dateWidth = 15;     // Width for ReleaseDate


                // Extract the ProductCode, Name, Version, and ReleaseDate from the selected item
                string productCode = selectedItem.Substring(0, codeWidth).Trim(); // First 15 characters for ProductCode
                string name = selectedItem.Substring(codeWidth, nameWidth).Trim(); // Next 40 characters for Name
                string version = selectedItem.Substring(codeWidth + nameWidth, versionWidth).Trim(); // Next 11 characters for Version
                string releaseDate = selectedItem.Substring(codeWidth + nameWidth + versionWidth, dateWidth).Trim(); // Next 15 characters for ReleaseDate

                //Create an instance of AddEditProductGUI form
                frm_Add_Edit addEditProductForm = new frm_Add_Edit(productCode, name, version, releaseDate);
                // Subscribe to the FormClosed event
                addEditProductForm.FormClosed += AddEditProductForm_FormClosed;
                addEditProductForm.Text = "Modify Product";
                //Show second form
                addEditProductForm.Show();
            }
            else
            {
                MessageBox.Show("Please select an item from the list to continue.");
            }
        }



        private static void HandlgeExitBtnClick()
        {
            MessageBox.Show("Exit clicked!");
        }

        private static void HandleRemoveBtnClick()
        {
            MessageBox.Show("Remove Clicked!");
        }
    }
}
