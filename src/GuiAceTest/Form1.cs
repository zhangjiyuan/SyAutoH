using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuiAceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            User formUser = new User();
            formUser.MdiParent = this;
            formUser.Show();
            this.Controls.Add(formUser);
            for (int i = 0; i < this.Controls.Count; i++)
            {
                MdiClient ClientMdi = this.Controls[i] as MdiClient;
                if (ClientMdi != null)
                {
                    ClientMdi.MouseMove += new System.Windows.Forms.MouseEventHandler(ClientMdi_MouseMove);
                    ClientMdi.BackColor = Color.FromArgb(214, 213, 215);
                }
            }
        }

        private void ClientMdi_MouseMove(object sender, MouseEventArgs e)  
     {  
             
     }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer5_Panel2_Paint(object sender, PaintEventArgs e)
        {

        } 

       
    }
}
