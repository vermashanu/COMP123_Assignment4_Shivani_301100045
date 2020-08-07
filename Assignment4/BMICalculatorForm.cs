using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class BMICalculatorForm : Form
    {
        public BMICalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculateBMIButton_Click(object sender, EventArgs e)
        {
            // Declare local variables to store input and calculated values
            double height = 0;
            double weight = 0;
            double bmi = 0;

            // Determine height is not a numeric value
            if (!double.TryParse(HeightTextBox.Text, out height))
            {
                MessageBox.Show("Height must be a numeric value", "Invalid Input!");
                HeightTextBox.Focus();
            }
            // Determine weight is not a numeric value
            else if (!double.TryParse(WeightTextBox.Text, out weight))
            {
                MessageBox.Show("Weight must be a numeric value", "Invalid Input!");
                WeightTextBox.Focus();
            }
            else // If both inputs are OK then calculate the BMI
            {
                // Determine which measurement units has selected
                if (ImperialRadioButton.Checked)
                {
                    // If imperial unit has selected
                    bmi = (weight * 703) / (height * height);
                }
                else
                {
                    // If metric unit has selected
                    bmi = weight / (height * height);
                }

                // Display calculated BMI
                BmiTextBox.Text = bmi.ToString("N2");

                // Call DisplayResult() method to display BMI status and update progress bar
                DisplayResult(bmi);
            }
        }

        /// <summary>
        /// Set controls value as defult
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            HeightTextBox.Clear();
            WeightTextBox.Clear();
            BmiTextBox.Clear();
            ResultTextBox.Clear();
            BmiProgressBar.Value = 0;
            ImperialRadioButton.Checked = true;
            ImperialRadioButton.Focus();
        }

        /// <summary>
        /// Display BMI result and update progress bar value and color
        /// </summary>
        /// <param name="bmi"></param>
        private void DisplayResult(double bmi)
        {
            // If bmi greater than MAX(100) value
            if (bmi > 100)
            {
                BmiProgressBar.Value = 100;
            }
            else if (bmi < 0) // if bmi less than MIN(0) value
            {
                BmiProgressBar.Value = 0;
            }
            else
            {
                BmiProgressBar.Value = (int)(bmi); // set progress bar value
            }

            // Display BMI report and set progress bar color as per BMI range
            if (bmi < 18.5)
            {
                ResultTextBox.Text = "Underweight" + Environment.NewLine + "(less than 18.5)";
                BmiProgressBar.ForeColor = Color.Red;
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                ResultTextBox.Text = "Normal" + Environment.NewLine + "(18.5 - 24.9)";
                BmiProgressBar.ForeColor = Color.Green;
            }
            else if (bmi >= 25 && bmi < 30)
            {
                ResultTextBox.Text = "Overweight" + Environment.NewLine + "(25 - 29.9)";
                BmiProgressBar.ForeColor = Color.Yellow;
            }
            else
            {
                ResultTextBox.Text = "Obese" + Environment.NewLine + "(30 or greater)";
                BmiProgressBar.ForeColor = Color.Maroon;
            }
        }

        
    }
}

