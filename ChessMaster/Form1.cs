using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e) // шахматы
        {
            using (ChessForm pForm = new ChessForm())
            {
                // модальный режим
                pForm.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Form2 pForm = new Form2())
            {
                // модальный режим
                pForm.ShowDialog(this);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
      
            Graphics g = Graphics.FromHwnd(Handle);
            g.DrawImage(Image.FromFile(@"картинки\fon.jpg"), new Point(0, 0));
            //label1.BackColor = Color.Transparent;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FormGame pForm = new FormGame())
            {
                // модальный режим
                pForm.ShowDialog(this);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
