using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator_box : Form
    {
        Double num1 = 0;
        String operationExecuted = "";
        bool isOperationExecuted = false;
        
        public Calculator_box()
        {
            InitializeComponent();
        }
        //==================================================================
        //---------Buttons (individual code)
        //
        //......"C"
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            bx_output.Text = "0";
            passValue_operation.Text = "";
            num1 = 0;
            del_btn.Enabled = true;
        }
        //......"CE"
        private void btn_clear_all_Click(object sender, EventArgs e)
        {
            bx_output.Clear();
            del_btn.Enabled = true;
        }
        //......"="
        private void equals_Click(object sender, EventArgs e)
        {
            try
            {
                switch_ops();
                num1 = Double.Parse(bx_output.Text);
                passValue_operation.Text = "";
            }
            catch
            {
                bx_output.Text = "Math Error!";
            }
        }
        //......"←"
        private void del_btn_Click(object sender, EventArgs e)
        {
            string zero = "0";
            if (bx_output.Text.Length > 1)
            {
                zero = bx_output.Text;
                zero = zero.Substring(0, zero.Length - 1);
            }
            bx_output.Text = zero;
        }
        private void cancelAll_Click(object sender, EventArgs e)
        {
            passValue_operation.Text = "0";
            bx_output.Text = "0";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            bx_output.Text = "0";
        }

        private void posneg_btn_Click(object sender, EventArgs e)
        {
            bx_output.Text = (-1 * Double.Parse(bx_output.Text)).ToString();
        }

        private void btn_sqrt(object sender, EventArgs e)
        {
            bx_output.Text = Math.Sqrt(Double.Parse(bx_output.Text)).ToString();
            num1 = Math.Sqrt(Double.Parse(bx_output.Text));
        }
        //==================================================================
        //--------Buttons (multiple)
        //Number Buttons
        private void btn_num_Click(object sender, EventArgs e)
        {

            if ((bx_output.Text == "0") || (isOperationExecuted))
                bx_output.Clear();

            isOperationExecuted = false;
            Button btn_num = (Button)sender;
            decimal EndResult = 0;
            decimal StoredMemory = 0;

            if (btn_num.Text == ".")
            {
                if (!bx_output.Text.Contains("."))
                    bx_output.Text = bx_output.Text + btn_num.Text;
                if (!bx_output.Text.Contains("0"))
                    bx_output.Text = "0" + btn_num.Text;
            }
            else
                bx_output.Text = bx_output.Text + btn_num.Text;
            
            //Memory Button
            if (btn_num.Text == "MC") //Memory Clear
            {
                StoredMemory = 0;
                return;
            }
            if (btn_num.Text == "MR") //Memory Recall
            {
                bx_output.Text = StoredMemory.ToString();
                return;
            }
            if (btn_num.Text == "M+") //Memory Add
            {
                StoredMemory += EndResult;
                return;
            }
            if (btn_num.Text == "M-") //Memory minus
            {
                StoredMemory -= EndResult;
                return;
            }
            if (btn_num.Text == "MS") //Memory Store
            {
                StoredMemory -= EndResult;
                return;
            }
        }
        //Operations
        private void oper_click(object sender, EventArgs e)
        {
            try
            {
                Button b_Oper = (Button)sender;
                if (num1 != 0)
                {
                    equals_btn.PerformClick();
                    operationExecuted = b_Oper.Text;
                    passValue_operation.Text = num1 + " " + operationExecuted;
                    bx_output.Text = "";
                }
                else
                {
                    operationExecuted = b_Oper.Text;
                    num1 = Double.Parse(bx_output.Text);
                    passValue_operation.Text = bx_output + "" + b_Oper.Text;
                    bx_output.Text = "";
                }
            }
            catch
            {
                bx_output.Text = "Math Error!";
                del_btn.Enabled = false;
            }
        }
        //========================================================================================
        //--------Private voids (made)
        private void switch_ops()
        {
            try
            {
                switch (operationExecuted)
                {
                    //add
                    case "+":
                        bx_output.Text = (num1 + Double.Parse(bx_output.Text)).ToString();
                        break;
                    //minus
                    case "-":
                        bx_output.Text = (num1 - Double.Parse(bx_output.Text)).ToString();
                        break;
                    //divide
                    case "÷":
                        bx_output.Text = (num1 / Double.Parse(bx_output.Text)).ToString();
                        break;
                    //multiply
                    case "*":
                        bx_output.Text = (num1 * Double.Parse(bx_output.Text)).ToString();
                        break;
                    //squared
                    case "x²":
                        bx_output.Text = (num1 * num1).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                bx_output.Text = "Math Error!";

            }
        }
        private void show_hist(object sender, EventArgs e)
        {

        }

        private void Calculator_box_Load(object sender, EventArgs e)
        {

        }

        private void bx_output_TextChanged(object sender, EventArgs e)
        {

        }

        private void squared_btn_Click(object sender, EventArgs e)
        {
        }
    }
}
