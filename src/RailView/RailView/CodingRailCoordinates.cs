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
        public Dictionary<long,Point> coordinatesList=new Dictionary<long,Point>();

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
                        break;
                    case 2:
                        curTemp = (CurvedEle)tempList[i];
                        if (startPt == curTemp.firstDot)
                            endPt = curTemp.secDot;
                        else
                            endPt = curTemp.firstDot;
                        break;
                    case 3:
                        croTemp = (CrossEle)tempList[i];
                        if (startPt == croTemp.pointList[0])
                            endPt = croTemp.pointList[5];
                        else
                            endPt = croTemp.pointList[0];
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

        public void AssignCoordinates()
        { }

        public void CompareOver()
        { }

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
