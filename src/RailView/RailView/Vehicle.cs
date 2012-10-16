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
        private ushort vehicleLocation;
        private VehicleDirection vehicleDirection = VehicleDirection.Null;
        private Point vehicleOldCoordinate=Point.Empty;

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
        public ushort VehicleLocation
        {
            get { return vehicleLocation; }
            set { vehicleLocation = value; }
        }

        private enum VehicleDirection
        { 
            Up, Down, Lift, Right, Null
        }

        public Vehicle()
        {
        }

        public bool ShowInScreen(Graphics canvas, Point location)
        {
            Pen pen = new Pen(Color.Red);
            SolidBrush bsh = new SolidBrush(Color.Red);
            Point oldLocation = vehicleOldCoordinate;
            Point[] tranglePts = new Point[3];
            tranglePts[0] = location;
            switch (vehicleDirection)
            { 
                case VehicleDirection.Up:
                    tranglePts[0].Offset(0, -3);
                    tranglePts[1].X = tranglePts[0].X - 3;
                    tranglePts[1].Y = tranglePts[0].Y + 6;
                    tranglePts[2].X = tranglePts[0].X + 3;
                    tranglePts[2].Y = tranglePts[0].Y + 6;
                    break;
                case VehicleDirection.Down:
                    tranglePts[0].Offset(0, 3);
                    tranglePts[1].X = tranglePts[0].X - 3;
                    tranglePts[1].Y = tranglePts[0].Y - 6;
                    tranglePts[2].X = tranglePts[0].X + 3;
                    tranglePts[2].Y = tranglePts[0].Y - 6;
                    break;
                case VehicleDirection.Lift:
                    tranglePts[0].Offset(-3, 0);
                    tranglePts[1].X = tranglePts[0].X + 6;
                    tranglePts[1].Y = tranglePts[0].Y - 3;
                    tranglePts[2].X = tranglePts[0].X + 6;
                    tranglePts[2].Y = tranglePts[0].Y + 3;
                    break;
                case VehicleDirection.Right:
                    tranglePts[0].Offset(3, 0);
                    tranglePts[1].X = tranglePts[0].X - 6;
                    tranglePts[1].Y = tranglePts[0].Y - 3;
                    tranglePts[2].X = tranglePts[0].X - 6;
                    tranglePts[2].Y = tranglePts[0].Y + 3;
                    break;
                default:
                    break;
            }
            GraphicsPath path = new GraphicsPath();
            path.AddLines(tranglePts);
            canvas.DrawPath(pen, path);
            canvas.FillPath(bsh, path);
            pen.Dispose();
            bsh.Dispose();
            vehicleOldCoordinate = location;
            Debug.WriteLine(string.Format("trangelePts {0},{1},{2}", tranglePts[0], tranglePts[1], tranglePts[2]));
            return false;
        }
    }
}
