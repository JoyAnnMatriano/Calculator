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
        Double resultValue = 0;
        String operationExecuted = "";
        String operationExecuted2 = "";
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
            resultValue = 0;
        }
        //......"CE"
        private void btn_clear_all_Click(object sender, EventArgs e)
        {
            bx_output.Text = "0";
        }
        //......"="
        private void equals_Click(object sender, EventArgs e)
        {
            switch_ops();
            resultValue = Double.Parse(bx_output.Text);
            passValue_operation.Text = "";
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
            resultValue = Math.Sqrt(Double.Parse(bx_output.Text));
        }
        //==================================================================
        //--------Buttons (multiple)
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
        private void oper_click(object sender, EventArgs e)
        {
            Button b_Oper = (Button)sender;
            if (resultValue != 0)
            {
                if (b_Oper.Text == "√")
                    bx_output.Text = Math.Sqrt(Double.Parse(bx_output.Text)).ToString();
                equals_btn.PerformClick();
                operationExecuted = b_Oper.Text;
                passValue_operation.Text = resultValue + " " + operationExecuted;
                isOperationExecuted = true;
            }
            else if (b_Oper.Text == "√")
            {
                bx_output.Text = Math.Sqrt(Double.Parse(bx_output.Text)).ToString();
                resultValue = Math.Sqrt(Double.Parse(bx_output.Text));
            }
            else
            {
                operationExecuted = b_Oper.Text;
                resultValue = Double.Parse(bx_output.Text);
                passValue_operation.Text = resultValue + " " + operationExecuted;
                isOperationExecuted = true;
            }
        }
        //========================================================================================
        //--------Private voids (made)
        //for history buttons
        private void checks_Ops()
        {
            //Will check: No operation on the display at all
            if (operationExecuted == string.Empty)
            {

            }

            //Will Check: No operation and if the box output is 0
            else if (operationExecuted == string.Empty && bx_output.Text == "0")
            {

            }

            //Will Check: when there is an operation in the box output
            else if (operationExecuted != string.Empty)
            {
                //will act if the case is called out
                switch_ops();
            }

            //Will Check: when there is an operation in the box output (for double ops)
            else if (operationExecuted2 != string.Empty)
            {
                try
                {
                    switch_ops();
                }
                catch (Exception)
                {
                    bx_output.Text = "Math Error!";
                }
            }
        }
        private void switch_ops()
        {
            switch (operationExecuted)
            {
                //add
                case "+":
                    bx_output.Text = (resultValue + Double.Parse(bx_output.Text)).ToString();
                    break;
                //minus
                case "-":
                    bx_output.Text = (resultValue - Double.Parse(bx_output.Text)).ToString();
                    break;
                //divide
                case "÷":
                    bx_output.Text = (resultValue / Double.Parse(bx_output.Text)).ToString();
                    break;
                //multiply
                case "*":
                    bx_output.Text = (resultValue * Double.Parse(bx_output.Text)).ToString();
                    break;
                //squared
                case "x²":
                    bx_output.Text = (resultValue * resultValue).ToString();
                    break;
                case "²":
                    bx_output.Text = (Double.Parse(bx_output.Text) * Double.Parse(bx_output.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
        private void show_hist(object sender, EventArgs e)
        {

        }

        private void Calculator_box_Load(object sender, EventArgs e)
        {

        }

        private void txbx_his_mem_TextChanged(object sender, EventArgs e)
        {

        }

        private void trash_btn_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bx_output_TextChanged(object sender, EventArgs e)
        {

        }

        private void squared_btn_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "²";
        }
    }
}
