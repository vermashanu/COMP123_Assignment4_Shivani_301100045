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


            }
        }
    }
}

        

        

