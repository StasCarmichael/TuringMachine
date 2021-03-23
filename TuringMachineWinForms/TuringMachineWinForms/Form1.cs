using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachineWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        TuringMachine turingMachine = new TuringMachine();


        public bool Protect()
        {
            if (textBox1.Text.Length == 0) { return false; }

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    turingMachine.SetHeadCommand(openFileDialog.FileName);
                    MessageBox.Show("Дані успішно завантажені");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (turingMachine.download == true)
                {
                    if (Protect())
                    {
                        turingMachine.CreateList(textBox1.Text);
                        textBox2.Text = turingMachine.StartMachine();
                    }
                    else
                    {
                        MessageBox.Show("Будь ласка введіть коректно дані !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Завантажте будь ласка дані !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Збій у роботі машини Тюрінга !!!\n" + ex.Message);
            }

        }
    }
}
