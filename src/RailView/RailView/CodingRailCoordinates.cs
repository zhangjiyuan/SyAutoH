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
            codingEleList.AddRange(railEleList);
            List<RailEle> eleTempList = new List<RailEle>();
            RailEle firstEle = railEleList[0];
            Point startPoint = Point.Empty;
            Point comparePoint = Point.Empty;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
            switch (railEleList[0].graphType)
            {
                case 1:
                    strTemp = (StraightEle)railEleList[0];
                    if (strTemp.pointList[0].X < strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y < strTemp.pointList[1].Y)
                        startPoint = strTemp.pointList[0];
                    else if (strTemp.pointList[0].X > strTemp.pointList[1].X || 
                        strTemp.pointList[0].Y > strTemp.pointList[1].Y)
                        startPoint = strTemp.pointList[1];
                    break;
                case 2:
                    curTemp = (CurvedEle)railEleList[0];
                    if (curTemp.secDot.X > curTemp.firstDot.X)
                        startPoint = curTemp.firstDot;
                    else if (curTemp.secDot.X < curTemp.firstDot.X)
                        startPoint = curTemp.secDot;
                    break;
                case 3:
                    croTemp = (CrossEle)railEleList[0];
                    if (croTemp.pointList[0].X < croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                        startPoint = croTemp.pointList[0];
                    else if (croTemp.pointList[0].X > croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                        startPoint = croTemp.pointList[5];
                    break;
                default:
                    break;
            }
            //compare x
            for (int i = 1; i < n; i++)
            {
                switch (railEleList[i].graphType)
                {
                    case 1:
                        strTemp = (StraightEle)railEleList[i];
                        if (strTemp.pointList[0].X < strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y < strTemp.pointList[1].Y)
                            comparePoint = strTemp.pointList[0];
                        else if (strTemp.pointList[0].X > strTemp.pointList[1].X ||
                            strTemp.pointList[0].Y > strTemp.pointList[1].Y)
                            comparePoint = strTemp.pointList[1];
                        break;
                    case 2:
                        curTemp = (CurvedEle)railEleList[i];
                        if (curTemp.secDot.X > curTemp.firstDot.X)
                            comparePoint = curTemp.firstDot;
                        else if (curTemp.secDot.X < curTemp.firstDot.X)
                            comparePoint = curTemp.secDot;
                        break;
                    case 3:
                        croTemp = (CrossEle)railEleList[i];
                        if (croTemp.pointList[0].X < croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                            comparePoint = croTemp.pointList[0];
                        else if (croTemp.pointList[0].X > croTemp.pointList[5].X ||
                            croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                            comparePoint = croTemp.pointList[5];
                        break;
                    default:
                        break;
                }
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
            switch (eleTempList[0].graphType)
            {
                case 1:
                    strTemp = (StraightEle)eleTempList[0];
                    if (strTemp.pointList[0].X < strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y < strTemp.pointList[1].Y)
                        startPoint = strTemp.pointList[0];
                    else if (strTemp.pointList[0].X > strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y > strTemp.pointList[1].Y)
                        startPoint = strTemp.pointList[1];
                    break;
                case 2:
                    curTemp = (CurvedEle)eleTempList[0];
                    if (curTemp.secDot.X > curTemp.firstDot.X)
                        startPoint = curTemp.firstDot;
                    else if (curTemp.secDot.X < curTemp.firstDot.X)
                        startPoint = curTemp.secDot;
                    break;
                case 3:
                    croTemp = (CrossEle)eleTempList[0];
                    if (croTemp.pointList[0].X < croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                        startPoint = croTemp.pointList[0];
                    else if (croTemp.pointList[0].X > croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                        startPoint = croTemp.pointList[5];
                    break;
                default:
                    break;
            }
            for (int i = 1; i < n; i++)
            {
                switch (eleTempList[i].graphType)
                {
                    case 1:
                        strTemp = (StraightEle)eleTempList[i];
                        if (strTemp.pointList[0].X < strTemp.pointList[1].X ||
                        strTemp.pointList[0].Y < strTemp.pointList[1].Y)
                            comparePoint = strTemp.pointList[0];
                        else if (strTemp.pointList[0].X > strTemp.pointList[1].X ||
                            strTemp.pointList[0].Y > strTemp.pointList[1].Y)
                            comparePoint = strTemp.pointList[1];
                        break;
                    case 2:
                        curTemp = (CurvedEle)eleTempList[i];
                        if (curTemp.secDot.X > curTemp.firstDot.X)
                            comparePoint = curTemp.firstDot;
                        else if (curTemp.secDot.X < curTemp.firstDot.X)
                            comparePoint = curTemp.secDot;
                        break;
                    case 3:
                        croTemp = (CrossEle)eleTempList[i];
                        if (croTemp.pointList[0].X < croTemp.pointList[5].X ||
                        croTemp.pointList[0].Y < croTemp.pointList[5].Y)
                            comparePoint = croTemp.pointList[0];
                        else if (croTemp.pointList[0].X > croTemp.pointList[5].X ||
                            croTemp.pointList[0].Y > croTemp.pointList[5].Y)
                            comparePoint = croTemp.pointList[5];
                        break;
                    default:
                        break;
                }
                if (comparePoint.Y < startPoint.Y && (startPoint.Y - comparePoint.Y) > 2)
                {
                    startPoint = comparePoint;
                    codingEleList.RemoveAt(i);
                    codingEleList.Insert(0, eleTempList[i]);
                }
            }
            return codingEleList;
        }

        public void AssignCoordinates()
        { }

        public void CompareOver()
        { }
    }
}
