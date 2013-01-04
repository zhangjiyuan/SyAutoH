using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCS.GuiHub;

namespace MCSControlLib
{
    public partial class pageMesCommand : baseControlPage, IMcsControlBase
    {
        private const string TKeyP_Pos = "Position";
        private const string TKeyP_Name = "Name";
        private const string TKeyP_Type = "Type";
        private const string TKeyP_Speed = "Speed";

        private DataTable m_tableKeyPos = null;

        public pageMesCommand()
        {
            InitializeComponent();
        }

        protected override void InitProcessDictionary()
        {
            m_dictProcess.Add(PushData.upMesPosTable, ProcessPosTable);
        }

        private void InitKeyPosTable()
        {
            if (null == m_tableKeyPos)
            {
                m_tableKeyPos = new DataTable("KeyPos");
                m_tableKeyPos.Columns.Add(TKeyP_Pos, typeof(System.UInt32));
                m_tableKeyPos.Columns[TKeyP_Pos].AllowDBNull = false;
                m_tableKeyPos.PrimaryKey = new DataColumn[] { m_tableKeyPos.Columns[TKeyP_Pos] };
                m_tableKeyPos.Columns.Add(TKeyP_Name, typeof(System.String));
                m_tableKeyPos.Columns.Add(TKeyP_Type, typeof(System.Byte));
                m_tableKeyPos.Columns.Add(TKeyP_Speed, typeof(System.Byte));

                m_tableKeyPos.AcceptChanges();
            }
        }

        private void ProcessPosTable(ArrayList item)
        {
            if (4 == item.Count)
            {
                UInt32 uPos = Convert.ToUInt32(item[1]);
                Byte uType = TryConver.ToByte(item[2].ToString());
                Byte uSpeed = TryConver.ToByte(item[3].ToString());
                DataRow row = m_tableKeyPos.Rows.Find(uPos);
                if (null != row)
                {
                    row[TKeyP_Name] = item[0].ToString();
                    row[TKeyP_Type] = uType;
                    row[TKeyP_Speed] = uSpeed;
                    row.AcceptChanges();
                }
                else
                {
                    row = m_tableKeyPos.NewRow();
                    row[TKeyP_Pos] = uPos;
                    row[TKeyP_Name] = item[0].ToString();
                    row[TKeyP_Type] = uType;
                    row[TKeyP_Speed] = uSpeed;
                    m_tableKeyPos.Rows.Add(row);
                    m_tableKeyPos.AcceptChanges();
                }
            }
        }

        private void linkLabelFoupRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int nWRet = m_dataHub.WriteData(GuiCommand.MesGetFoupTable, "");
        }

        private void linkLabelLocationRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // get keypoints where type = 0x20, (pick and place)
            int nWRet = m_dataHub.WriteData(GuiCommand.MesGetPosTable, "");
        }

        private void pageMesCommand_Load(object sender, EventArgs e)
        {
            InitKeyPosTable();

            dataGridViewKeyPos.DataSource = m_tableKeyPos;
        }
    }
}
