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
            txtDepth.Text = "0";
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
            decimal length = Convert.ToDecimal(txtLength.Text); //change Length to decimal
            decimal width = Convert.ToDecimal(txtWidth.Text);   //change width to decimal
            decimal depth = Convert.ToDecimal(txtDepth.Text);   //change depth to decimal
            decimal area;
            decimal perimeter;
             
            if(length!=0 && width!= 0){
                area = length * width;                      //calculate area
                perimeter = 2 * (length + width);           //calculate perimeter
                txtArea.Text = Convert.ToString(area);              //display area
                txtPerimeter.Text = Convert.ToString(perimeter);    //display perimeter
            }
            else
            {
                txtArea.Text = "Please enter both length and width.";
                
            }
            
                
            if (depth !=0){                                     //check if a value for depth has been entered (i.e. object is 3D)
                decimal volume = length * width * depth;                  //calculate volume for 3D
                txtVolume.Text = Convert.ToString(volume);      //display volume for 3D
            }
            
            btnAC.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
    }
}
