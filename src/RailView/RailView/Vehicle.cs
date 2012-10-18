using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace RailView
{
    public class Vehicle
    {
        private Int16 vehicleID;
        private bool vehicleState;
        private bool vehicleAlarm;
        private Point vehicleOldPoint=Point.Empty;
        private Point vehicleTempPoint = Point.Empty;

        public Int16 VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }

        public bool VehicleState
        {
            get { return vehicleState; }
            set { vehicleState = value; }
        }

        public bool VehicleAlarm
        {
            get { return vehicleAlarm; }
            set { vehicleAlarm = value; }
        }

        public Vehicle(Int16 ID)
        {
            vehicleID = ID;
            //vehicleOldPoint = initPoint;
            //vehicleTempPoint = initPoint;
        }

        public bool ShowInScreen(Graphics canvas, Point location)
        {
            Pen pen = new Pen(Color.Red);
            SolidBrush bsh = new SolidBrush(Color.Red);
            ChangeVehiclePoint(location);
            Point[] tranglePts = new Point[3];
            tranglePts[0] = location;
            ComputeVehicleShape(location, tranglePts);
            GraphicsPath path = new GraphicsPath();
            path.AddLines(tranglePts);
            canvas.DrawPath(pen, path);
            canvas.FillPath(bsh, path);
            pen.Dispose();
            bsh.Dispose();
//            Debug.WriteLine(string.Format("trangelePts {0},{1},{2}", tranglePts[0], tranglePts[1], tranglePts[2]));
            return false;
        }

        private void ChangeVehiclePoint(Point pt)
        {
            if (pt != vehicleTempPoint)
            {
                vehicleOldPoint = vehicleTempPoint;
                vehicleTempPoint = pt;
            }
        }

        private void ComputeVehicleShape(Point pt, Point[] pts)
        {
            Point[] tempPts = new Point[3];
            int dx = pt.X - vehicleOldPoint.X;
            int dy = pt.Y - vehicleOldPoint.Y;
            Int16 dxSign = 0;
            Int16 dysign = 0;
            if (dx != 0)
            {
                dxSign = Convert.ToInt16(dx / Math.Abs(dx));
            }
            if (dy != 0)
            {
                dysign = Convert.ToInt16(dy / Math.Abs(dy));
            }
            tempPts[0].Offset(pts[0].X + dxSign * 3, pts[0].Y + dysign * 3);
            tempPts[1].Offset(pts[0].X - dxSign * 3, pts[0].Y - dysign * 3);
            tempPts[2].Offset(pts[0].X - dxSign * 3, pts[0].Y - dysign * 3);
            if (tempPts[0].X != tempPts[1].X)
            {
                double angle = Math.Atan((tempPts[0].Y - tempPts[1].Y) * 1.0 / (tempPts[0].X - tempPts[1].X));
                tempPts[1].Offset(-Convert.ToInt32(3 * Math.Sin(angle)), Convert.ToInt32(3 * Math.Cos(angle)));
                tempPts[2].Offset(Convert.ToInt32(3 * Math.Sin(angle)), -Convert.ToInt32(3 * Math.Cos(angle)));
            }
            else
            {
                tempPts[1].Offset(3, 0);
                tempPts[2].Offset(-3, 0);
            }
            pts[0].Offset(tempPts[0].X - pts[0].X, tempPts[0].Y - pts[0].Y);
            pts[1].Offset(tempPts[1].X - pts[1].X, tempPts[1].Y - pts[1].Y);
            pts[2].Offset(tempPts[2].X - pts[2].X, tempPts[2].Y - pts[2].Y);
        }
    }
}
