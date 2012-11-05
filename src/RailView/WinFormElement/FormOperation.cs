using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormElement
{
    public class FormOperation
    {
        FormShowRegion formShowRegion = new FormShowRegion();
        FormTreeViewOp formTreeViewOp = new FormTreeViewOp();
        List<Vehicle> vehicleList = new List<Vehicle>();

        static short vehicleID = 0;                             //using for test

        public FormOperation()
        {
        }

        public void FormShowRegionInit()
        {
            if (formShowRegion.ReadRailSaveFile())
            {
                formShowRegion.InitRailList();
            }
        }

        public void ShowRegion(Graphics canvas)
        {
            formShowRegion.DrawRailInfo(canvas);
            formShowRegion.DrawVehicleInfo(canvas, vehicleList);
        }

        //添加第二个参数，表示添加节点类型，根据节点类型调用switch函数
        public void AddVehicleNode(TreeView tempTreeView)
        {
            Vehicle vehicle = new Vehicle(vehicleID);
            vehicleList.Add(vehicle);
            formTreeViewOp.AddVehicleNode(tempTreeView, vehicleID);
            vehicleID++;
        }

        public void DeleteVehicleNode(TreeView tempTreeView)
        { }
    }
}
