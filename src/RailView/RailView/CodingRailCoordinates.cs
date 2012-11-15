using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RailView
{
    public class CodingRailCoordinates
    {
//        public List<RailEle> codingEleList=new List<RailEle>();

        public List<RailEle> InitEleList(List<RailEle> paraList)
        {
            List<RailEle> tempList = new List<RailEle>();
            Int16 num = Convert.ToInt16(paraList.Count);
            for (Int16 i = 0; i < num; i++)
            {
                for (Int16 j = 0; j < num; j++)
                {
                    if (paraList[j].segmentNumber == Convert.ToInt16(i + 1))
                        tempList.Add(paraList[j]);
                }
            }
            return tempList;
        }

        public void ChooseStartDot(List<RailEle> paraList)
        {
            Int16 num=Convert.ToInt16(paraList.Count);
            ChooseStartDotForStartPart(paraList, 0);
            for (Int16 i = 1; i < num; i++)
            {
                if (!SearchForNeighborDot(paraList, paraList[i - 1].endPoint, i) && i != (num - 1))
                {
                    ChooseStartDotForStartPart(paraList, i);
                }
            }
        }

        public void ComputeOffset(ushort value)
        { 
        }

        public Int16 ComputeSegmentNumber(ushort value, List<RailEle> paraList)
        {
            Int16 temp = Convert.ToInt16(value);
            Int16 segNum = 0;
            for (Int16 i = 0; i < paraList.Count; i++)
            {
                if (temp < paraList[i].tagNumber)
                {
                    segNum = Convert.ToInt16(i);
                    i = Convert.ToInt16(paraList.Count-1);
                }
                temp -= paraList[i].tagNumber;
            }
            return segNum;
        }

        public Int16 ComputeSegmentOffset(ushort value, List<RailEle> tempList, Int16 segNum)
        {
            Int16 temp = Convert.ToInt16(value);
            for (Int16 i = 0; i < segNum;i++ )
            {
                temp -= tempList[i].tagNumber;
            }
            return temp;
        }

        private void ChooseStartDotForStartPart(List<RailEle> paraList, Int16 i)
        {
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            switch (paraList[i].graphType)
            {
                case 1:
                    strTemp = (StraightEle)paraList[i];
                    paraList[i].startPoint = strTemp.pointList[0];
                    paraList[i].endPoint = strTemp.pointList[1];
                    break;
                case 2:
                    curTemp = (CurvedEle)paraList[i];
                    paraList[i].startPoint = curTemp.firstDot;
                    paraList[i].endPoint = curTemp.secDot;
                    break;
                case 3:
                    croTemp = (CrossEle)paraList[i];
                    paraList[i].startPoint = croTemp.pointList[0];
                    paraList[i].endPoint = croTemp.pointList[5];
                    break;
                default:
                    break;
            }
            if (!SearchForNeighborDot(paraList, paraList[i].endPoint, Convert.ToInt16(i + 1)))
            {
                switch (paraList[i].graphType)
                {
                    case 1:
                        strTemp = (StraightEle)paraList[i];
                        paraList[i].startPoint = strTemp.pointList[1];
                        paraList[i].endPoint = strTemp.pointList[0];
                        break;
                    case 2:
                        curTemp = (CurvedEle)paraList[i];
                        paraList[i].startPoint = curTemp.secDot;
                        paraList[i].endPoint = curTemp.firstDot;
                        break;
                    case 3:
                        croTemp = (CrossEle)paraList[i];
                        paraList[i].startPoint = croTemp.pointList[5];
                        paraList[i].endPoint = croTemp.pointList[0];
                        break;
                    default:
                        break;
                }
            }
        }

        private bool SearchForNeighborDot(List<RailEle> tempList, Point pt, Int16 j)
        {
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            Point startPt = Point.Empty;
            Point endPt = pt;
            switch (tempList[j].graphType)
            {
                case 1:
                    strTemp = (StraightEle)tempList[j];
                    if ((Int16)Math.Sqrt((strTemp.pointList[0].X - pt.X) * (strTemp.pointList[0].X - pt.X) +
                        (strTemp.pointList[0].Y - pt.Y) * (strTemp.pointList[0].Y - pt.Y)) < 2)
                    {
                        tempList[j].startPoint = strTemp.pointList[0];
                        tempList[j].endPoint = strTemp.pointList[1];
                        return true;
                    }
                    else if ((Int16)Math.Sqrt((strTemp.pointList[1].X - pt.X) * (strTemp.pointList[1].X - pt.X) +
                        (strTemp.pointList[1].Y - pt.Y) * (strTemp.pointList[1].Y - pt.Y)) < 2)
                    {
                        tempList[j].startPoint = strTemp.pointList[1];
                        tempList[j].endPoint = strTemp.pointList[0];
                        return true;
                    }
                    break;
                case 2:
                    curTemp = (CurvedEle)tempList[j];
                    if ((Int16)Math.Sqrt((curTemp.firstDot.X - endPt.X) * (curTemp.firstDot.X - endPt.X) +
                        (curTemp.firstDot.Y - pt.Y) * (curTemp.firstDot.Y - pt.Y)) < 2)
                    {
                        tempList[j].startPoint = curTemp.firstDot;
                        tempList[j].endPoint = curTemp.secDot;
                        return true;
                    }
                    else if ((Int16)Math.Sqrt((curTemp.secDot.X - endPt.X) * (curTemp.secDot.X - endPt.X) +
                        (curTemp.secDot.Y - pt.Y) * (curTemp.secDot.Y - pt.Y)) < 2)
                    {
                        tempList[j].startPoint = curTemp.secDot;
                        tempList[j].endPoint = curTemp.firstDot;
                        return true;
                    }
                    break;
                case 3:
                    croTemp = (CrossEle)tempList[j];
                    if ((Int16)Math.Sqrt((croTemp.pointList[0].X - pt.X) * (croTemp.pointList[0].X - pt.X) +
                        (croTemp.pointList[0].Y - pt.Y) * (croTemp.pointList[0].Y - pt.Y)) < 2)
                    {
                        tempList[j].startPoint = croTemp.pointList[0];
                        tempList[j].endPoint = croTemp.pointList[5];
                        return true;
                    }
                    else if ((Int16)Math.Sqrt((croTemp.pointList[5].X - pt.X) * (croTemp.pointList[5].X - pt.X) +
                        (croTemp.pointList[5].Y - pt.Y) * (croTemp.pointList[5].Y - pt.Y)) < 2)
                    {
                        tempList[j].startPoint = croTemp.pointList[5];
                        tempList[j].endPoint = croTemp.pointList[0];
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        public Point ComputeCoordinates(List<RailEle> tempList, ushort locationValue)
        {
            Point returnPt = Point.Empty;
            Int32 offsetTemp = 0;
            Int16 section = 0;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            ComputeOffset(locationValue);
            section = ComputeSegmentNumber(locationValue, tempList);
            offsetTemp = ComputeSegmentOffset(locationValue, tempList, section);
            switch (tempList[section].graphType)
            {
                case 1:
                    strTemp = (StraightEle)tempList[section];
                    offsetTemp =offsetTemp * strTemp.lenght / strTemp.tagNumber;
                    returnPt = strTemp.startPoint;
                    if (Math.Abs(strTemp.pointList[0].Y - strTemp.pointList[1].Y) < 3)
                    {
                        if (strTemp.startPoint.X < strTemp.endPoint.X)
                            returnPt.X = strTemp.startPoint.X + offsetTemp;
                        else if (strTemp.startPoint.X > strTemp.endPoint.X)
                            returnPt.X = strTemp.startPoint.X - offsetTemp;
                    }
                    else
                    {
                        if (strTemp.startPoint.Y < strTemp.endPoint.Y)
                            returnPt.Y = strTemp.startPoint.Y + offsetTemp;
                        else if (strTemp.startPoint.Y > strTemp.endPoint.Y)
                            returnPt.Y = strTemp.startPoint.Y - offsetTemp;
                    }
                    break;
                case 2:
                    curTemp = (CurvedEle)tempList[section];
                    offsetTemp = offsetTemp * 90 / curTemp.tagNumber;
                    double angleTemp = 0;
                    if (curTemp.firstDot == curTemp.startPoint)
                        angleTemp = (curTemp.startAngle + offsetTemp) * 3.14 / 180;
                    else if (curTemp.secDot == curTemp.startPoint)
                        angleTemp = (curTemp.startAngle + curTemp.sweepAngle - offsetTemp) * 3.14 / 180;
                    returnPt.X = (int)(curTemp.center.X + curTemp.radiu * Math.Cos(angleTemp));
                    returnPt.Y = (int)(curTemp.center.Y + curTemp.radiu * Math.Sin(angleTemp));
                    break;
                case 3:
                    croTemp = (CrossEle)tempList[section];
                    offsetTemp = offsetTemp * (croTemp.firstPart + croTemp.secPart + croTemp.thPart + 
                        (int)Math.Sqrt(croTemp.fourPart.X * croTemp.fourPart.X + croTemp.fourPart.Y * croTemp.fourPart.Y)) / croTemp.tagNumber;
                    returnPt = croTemp.startPoint;
                    if (croTemp.startAngle == 0 || croTemp.startAngle == 180)
                    {
                        if (croTemp.startPoint.X < croTemp.endPoint.X)
                        {
                            if (croTemp.pointList[0].X < croTemp.pointList[5].X)
                            {
                                if (offsetTemp <= croTemp.firstPart)
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp <= (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].Y > croTemp.pointList[7].Y)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].Y < croTemp.pointList[7].Y)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                }
                            }
                            else if (croTemp.pointList[0].X > croTemp.pointList[5].X)
                            {
                                if (offsetTemp <= croTemp.thPart)
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > croTemp.thPart && offsetTemp <= (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart)
                                    && offsetTemp <= (croTemp.thPart + croTemp.secPart + croTemp.firstPart))
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].Y > croTemp.pointList[7].Y)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].Y < croTemp.pointList[7].Y)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                }
                            }
                        }
                        else if (croTemp.startPoint.X > croTemp.endPoint.X)
                        {
                            if (croTemp.pointList[0].X < croTemp.pointList[5].X)
                            {
                                if (offsetTemp <= croTemp.thPart)
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp <= (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].Y > croTemp.pointList[7].Y)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].Y < croTemp.pointList[7].Y)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                }
                            }
                            else if (croTemp.pointList[0].X > croTemp.pointList[5].X)
                            {
                                if (offsetTemp <= croTemp.firstPart)
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > croTemp.thPart && offsetTemp <= (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart)
                                    && offsetTemp <= (croTemp.thPart + croTemp.secPart + croTemp.firstPart))
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].Y > croTemp.pointList[7].Y)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].Y < croTemp.pointList[7].Y)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                }
                            }
                        }
                    }
                    else if (croTemp.startAngle == 90 || croTemp.startAngle == 270 || croTemp.startAngle == -90)
                    {
                        if (croTemp.startPoint.Y < croTemp.startPoint.Y)
                        {
                            if (croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                            {
                                if (offsetTemp <= croTemp.firstPart)
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp <= (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].X > croTemp.pointList[7].X)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].X < croTemp.pointList[7].X)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                }
                            }
                            else if (croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                            {
                                if (offsetTemp <= croTemp.thPart)
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp <= (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].X > croTemp.pointList[7].X)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].X < croTemp.pointList[7].X)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                }
                            }
                        }
                        else if (croTemp.startPoint.Y > croTemp.startPoint.Y)
                        {
                            if (croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                            {
                                if (offsetTemp <= croTemp.firstPart)
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp <= (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].X > croTemp.pointList[7].X)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].X < croTemp.pointList[7].X)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y -= offsetTemp;
                                    }
                                }
                            }
                            else if (croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                            {
                                if (offsetTemp <= croTemp.thPart)
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp <= (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp <= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
                                {
                                    offsetTemp -= (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y);
                                    returnPt = croTemp.pointList[6];
                                    if (croTemp.pointList[6].X > croTemp.pointList[7].X)
                                    {
                                        returnPt.X -= offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                    else if (croTemp.pointList[6].X < croTemp.pointList[7].X)
                                    {
                                        returnPt.X += offsetTemp;
                                        returnPt.Y += offsetTemp;
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return returnPt;
        }

        public void ComputeVehicleDirection(List<RailEle> tempList)
        {
        }
    }
}