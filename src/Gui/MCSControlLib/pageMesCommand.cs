using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCSControlLib
{
    public partial class pageMesCommand : baseControlPage, IMcsControlBase
    {
        public event DataChangeHander DataChange;
        public pageMesCommand()
        {
            InitializeComponent();

            if (null != this.DataChange)
            {
                this.DataChange(this, 0);
            }
        }

        public void ProcessGuiData(List<MCS.GuiDataItem> list)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MesCommand Test");
        }
    }
}
