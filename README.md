# TechSupport

## Product Maintenance Application
✅ (Copy-Paste Checkmark as you complete tasks)
### To-Do List
1. **Set Up Entity Framework Core Database First**  
  - ✅ Create Models folder for generated classes. 
  - ✅ Ensure correct setup of Entity Framework in the project.

3. **Develop Main Form**  
  - ✅ Implement data display for all products using a ListBox or ComboBox.
  - ✅ Override the `ToString()` method for product display.
  - ✅ Add functionality for Add, Modify, and Remove operations.
  - ✅ Refresh data on the main form after each operation.
  - ✅ Implement Exit button functionality.

4. **Develop Second Form**  
  - ✅ Design modal form for Add and Modify operations.
  - ✅ Display appropriate title and input fields based on the operation.
  - ❌ Implement data validation:
    - ❌ Limit character input in text boxes.
    - ❌ Validate the release date format.
    - ✅ Disable Product Code field during modification.

5. **Apply Professional Design**  
  - ✅ Ensure a clear and user-friendly interface.
  - ✅ Use meaningful control names.

6. **Code Documentation**  
  - ❌ Add top block comments to each code file:
    - ❌ Purpose of the module/class.
    - ❌ Date created (at least month and year).
    - ❌ Author’s name.
  - ❌ Comment each method explaining its purpose.
  - ❌ Comment each variable to explain its meaning.
  - ❌ Add comments for groups of statements performing a single task.

7. **Testing and Submission**  
  - ❌ Test the application thoroughly to ensure all features work as expected.
  - ❌ Zip the entire project folder and submit to the appropriate Dropbox on D2L.

### Recommended Task Order

1. **Set Up Entity Framework Core Database First**  
   - **Priority**: High  
   - **Reason**: Setting up the database context and models is foundational. It allows you to interact with the database and retrieve data, which is essential for the rest of the application.

2. **Develop Main Form**  
   - **Priority**: High  
   - **Reason**: The main form is the primary interface for users to interact with the product data. Implementing this first allows you to test data retrieval and display functionality early on.

3. **Develop Second Form**  
   - **Priority**: Medium  
   - **Reason**: The second form is used for adding and modifying products. Once the main form is functional, you can focus on the modal form to handle user input for DML operations.

4. **Implement Data Validation**  
   - **Priority**: Medium  
   - **Reason**: Validating user input is crucial for maintaining data integrity. This can be done while developing the second form, ensuring that the application behaves correctly when users enter data.

5. **Apply Professional Design**  
   - **Priority**: Medium  
   - **Reason**: While aesthetics are important, they can be refined after the core functionality is in place. Focus on usability and clarity as you develop the forms.

6. **Code Documentation**  
   - **Priority**: Low (but ongoing)  
   - **Reason**: Documentation should be integrated into your workflow. As you write code, add comments and documentation to ensure clarity. This can also be revisited after the main functionality is complete.

7. **Testing and Submission**  
   - **Priority**: High (final step)  
   - **Reason**: Thorough testing is essential to ensure that all features work as expected before submission. This should be the last step after all functionality is implemented.

## Project Overview

### Objectives
In this lab, you will practice working with **Entity Framework Database First** to retrieve data from a table and perform DML operations. You will create a Windows Forms application called **ProductMaintenance** that allows the user to maintain products within a tech support database.

### Problem Description
You will work with a database related to tech support. The application will consist of two forms, as described below.

### Main Form
- Displays data of all products and allows the user to select one.
- Optionally, allows the user to select a product code from a combo box and display it in read-only text boxes.
- Implements buttons for **Add**, **Modify**, and **Remove** operations, followed by a data refresh.
- Includes an **Exit** button to terminate the application.

### Second Form
- Displays as a modal form when the user clicks **Add** or **Modify**.
- Shows empty text boxes for Add operations and pre-fills for Modify operations.
- Validates user input by:
  - Limiting character lengths to match database column sizes.
  - Ensuring the release date is valid.
- Disables the Product Code field during modification.

### General Requirements
- The design of the forms is flexible but should prioritize professionalism and clarity.
- Include the following comments:
  - Top block comments on each code file describing its purpose, creation date, and author.
  - Comments for each method explaining their purpose.
  - Comments for each variable explaining their meaning.
  - Comments for groups of statements performing a single task.

### Submission Instructions
- Zip the entire folder with your application and submit it to the appropriate Dropbox on D2L before the due date.
- Late submissions will incur a penalty of 3 points per day unless a valid reason is provided.

## Marking Scheme
| Marking Component                                                      | Out of |
|------------------------------------------------------------------------|--------|
| Entity Framework is correctly set up                                   | 5      |
| Data from Products table is retrieved and displayed                   | 5      |
| Insert operation adds row to Products table                           | 5      |
| Update operation modifies selected row                                 | 5      |
| Delete operation removes selected row                                   | 5      |
| User inputs are validated                                              | 5      |
| User forms have all needed controls with meaningful names, and are neat and straightforward to use | 5      |
| Code is clear, uses good naming practices, and has comments as required | 5      |
| **Total:**                                                             | **40** |
