﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataApp;

namespace DataApp
{
    public partial class Form2 : Form
    {
        public static char delimiter_f2;
        static string filepath = Form1.sourceFile;
        public static DataTable temp_dt = DataHandler.FlatToDataTableFirst10(filepath);
        public Form2()
        {
            InitializeComponent();
            dataGridView1_Form2.DataSource = temp_dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1_Form2_SemiColon.Checked)
            {
                delimiter_f2 = ';';
                this.Close();
            }
            else if (radioButton1_Form2_Space.Checked)
            {
                delimiter_f2 = ' ';
                this.Close();
            }
            else if (radioButton1_form2_Comma.Checked)
            {
                delimiter_f2 = ',';
                this.Close();
            }
            else if (radioButton1_Form2_Other.Checked)
            {
                if(textBox1_Form2_Other.Text.Length <1)
                {
                    MessageBox.Show("Please introduce a delimiter or select one");
                }
                else
                {
                    delimiter_f2 = Convert.ToChar(textBox1_Form2_Other.Text);
                    this.Close();
                }               
            }            
        }

        private void radioButton1_Form2_SemiColon_CheckedChanged(object sender, EventArgs e)
        {
            delimiter_f2 = ';';
            temp_dt = DataHandler.FlatToDataTableFirst10(filepath, delimiter_f2);
            dataGridView1_Form2.DataSource = temp_dt;
        }

        private void radioButton1_Form2_Space_CheckedChanged(object sender, EventArgs e)
        {
            delimiter_f2 = ' ';
            temp_dt = DataHandler.FlatToDataTableFirst10(filepath, delimiter_f2);
            dataGridView1_Form2.DataSource = temp_dt;
        }

        private void radioButton1_form2_Comma_CheckedChanged(object sender, EventArgs e)
        {
            delimiter_f2 = ',';
            temp_dt = DataHandler.FlatToDataTableFirst10(filepath, delimiter_f2);
            dataGridView1_Form2.DataSource = temp_dt;
            dataGridView1_Form2.AutoSize = true;
        }

        private void radioButton1_Form2_Other_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_Form2_Other.Select();
            if (textBox1_Form2_Other.Text.Length > 0)
            {
                delimiter_f2 = Convert.ToChar(textBox1_Form2_Other.Text);
                temp_dt = DataHandler.FlatToDataTableFirst10(Form1.sourceFile, delimiter_f2);
                dataGridView1_Form2.DataSource = temp_dt;
            }
        }

        private void textBox1_Form2_Other_Click(object sender, EventArgs e)
        {
            radioButton1_Form2_Other.Select();
            textBox1_Form2_Other.Select();
        }

        private void textBox1_Form2_Other_TextChanged(object sender, EventArgs e)
        {
            if (textBox1_Form2_Other.Text.Length > 0)
            {
                radioButton1_Form2_Other.Checked = true;
                delimiter_f2 = Convert.ToChar(textBox1_Form2_Other.Text);
                temp_dt = DataHandler.FlatToDataTableFirst10(Form1.sourceFile, delimiter_f2);
                dataGridView1_Form2.DataSource = temp_dt;
            }
        }
    }
}