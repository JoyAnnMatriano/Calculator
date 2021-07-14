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
        numDefault def = new numDefault();

        public Calculator_box()
        {
            InitializeComponent();

            Historydefault();
            Memorydefault();

            MClear.Enabled = false;
            MReall.Enabled = false;
            MShow.Enabled = false;

            del_btn.Enabled = true;
        }
        //==================================================================
        //---------Buttons (individual code)
        //
        //......"C"
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            bx_output.Text = "0";
            passValue_operation.Text = " ";
        }
        //......"CE"
        private void btn_clear_all_Click(object sender, EventArgs e)
        {
            bx_output.Clear();
            passValue_operation.Clear();
            del_btn.Enabled = true;
        }
        //......"="
        private void equals_Click(object sender, EventArgs e)
        {
            def.num2 = Double.Parse(bx_output.Text);
            try
            {
                switch (def.operationExecuted)
                {
                    //add
                    case "+":
                        Add();
                        showValue_OP();
                        SaveHistory();
                        break;
                    //minus
                    case "-":
                        Minus();
                        showValue_OP();
                        SaveHistory();
                        break;
                    //divide
                    case "÷":
                        Divide();
                        showValue_OP();
                        SaveHistory();
                        break;
                    //multiply
                    case "x":
                        Multiply();
                        showValue_OP();
                        SaveHistory();
                        break;
                    //percent
                    case "%"://to improve pa, kulang din sa code
                        Percent();
                        showValue_OP();
                        SaveHistory();
                        break;
                    //squared
                    case "x²":
                        Squared();
                        passValue_operation.Text = (def.num1 + "²");
                        SaveHistory();
                        break;
                    //recirpocal
                    case "1 / x":
                        Reciprocal();
                        passValue_operation.Text = ("1/(" + def.num1 + ")");
                        SaveHistory();
                        break;
                    default:
                        break;
                }
                def.num1 = Double.Parse(bx_output.Text);
                def.operationExecuted = " ";
            }
            catch
            {
                bx_output.Text = "Math Error!";
                del_btn.Enabled = false;
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
            def.num1 = 0;
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
            passValue_operation.Text = ("sqrt("+Math.Pow(Double.Parse(bx_output.Text),2)+")");
            def.num1 = Math.Sqrt(Double.Parse(bx_output.Text));
        }
        //==================================================================
        //--------Buttons (multiple)
        //Number Buttons
        private void btn_num_Click(object sender, EventArgs e)
        {

            Button btn_num = (Button)sender;

            if (btn_num.Text == ".")
            {
                if (!bx_output.Text.Contains("."))
                    bx_output.Text = bx_output.Text + btn_num.Text;
                if (bx_output.Text == "0")
                    bx_output.Text = bx_output.Text + btn_num.Text;
            }
            else if (bx_output.Text == "0")
            {
                bx_output.Clear();
                bx_output.Text = bx_output.Text + btn_num.Text;
            }
            else
                bx_output.Text = bx_output.Text + btn_num.Text;
        }
        //Operations
        private void oper_click(object sender, EventArgs e)
        {
            try
            {
                Button b_Oper = (Button)sender;
                if (def.num1 != 0)
                {
                    equals_btn.PerformClick();
                    def.operationExecuted = b_Oper.Text;
                    passValue_operation.Text = def.num1 + " " + def.operationExecuted;
                    bx_output.Text = "";
                }
                else
                {
                    equals_btn.PerformClick();
                    def.operationExecuted = b_Oper.Text;
                    passValue_operation.Text = bx_output.Text + "" + b_Oper.Text;
                    bx_output.Text = "";
                }
            }
            catch
            {
                bx_output.Text = "Math Error!";
                del_btn.Enabled = false;
            }
        }

        private void squared_btn_Click(object sender, EventArgs e)
        {
            bx_output.Text = Math.Pow(Double.Parse(bx_output.Text), 2).ToString();
            passValue_operation.Text = (Math.Sqrt(Double.Parse(bx_output.Text)) + "²");
            bx_history.AppendText("\r\n" + passValue_operation.Text + ("\n" + "=") + bx_output.Text + "\n\n");
        }

        private void over_btn_Click(object sender, EventArgs e)
        {
            def.num3 = Double.Parse(bx_output.Text);
            bx_output.Text = (1 / Double.Parse(bx_output.Text)).ToString();
            passValue_operation.Text = ("1/" + (def.num3));
            bx_history.AppendText("\r\n" + passValue_operation.Text + ("\n" + "=") + bx_output.Text + "\n\n");

        }
        //===========================================================================================end of operations

        private void history_btn_Click(object sender, EventArgs e)
        {
            bx_history.Visible = true;
            closeHis_btn.Visible = true;
            noHistory_lbl.Visible = false;
            clearHis_bx.Visible = true;

            Memorydefault();
        }
        //=======================================================start of memory button
        private void MShow_Click(object sender, EventArgs e)
        {
            bx_memory.Visible = true;
            closeMem_btn.Visible = true;
            noMemory_lbl.Visible = false;
            clearMem_bx.Visible = true;

            Historydefault();

        }

        private void MSave_Click(object sender, EventArgs e)
        {
            def.storedNumber = float.Parse(bx_output.Text);
            MClear.Enabled = true;
            MReall.Enabled = true;
            MShow.Enabled = true;

            bx_memory.AppendText("\r\n" + bx_output.Text + "\n\n");

        }

        private void MSubtract_Click(object sender, EventArgs e)
        {
            def.storedNumber -= float.Parse(bx_output.Text);
            bx_output.Text = string.Format("{0:N0}", def.storedNumber);
        }

        private void MAdd_Click(object sender, EventArgs e)
        {
            def.storedNumber += float.Parse(bx_output.Text);
            bx_output.Text = string.Format("{0:N0}", def.storedNumber);
        }

        private void MReall_Click(object sender, EventArgs e)
        {
            bx_output.Text = string.Format("{0:N0}", def.storedNumber);
        }

        private void MClear_Click(object sender, EventArgs e)
        {
            bx_memory.Clear();
        }

        private void closeMem_btn_Click(object sender, EventArgs e)
        {
            Memorydefault();
        }

        private void closeHis_btn_Click(object sender, EventArgs e)
        {
            Historydefault();
        }

        private void clearHis_bx_Click(object sender, EventArgs e)
        {
            bx_history.Clear();
            noHistory_lbl.Visible = true;
        }

        private void clearMem_bx_Click(object sender, EventArgs e)
        {
            bx_memory.Clear();
            noMemory_lbl.Visible = true;
        }

        //======private voids (made)
        private void SaveHistory()
        {
            bx_history.AppendText("\r\n" + (def.num1 + def.operationExecuted) + def.num2 + ("\n" + "=") + bx_output.Text + "\n\n");
        }

        private void Memorydefault()
        {
            bx_memory.Visible = false;
            noMemory_lbl.Visible = false;
            closeMem_btn.Visible = false;
            clearMem_bx.Visible = false;
        }

        private void Historydefault()
        {
            bx_history.Visible = false;
            noHistory_lbl.Visible = false;
            closeHis_btn.Visible = false;
            clearHis_bx.Visible = false;
        }

        //Operations
        private void Add()
        {
            bx_output.Text = (def.num1 + Double.Parse(bx_output.Text)).ToString();
        }

        private void Minus()
        {
            bx_output.Text = (def.num1 - Double.Parse(bx_output.Text)).ToString();
        }

        private void Divide()
        {
            bx_output.Text = (def.num1 / Double.Parse(bx_output.Text)).ToString();
        }

        private void Multiply()
        {
            bx_output.Text = (def.num1 * Double.Parse(bx_output.Text)).ToString();
        }

        private void Percent() //kulang pa sa code
        {
            bx_output.Text = (def.num1 / 100).ToString();
        }

        private void Squared()
        {
            bx_output.Text = Math.Pow(def.num1, 2).ToString();
        }

        private void Reciprocal()
        {
            bx_output.Text = (1 / def.num1).ToString();
        }

        private void showValue_OP()
        {
            passValue_operation.Text = (def.num1 + def.operationExecuted + def.num2);
        }
    }
}
