using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RailView
{
    public class Vehicle
    {
        private Int16 vehicleID;
        private bool vehicleDirection;
        private bool vehicleState;
        private bool vehicleAlarm;
        private ushort vehicleLocation;

        public Int16 VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }

        public bool VehicleDirection
        {
            get { return vehicleDirection; }
            set { vehicleDirection = value; }
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

        public Vehicle()
        {
        }

        public bool ShowInScreen(Graphics canvas, Point location, Point oldLocation)
        {
            Pen pen = new Pen(Color.Red);
            SolidBrush bsh = new SolidBrush(Color.Red);
            Point[] tranglePts = new Point[3];
            tranglePts[0] = location;
            if (location.X == oldLocation.X)
            {
                if (location.Y < oldLocation.Y)
                {
                    tranglePts[1].X = location.X - 3;
                    tranglePts[1].Y = location.Y + 6;
                    tranglePts[2].X = location.X + 3;
                    tranglePts[2].Y = location.Y + 6;
                }
                else if (location.Y >= oldLocation.Y)
                {
                    tranglePts[1].X = location.X - 3;
                    tranglePts[1].Y = location.Y - 6;
                    tranglePts[2].X = location.X + 3;
                    tranglePts[2].Y = location.Y - 6;
                }
            }
            else if (location.Y == oldLocation.Y)
            {
                if (location.X < oldLocation.X)
                {
                    tranglePts[1].X = location.X + 6;
                    tranglePts[1].Y = location.Y - 3;
                    tranglePts[2].X = location.X + 6;
                    tranglePts[2].Y = location.Y + 3;
                }
                else if (location.X >= oldLocation.X)
                {
                    tranglePts[1].X = location.X - 6;
                    tranglePts[1].Y = location.Y - 3;
                    tranglePts[2].X = location.X - 6;
                    tranglePts[2].Y = location.Y + 3;
                }
            }
            GraphicsPath path = new GraphicsPath();
            path.AddLines(tranglePts);
            canvas.DrawPath(pen, path);
            canvas.FillPath(bsh, path);
            pen.Dispose();
            bsh.Dispose();
            return false;
        }
    }
}
