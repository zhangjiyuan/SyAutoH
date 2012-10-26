using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormElement
{
    public class FormTreeViewOp
    {
        public void AddVehicleNode(TreeView tempTreeView,short vehicleID)
        {
            tempTreeView.SelectedNode = tempTreeView.Nodes[0];
            TreeNode node = new TreeNode("vehicle" + vehicleID);
            tempTreeView.SelectedNode.Nodes.Add(node);
        }

        public void DeleteVehicleNode(TreeView tempTreeView)
        { }

        public void AddQueuesNode()
        { }

        public void DeleteQueuesNode()
        { }

        public void AddAlarmNode()
        { }

        public void DeleteAlarmNode()
        { }
    }
}
