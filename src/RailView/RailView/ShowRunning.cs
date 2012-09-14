﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RailView
{
    public class ShowRunning
    {
        ReadRailInfo railInfo = new ReadRailInfo();
        CodingRailCoordinates codingRailCoor = new CodingRailCoordinates();
        List<RailEle> railEleList = new List<RailEle>();

        public void InitShowRunning()
        {
            railEleList.AddRange(railInfo.OpenFile());
            List<RailEle> listTemp = codingRailCoor.InitEleList(railEleList);
            railEleList.Clear();
            railEleList.AddRange(listTemp);
        }

        public void DrawRailInfo(Graphics canvas)
        {
            Pen pen = new Pen(Color.Black, 1);
            Pen pen1 = new Pen(Color.Red, 1);
            Pen pen2 = new Pen(Color.Black, 1);
            int j = railEleList.Count;

            for (int k = 0; k < j; k++)
            {
                if (k == 0)
                    pen = pen1;
                else
                    pen = pen2;
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
                        gp.AddArc(rc, curTemp.startAngle, curTemp.rotateAngle);
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
                                        gp.AddArc(rc, curTemp.startAngle, curTemp.rotateAngle);
                                        canvas.DrawPath(pen, gp);
                                        gp.Dispose();
                                        break;
                                    case 3:
                                        CrossEle croTemp=(CrossEle)obj;
                                        int n = croTemp.pointList.Count;
                                        Point[] pts = new Point[2];
                                        for (int i = 0; i < n; i++, i++)
                                        {
                                            pts[0] = croTemp.pointList[i];
                                            pts[1] = croTemp.pointList[i + 1];
                                            canvas.DrawLines(pen, pts);
                                        }
                                            break;
                                    default :
                                        break;
                                }
                            }
                 */
            pen.Dispose();
        }

        public void DrawRunningInfo(Graphics canvas)
        { 
        }
    }
}
