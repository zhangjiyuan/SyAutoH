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
        public List<RailEle> codingEleList=new List<RailEle>();

        public List<RailEle> InitEleList(List<RailEle> railEleList)
        {
            int n = railEleList.Count;
            codingEleList.Clear();
            codingEleList.AddRange(railEleList);
            List<RailEle> eleTempList = new List<RailEle>();
            eleTempList.Add(railEleList[0]);
            Point startPoint = Point.Empty;
            Point comparePoint = Point.Empty;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            //set first element startpoint
            startPoint = GetPointOfInitFun(railEleList, 0);
            //compare x
            for (int i = 1; i < n; i++)
            {
                comparePoint = GetPointOfInitFun(railEleList, i);
                if (comparePoint.X < startPoint.X && (startPoint.X - comparePoint.X) > 2)
                {
                    startPoint = comparePoint;
                    codingEleList.RemoveAt(i);
                    codingEleList.Insert(0, railEleList[i]);
                    eleTempList.Clear();
                    eleTempList.Add(railEleList[i]);
                }
                else if (comparePoint.X == startPoint.X)
                {
                    eleTempList.Insert(0, railEleList[i]);
                    codingEleList.RemoveAt(i);
                    codingEleList.Insert(0, railEleList[i]);
                }
            }
            //compare y
            n=eleTempList.Count;
            //find the top element
            startPoint = GetPointOfInitFun(eleTempList, 0);
            for (int i = 1; i < n; i++)
            {
                comparePoint = GetPointOfInitFun(eleTempList, i);
                if (comparePoint.Y < startPoint.Y && (startPoint.Y - comparePoint.Y) > 2)
                {
                    startPoint = comparePoint;
                    codingEleList.RemoveAt(i);
                    codingEleList.Insert(0, eleTempList[i]);
                }
            }
            return codingEleList;
        }

        public List<RailEle> ArrangeEleList(List<RailEle> railEleList)
        {
            List<RailEle> tempList = new List<RailEle>();
            List<RailEle> remailEleList = new List<RailEle>();
            tempList.AddRange(railEleList);
            remailEleList.AddRange(railEleList);
            remailEleList.RemoveAt(0);
            int numOfList = railEleList.Count;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            Point startPt = Point.Empty;
            Point endPt = Point.Empty;
            bool isSearchedNextEle = false;
            startPt = GetPointOfInitFun(tempList, 0);
            for (int i = 0; i < numOfList-1; i++)
            {
                switch (tempList[i].graphType)
                {
                    case 1:
                        strTemp = (StraightEle)tempList[i];
                        if (startPt == strTemp.pointList[0])
                            endPt = strTemp.pointList[1];
                        else
                            endPt = strTemp.pointList[0];
                        tempList[i].startPoint = startPt;
                        tempList[i].endPoint = endPt;
                        break;
                    case 2:
                        curTemp = (CurvedEle)tempList[i];
                        if (startPt == curTemp.firstDot)
                            endPt = curTemp.secDot;
                        else
                            endPt = curTemp.firstDot;
                        tempList[i].startPoint = startPt;
                        tempList[i].endPoint = endPt;
                        break;
                    case 3:
                        croTemp = (CrossEle)tempList[i];
                        if (startPt == croTemp.pointList[0])
                            endPt = croTemp.pointList[5];
                        else
                            endPt = croTemp.pointList[0];
                        tempList[i].startPoint = startPt;
                        tempList[i].endPoint = endPt;
                        break;
                    default:
                        break;
                }
                for (int j = i+1; j < numOfList;j++ )
                {
                    switch (tempList[j].graphType)
                    {
                        case 1:
                            strTemp = (StraightEle)tempList[j];
                            if ((int)Math.Sqrt((strTemp.pointList[0].X - endPt.X) * (strTemp.pointList[0].X - endPt.X) +
                                (strTemp.pointList[0].Y - endPt.Y) * (strTemp.pointList[0].Y - endPt.Y)) < 2)
                            {
                                startPt = strTemp.pointList[0];
                                isSearchedNextEle = true;
                            }
                            else if ((int)Math.Sqrt((strTemp.pointList[1].X - endPt.X) * (strTemp.pointList[1].X - endPt.X) +
                                (strTemp.pointList[1].Y - endPt.Y) * (strTemp.pointList[1].Y - endPt.Y)) < 2)
                            {
                                startPt = strTemp.pointList[1];
                                isSearchedNextEle = true;
                            }
                            break;
                        case 2:
                            curTemp = (CurvedEle)tempList[j];
                            if ((int)Math.Sqrt((curTemp.firstDot.X - endPt.X) * (curTemp.firstDot.X - endPt.X) +
                                (curTemp.firstDot.Y - endPt.Y) * (curTemp.firstDot.Y - endPt.Y)) < 2)
                            {
                                startPt = curTemp.firstDot;
                                isSearchedNextEle = true;
                            }
                            else if ((int)Math.Sqrt((curTemp.secDot.X - endPt.X) * (curTemp.secDot.X - endPt.X) +
                                (curTemp.secDot.Y - endPt.Y) * (curTemp.secDot.Y - endPt.Y)) < 2)
                            {
                                startPt = curTemp.secDot;
                                isSearchedNextEle = true;
                            }
                            break;
                        case 3:
                            croTemp = (CrossEle)tempList[j];
                            if ((int)Math.Sqrt((croTemp.pointList[0].X - endPt.X) * (croTemp.pointList[0].X - endPt.X) +
                                (croTemp.pointList[0].Y - endPt.Y) * (croTemp.pointList[0].Y - endPt.Y)) < 2)
                            {
                                startPt = croTemp.pointList[0];
                                isSearchedNextEle = true;
                            }
                            else if ((int)Math.Sqrt((croTemp.pointList[5].X - endPt.X) * (croTemp.pointList[5].X - endPt.X) +
                                (croTemp.pointList[5].Y - endPt.Y) * (croTemp.pointList[5].Y - endPt.Y)) < 2)
                            {
                                startPt = croTemp.pointList[5];
                                isSearchedNextEle = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (isSearchedNextEle)
                    {
                        remailEleList.Remove(tempList[j]);
                        tempList.Insert(i + 1, tempList[j]);
                        tempList.RemoveAt(j + 1);
                        break;
                    }                  
                }
                if (!isSearchedNextEle)
                {
                    tempList.RemoveRange(i + 1, numOfList - i - 1);
                    tempList.AddRange(InitEleList(remailEleList));
                    GetPointOfInitFun(tempList, i + 1);
                    remailEleList.Remove(tempList[i+1]);
                }
                isSearchedNextEle = false;
            }
            return tempList;
        }

        public Point computeCoordinates(List<RailEle> tempList,int section,int offset)
        {
            Point returnPt=Point.Empty;
            int offsetTemp = offset;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            switch (tempList[section].graphType)
            {
                case 1:
                    strTemp = (StraightEle)tempList[section];
                    returnPt = strTemp.startPoint;
                    if ((strTemp.rotateAngle + 180) % 180 == 0)
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
                    double angleTemp = 0;
                    if (curTemp.firstDot == curTemp.startPoint)
                        angleTemp = (curTemp.startAngle + offsetTemp)*3.14/180;                  
                    else if (curTemp.secDot == curTemp.startPoint)
                        angleTemp = (curTemp.startAngle + curTemp.sweepAngle - offsetTemp)*3.14/180;
                    returnPt.X = (int)(curTemp.center.X + curTemp.radiu * Math.Cos(angleTemp));
                    returnPt.Y = (int)(curTemp.center.Y + curTemp.radiu * Math.Sin(angleTemp));
                    break;
                case 3:
                    croTemp = (CrossEle)tempList[section];
                    returnPt = croTemp.startPoint;
                    if (croTemp.startAngle == 0 || croTemp.startAngle == 180)
                    {
                        if (croTemp.startPoint.X < croTemp.endPoint.X)
                        {
                            if (croTemp.pointList[0].X < croTemp.pointList[5].X)
                            {
                                if (offsetTemp < croTemp.firstPart)
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp < (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
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
                                if (offsetTemp < croTemp.thPart)
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > croTemp.thPart && offsetTemp < (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart)
                                    && offsetTemp < (croTemp.thPart + croTemp.secPart + croTemp.firstPart))
                                    returnPt.X = croTemp.startPoint.X + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
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
                                if (offsetTemp < croTemp.thPart)
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp < (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
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
                                if (offsetTemp < croTemp.firstPart)
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > croTemp.thPart && offsetTemp < (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                    returnPt.Y = croTemp.pointList[2].Y;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart)
                                    && offsetTemp < (croTemp.thPart + croTemp.secPart + croTemp.firstPart))
                                    returnPt.X = croTemp.startPoint.X - offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X))
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
                                if (offsetTemp < croTemp.firstPart)
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp < (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
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
                                if (offsetTemp < croTemp.thPart)
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp < (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
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
                                if (offsetTemp < croTemp.firstPart)
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp < (croTemp.firstPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
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
                                if (offsetTemp < croTemp.thPart)
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                else if (offsetTemp > croTemp.firstPart && offsetTemp < (croTemp.thPart + croTemp.secPart))
                                {
                                    returnPt.X = croTemp.pointList[2].X;
                                    returnPt.Y = croTemp.startPoint.Y - offsetTemp;
                                }
                                else if (offsetTemp > (croTemp.thPart + croTemp.secPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart))
                                    returnPt.Y = croTemp.startPoint.Y + offsetTemp;
                                else if (offsetTemp > (croTemp.firstPart + croTemp.secPart + croTemp.thPart) &&
                                    offsetTemp < (croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.Y))
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

        private Point GetPointOfInitFun(List<RailEle> tempList, int i)
        {
            Point pt = Point.Empty;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            switch (tempList[i].graphType)
            {
                case 1:
                    strTemp = (StraightEle)tempList[i];
                    if (strTemp.pointList[0].X < strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y < strTemp.pointList[1].Y)
                        pt = strTemp.pointList[0];
                    else if (strTemp.pointList[0].X > strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y > strTemp.pointList[1].Y)
                        pt = strTemp.pointList[1];
                    break;
                case 2:
                    curTemp = (CurvedEle)tempList[i];
                    if (curTemp.secDot.X > curTemp.firstDot.X)
                        pt = curTemp.firstDot;
                    else if (curTemp.secDot.X < curTemp.firstDot.X)
                        pt = curTemp.secDot;
                    break;
                case 3:
                    croTemp = (CrossEle)tempList[i];
                    if (croTemp.pointList[0].X < croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                        pt = croTemp.pointList[0];
                    else if (croTemp.pointList[0].X > croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                        pt = croTemp.pointList[5];
                    break;
                default:
                    break;
            }
            return pt;
        }
    }
}
