using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Timers;                //test using,finally delete

namespace RailView
{
    public class ShowRunning
    {
        ReadRailInfo railInfo = new ReadRailInfo();
        CodingRailCoordinates codingRailCoor = new CodingRailCoordinates();
        List<RailEle> railEleList = new List<RailEle>();

        TestCoordination tempTest = new TestCoordination();     //test using,finally delete
        int section = -1;                                       //test using,finally delete
        int offset = -1;                                        //test using,finally delete

        public void InitShowRunning()
        {
            railEleList.AddRange(railInfo.OpenFile());
            List<RailEle> listTemp = codingRailCoor.ChooseStartPartInList(railEleList);
            railEleList.Clear();
            railEleList.AddRange(codingRailCoor.ArrangeEleList(listTemp));

            tempTest.Show();        //test using,finally delete
            tempTest.ReadSectionNum(railEleList);       //test using,finally delete
        }

        public void DrawRailInfo(Graphics canvas)
        {
            Pen pen = new Pen(Color.Black, 1);
            Pen pen1 = new Pen(Color.Red, 1);
            Pen pen2 = new Pen(Color.Green, 1);
            Pen pen3 = new Pen(Color.Blue, 1);
            Pen pen4 = new Pen(Color.Yellow, 1);
            Pen pen5 = new Pen(Color.Pink, 1);
            Pen pen6 = new Pen(Color.Orange, 1);
            int j = railEleList.Count;

            for (int k = 0; k < j; k++)
            {
                if (k == 0||k==6||k==12)
                    pen = pen1;
                else if (k == 1||k==7||k==13)
                    pen = pen2;
                else if (k == 2||k==8||k==14)
                    pen = pen3;
                else if (k == 3||k==9||k==15)
                    pen = pen4;
                else if (k == 4||k==10||k==16)
                    pen = pen5;
                else if (k == 5||k==11)
                    pen = pen6;
                RailEle obj = railEleList[k];
                switch (obj.graphType)
                {
                    case 1:
                        StraightEle strTemp = (StraightEle)obj;
                        canvas.DrawLine(pen, strTemp.pointList[0], strTemp.pointList[1]);
                        break;
                    case 2:
                        CurvedEle curTemp = (CurvedEle)obj;
                        Rectangle rc = new Rectangle();
                        rc.Location = new Point(curTemp.center.X - curTemp.radiu, curTemp.center.Y - curTemp.radiu);
                        rc.Size = new Size(curTemp.radiu * 2, curTemp.radiu * 2);
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddArc(rc, curTemp.startAngle, curTemp.sweepAngle);
                        canvas.DrawPath(pen, gp);
                        gp.Dispose();
                        break;
                    case 3:
                        CrossEle croTemp = (CrossEle)obj;
                        int n = croTemp.pointList.Count;
                        Point[] pts = new Point[2];
                        for (int i = 0; i < n; i++, i++)
                        {
                            pts[0] = croTemp.pointList[i];
                            pts[1] = croTemp.pointList[i + 1];
                            canvas.DrawLines(pen, pts);
                        }
                        break;
                    default:
                        break;
                }
            }
 
/*            foreach (RailEle obj in railEleList)
            {
                switch (obj.graphType)
                {
                    case 1:
                        StraightEle strTemp = (StraightEle)obj;
                        canvas.DrawLine(pen, strTemp.pointList[0], strTemp.pointList[1]);
                        break;
                    case 2:
                        CurvedEle curTemp = (CurvedEle)obj;
                        Rectangle rc = new Rectangle();
                        rc.Location = new Point(curTemp.center.X - curTemp.radiu, curTemp.center.Y - curTemp.radiu);
                        rc.Size = new Size(curTemp.radiu * 2, curTemp.radiu * 2);
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddArc(rc, curTemp.startAngle, curTemp.sweepAngle);
                        canvas.DrawPath(pen, gp);
                        gp.Dispose();
                        break;
                    case 3:
                        CrossEle croTemp = (CrossEle)obj;
                        int n = croTemp.pointList.Count;
                        Point[] pts = new Point[2];
                        for (int i = 0; i < n; i++, i++)
                        {
                            pts[0] = croTemp.pointList[i];
                            pts[1] = croTemp.pointList[i + 1];
                            canvas.DrawLines(pen, pts);
                        }
                        break;
                    default:
                        break;
                }
            }
*/
            pen.Dispose();
        }

        public void DrawRunningInfo(Graphics canvas)
        {
            section = tempTest.sectionOfText;
            offset = tempTest.offsetOfText;
            if (section != -1 && offset != -1)
            {
                Pen pen = new Pen(Color.Red, 1);
                Point carrierCoor = codingRailCoor.ComputeCoordinates(railEleList, section, offset);
                Point carrierCoor1 = carrierCoor;
                carrierCoor1.Offset(2, 0);
                canvas.DrawLine(pen, carrierCoor, carrierCoor1);
                pen.Dispose();
            }
        }
    }
}
