using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xmind_project
{
    internal class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void textBox1_KeyDown( object sender, KeyEventArgs e) 
        {
            if (e.KeyValue == (char)Keys.A) 
            {
                MessageBox.Show("pressed A");
            }
            if (e.KeyValue == (char)Keys.B)
            {
                MessageBox.Show("pressed B");
            }
        }         
    }

}