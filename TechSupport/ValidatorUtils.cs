// ************************************************************************************
// SAIT Class: Fall 2024 RAD for OOSD (CRPG-200-A)
// Author: Carlos Hernandez-Zelaya
// Project Title: CPRG 200 Lab Assignment 2
// ************************************************************************************
namespace TechSupport.Views
{
    static public class ValidatorUtils
    {
        /// <summary>
        /// Tests if there is any input from the user (checks for empty string).
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <returns>True if input is not empty; false if empty.</returns>
        public static bool IsPresent(TextBox textBox)
        {
            bool isValid = true;
            if (textBox.Text == "") // Check if the textbox is empty
            {
                isValid = false;
                //MessageBox.Show($"{textBox.Tag} field is empty");
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the input consists of alphabetic characters only.
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <returns>True if input is alphabetic; false otherwise.</returns>
        public static bool IsAlphabetic(TextBox textBox)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(textBox.Text) || !textBox.Text.All(char.IsLetter))
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} field needs to be alphabetic characters only");
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the input consists of alphanumeric characters, allowing spaces and periods.
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <returns>True if input is alphanumeric; false otherwise.</returns>
        public static bool IsAlphanumeric(TextBox textBox)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(textBox.Text) || !textBox.Text.All(c => char.IsLetterOrDigit(c) || c == '.' || c == ' '))
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} field needs to be alphanumeric characters only \n" +
                    $"Example: (Product Name 1.0)");
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the selected date is within a specified range.
        /// </summary>
        /// <param name="dateTimePicker">The DateTimePicker to be checked.</param>
        /// <returns>True if the date is valid; false otherwise.</returns>
        public static bool IsValidDate(DateTimePicker dateTimePicker)
        {
            //As the first entry in the DB is in 2012, assuming the company started in 2012.
            //Ergo, Release Dates cannot be before 2012.

            DateTime minDate = new DateTime(2012, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime maxDate = DateTime.Today.AddYears(5);

            bool isValid = true;
            if (dateTimePicker.Value.Date < minDate || dateTimePicker.Value.Date > maxDate)
            {
                isValid = false;
                MessageBox.Show($"The selected date must be in between {minDate.ToShortDateString()} & {maxDate.ToShortDateString()}");
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the input can be parsed as a double.
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <returns>True if input is a valid double; false otherwise.</returns>
        public static bool IsDouble(TextBox textBox)
        {
            bool isValid = true;
            double output;

            if (!double.TryParse(textBox.Text, out output))
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} Field contains non-numeric characters");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the input is an integer within the range of 0 to 12.
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <returns>True if input is within the range; false otherwise.</returns>
        public static bool IsInInches(TextBox textBox)
        {
            bool isValid = true;
            int value;

            if (int.TryParse(textBox.Text, out value))
            {
                if (value < 0 || value > 12) // Check to see if the value is equal to 0 or greater than 12
                {
                    isValid = false;
                    MessageBox.Show($"{textBox.Tag} Field must be between 0 and 12 inches");
                    textBox.SelectAll();
                    textBox.Focus();
                }
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the input is a non-negative number.
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <returns>True if input is non-negative; false otherwise.</returns>
        public static bool IsNonNegative(TextBox textBox)
        {
            bool isValid = true;

            if (!double.TryParse(textBox.Text, out double output))
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} Field contains non-numeric characters");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (output < 0)
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} Field must be a non-negative number");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Validates that the input is a double within a specified range.
        /// </summary>
        /// <param name="textBox">The TextBox to be checked.</param>
        /// <param name="min">The minimum allowable value.</param>
        /// <param name="max">The maximum allowable value.</param>
        /// <returns>True if input is within the range; false otherwise.</returns>
        public static bool isDoubleInRange(TextBox textBox, double min, double max)
        {
            bool isValid = true;

            if (!double.TryParse(textBox.Text, out double output))
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} Field contains non-numeric characters");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (output < min || output > max)
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} Field must be within the range of {min} and {max}");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

    }

}