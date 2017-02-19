using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            calAnswer(); //calculate results
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populate(); //add question on form load
        }

        /*the populate function sets text boxes to default setting 0.  
         * Could have used txtLength.Clear() instead*/
        private void populate()
        {
            txtLength.Text = "0"; 
            txtWidth.Text = "0";
            txtHeight.Text = "0";
            txtArea.Text = "";
            txtPerimeter.Text = "";
            txtVolume.Text = "";

            txtLength.Focus();
        }
        /* calAnswer is the function that processes input.  
         * This is where I would do data validation and exception handling
         */
        private void calAnswer()
        {
            try
            {
                TextBox[] textboxes;// = new TextBox[2] { txtLength, txtWidth };
                if (txtHeight.Text != "0") textboxes = new TextBox[3] { txtLength, txtWidth, txtHeight };
                else textboxes = new TextBox[2] { txtLength, txtWidth };
                //above should lead to an array of text boxes for dataValidation that only includes Height if height is given
                if (dataValidation(textboxes))
                {
                    decimal length = Convert.ToDecimal(txtLength.Text); //change Length to decimal
                    decimal width = Convert.ToDecimal(txtWidth.Text);   //change width to decimal
                    decimal height = Convert.ToDecimal(txtHeight.Text);   //change depth to decimal
                    decimal area;
                    decimal perimeter;
                    

                    if (dataValidation(textboxes))
                    {
                        area = length * width;                      //calculate area
                        perimeter = 2 * (length + width);           //calculate perimeter
                        txtArea.Text = Convert.ToString(area);              //display area
                        txtPerimeter.Text = Convert.ToString(perimeter);    //display perimeter
                    }
                    else
                    {
                        MessageBox.Show("An Exception occured.", "Entry Error");

                    }


                    if (height != 0)
                    {                                     //check if a value for depth has been entered (i.e. object is 3D)
                        decimal volume = length * width * height;                  //calculate volume for 3D
                        txtVolume.Text = Convert.ToString(volume);      //display volume for 3D
                    }

                    btnAC.Focus();
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("An Overflow Exception occured.  Try using smaller numbers.", "Entry Error");
            }
            catch (Exception)
            {
                MessageBox.Show("An Exception occured.", "Entry Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void clearAnswers(object sender, EventArgs e)
        {
            txtArea.Text = "";
            txtPerimeter.Text = "";
            txtVolume.Text = "";
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            populate();
        }

        public bool IsPresent(TextBox textBox, string name) //is there data in the text box?
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        public bool IsNumber(TextBox textBox, string name) //is the data numeric?
        {
            decimal numdec = 0m;
            if (Decimal.TryParse(textBox.Text, out numdec))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        public bool IsInRange(TextBox textBox, string name, decimal min, decimal max) //is the number in the right range?
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min.ToString() + " and " + max.ToString() + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
      
        private bool dataValidation(TextBox[] textBoxes)
            //can only return one error message at a time. (what if two or more entries wrong?)
        {

            foreach (TextBox t in textBoxes)
            {
                string name = "";
                if (t.Name.Contains("L")) name = "Length";      //t.Name.Contains should be txtLength
                else if (t.Name.Contains("W")) name = "Width";  //t.Name.Contains should be txtWidth
                else if (t.Name.Contains("H")) name = "Height"; //t.Name.Contains should be txtHeight
                if (!(IsPresent(t, name) && IsNumber(t, name) && IsInRange(t, name, 1, 1000000)))
                {
                    return false; //if any txtbox evaluates to false, stop checking.
                }
            }

            return true; //should only reach this if they are all true

        }

    }
}
