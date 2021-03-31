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
    public partial class bootForm : Form
    {
        public TuringMachine tempMachine;

        public bootForm(TuringMachine turingMachine)
        {
            InitializeComponent();
            tempMachine = turingMachine;

            string str = string.Empty;
            for (int i = 0; i < turingMachine.myData.Length; i++)
            {
                str += turingMachine.myData[i] + '\n';
            }

            richTextBoxforUser.Text = str;
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDonwload_Click(object sender, EventArgs e)
        {
            try
            {
                string[] myNewData = richTextBoxforUser.Text.Split('\n');
                tempMachine.DonwloadMatrix(myNewData);

                this.Close();

                MessageBox.Show("Дані успішно завантажені !!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Стався збій перевірте коректрість даних!!!\n" + ex.Message);
            }
        }





        Point point;
        private void bootForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }
        private void bootForm_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }
    }
}
