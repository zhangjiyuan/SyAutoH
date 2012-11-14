using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace OptsRightsEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlDataAdapter sda = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public DataTable dt;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;

            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "Integrated Security = True; database = MCS; server = HL-20121109HRYV\\AMHS";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.OptsRights";
            cmd.Connection = scon;
            sda.SelectCommand = cmd;
            scon.Open();
            sda.Fill(ds, "OptsRights");
            DataSet ds1 = new DataSet();
            dt = ds.Tables[0].Copy();

            //设置下拉框显示
            SqlCommand cmdbox = new SqlCommand();
            cmdbox.CommandText = "select ID,RoleName from dbo.RightInfo";
            cmdbox.Connection = scon;
            SqlDataAdapter sdabox = new SqlDataAdapter();
            sdabox.SelectCommand = cmdbox;
            DataTable dtbox = new DataTable();
            sdabox.Fill(dtbox);
            DataGridViewComboBoxColumn dgvComboBoxColumn = dataGridView1.Columns["RoleRight"] as DataGridViewComboBoxColumn;
            dgvComboBoxColumn.DataPropertyName = "RoleRight";
            dgvComboBoxColumn.DataSource = dtbox.DefaultView;
            dgvComboBoxColumn.DisplayMember = "RoleName";
            dgvComboBoxColumn.ValueMember = "ID";
            scon.Close();

            this.dataGridView1.DataSource = dt.DefaultView;
            dt.Columns["MODE"].DefaultValue = 0;
            this.dataGridView1.Columns["OPT"].DataPropertyName = ds.Tables[0].Columns[0].ToString();
            this.dataGridView1.Columns["MODE"].DataPropertyName = ds.Tables[0].Columns[1].ToString();
            this.dataGridView1.Columns["RoleRight"].DataPropertyName = ds.Tables[0].Columns[2].ToString();
        }

        private void Add_Row_Click(object sender, EventArgs e)
        {
            dt.Rows.Add();
        }

        private void Delete_Row_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            drv.Delete();
            MessageBox.Show("删除数据集记录操作成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Save_Data_Click(object sender, EventArgs e)
        {

            SqlCommandBuilder sqlcb = new SqlCommandBuilder(sda);
            sda.InsertCommand = sqlcb.GetInsertCommand();
            sda.Update(dt);
            MessageBox.Show("保存数据集记录操作成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            }
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int rownum = (e.RowIndex + 1);
            Rectangle rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rownum.ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, 
                                  rct, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, System.Drawing.Color.Transparent, TextFormatFlags.HorizontalCenter);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult key = MessageBox.Show("是否确认关闭窗口？(如未保存数据，请点‘否’返回保存后继续)", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (key == DialogResult.No);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int count = this.dataGridView1.Rows.Count;
            if (count > 1 && dataGridView1.CurrentCell.RowIndex > 0)
            {
                if (this.dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    for (int i = 0; i < this.dataGridView1.CurrentCell.RowIndex; i++)
                    {
                        if (this.dataGridView1.Rows[i].Cells[0].Value.ToString() == this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("输入的OPT值重复，请重新输入！", "提示");
                            break;
                        }
                    }
                }
            }
        }
    }
}
