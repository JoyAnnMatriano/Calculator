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
        public Calculator_box()
        {
            InitializeComponent();
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "0";
        }
        private void oper_plus_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "+";
        }

        private void oper_minus_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "-";
        }

        private void oper_times_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "*";
        }

        private void oper_divide_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "/";
        }

        private void oper_equals_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "=";
        }

        private void symbol_percent_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "%";
        }

        private void oper_reciprocal_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "/x";
        }

        private void oper_sqrt_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "√";
        }

        private void btn_pos_neg_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "-";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "-";
        }

        private void btn_del_Click(object sender, EventArgs e)
        {

        }

        private void btn_clear_all_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_num_Click(object sender, EventArgs e)
        {

            if (bx_output.Text == "0")
                bx_output.Clear();


            Button btn_num = (Button)sender;
            bx_output.Text = bx_output.Text + btn_num.Text;


        
        }

        private void btn_num_click(object sender, EventArgs e)
        {

        }
    }
}
