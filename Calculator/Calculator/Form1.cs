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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + "9";
        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
            bx_output.Text = bx_output.Text + ".";
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
#editPa
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
    }
}
