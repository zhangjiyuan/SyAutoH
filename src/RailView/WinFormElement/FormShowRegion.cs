using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace WinFormElement
{
    public class FormShowRegion
    {
        public List<RailEle> railInfoEleList = new List<RailEle>();
        public List<RailEle> railCodingEleList = new List<RailEle>();

        public bool ReadRailSaveFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("..//config//rails.xml");
                //xmlDoc.Load("3.xml");
            }
            catch
            {
                MessageBox.Show("文件不存在，请打开组态软件进行配置");
                return false;
            }
            XmlNode root = xmlDoc.SelectSingleNode("DrawDoc");
            XmlNodeList rootNodeList = xmlDoc.SelectSingleNode("DrawDoc").ChildNodes;
            foreach (XmlNode rxn in rootNodeList)
            {
                XmlElement rxe = (XmlElement)rxn;
                if (rxe.Name == "DrawObjectList")
                {
                    XmlNodeList childNodeList = rxe.ChildNodes;
                    foreach (XmlNode cxn in childNodeList)
                    {
                        XmlElement cxe = (XmlElement)cxn;
                        XmlNodeList cTwoNodeList = null;
                        XmlNodeList cThNodeList = null;
                        XmlNodeList cFNodeList = null;
                        Point pt = Point.Empty;
                        switch (cxe.GetAttribute("xsi:type"))
                        {
                            case "StraightRailEle":
                                StraightEle strTemp = new StraightEle();
                                cTwoNodeList = cxe.ChildNodes;
                                foreach (XmlNode ctwoxn in cTwoNodeList)
                                {
                                    XmlElement ctwoxe = (XmlElement)ctwoxn;
                                    if (ctwoxe.Name == "GraphType")
                                        strTemp.graphType = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "Speed")
                                        strTemp.speed = float.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "SegmentNumber")
                                        strTemp.segmentNumber = Int16.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "TagNumber")
                                        strTemp.tagNumber = Convert.ToInt16(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "Lenght")
                                        strTemp.lenght = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "StartAngle")
                                        strTemp.startAngle = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "StartDot")
                                        strTemp.startDot = ctwoxe.InnerText;
                                    else if (ctwoxe.Name == "PointList")
                                    {
                                        cThNodeList = ctwoxe.ChildNodes;
                                        foreach (XmlNode cthxn in cThNodeList)
                                        {
                                            XmlElement cthxe = (XmlElement)cthxn;
                                            if (cthxe.Name == "Point")
                                            {
                                                cFNodeList = cthxe.ChildNodes;
                                                foreach (XmlNode cfxn in cFNodeList)
                                                {
                                                    XmlElement cfxe = (XmlElement)cfxn;
                                                    if (cfxe.Name == "X")
                                                        pt.X = int.Parse(cfxe.InnerText);
                                                    else if (cfxe.Name == "Y")
                                                        pt.Y = int.Parse(cfxe.InnerText);
                                                }
                                                strTemp.pointList.Add(pt);
                                            }
                                        }
                                    }
                                }
                                railInfoEleList.Add(strTemp);
                                break;
                            case "CurvedRailEle":
                                CurvedEle curTemp = new CurvedEle();
                                cTwoNodeList = cxn.ChildNodes;
                                foreach (XmlNode ctwoxn in cTwoNodeList)
                                {
                                    XmlElement ctwoxe = (XmlElement)ctwoxn;
                                    if (ctwoxe.Name == "GraphType")
                                        curTemp.graphType = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "speed")
                                        curTemp.speed = float.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "SegmentNumber")
                                        curTemp.segmentNumber = Convert.ToInt16(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "TagNumber")
                                        curTemp.tagNumber = Int16.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "StartAngle")
                                        curTemp.startAngle = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "SweepAngle")
                                        curTemp.sweepAngle = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "Radiu")
                                        curTemp.radiu = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "Center")
                                    {
                                        cThNodeList = ctwoxe.ChildNodes;
                                        foreach (XmlNode cthxn in cThNodeList)
                                        {
                                            XmlElement cthxe = (XmlElement)cthxn;
                                            if (cthxe.Name == "X")
                                                curTemp.center.X = int.Parse(cthxe.InnerText);
                                            else if (cthxe.Name == "Y")
                                                curTemp.center.Y = int.Parse(cthxe.InnerText);
                                        }
                                    }
                                    else if (ctwoxn.Name == "FirstDot")
                                    {
                                        cThNodeList = ctwoxn.ChildNodes;
                                        foreach (XmlNode cthxn in cThNodeList)
                                        {
                                            XmlElement cthxe = (XmlElement)cthxn;
                                            if (cthxe.Name == "X")
                                                curTemp.firstDot.X = int.Parse(cthxe.InnerText);
                                            else if (cthxe.Name == "Y")
                                                curTemp.firstDot.Y = int.Parse(cthxe.InnerText);
                                        }
                                    }
                                    else if (ctwoxn.Name == "SecDot")
                                    {
                                        cThNodeList = ctwoxn.ChildNodes;
                                        foreach (XmlNode cthxn in cThNodeList)
                                        {
                                            XmlElement cthxe = (XmlElement)cthxn;
                                            if (cthxe.Name == "X")
                                                curTemp.secDot.X = int.Parse(cthxe.InnerText);
                                            else if (cthxe.Name == "Y")
                                                curTemp.secDot.Y = int.Parse(cthxe.InnerText);
                                        }
                                    }
                                }
                                railInfoEleList.Add(curTemp);
                                break;
                            case "CrossEle":
                                CrossEle croTemp = new CrossEle();
                                cTwoNodeList = cxn.ChildNodes;
                                foreach (XmlNode ctwoxn in cTwoNodeList)
                                {
                                    XmlElement ctwoxe = (XmlElement)ctwoxn;
                                    if (ctwoxe.Name == "GraphType")
                                        croTemp.graphType = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "Speed")
                                        croTemp.speed = float.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "SegmentNumber")
                                        croTemp.segmentNumber = Convert.ToInt16(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "TagNumber")
                                        croTemp.tagNumber = Int16.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "FirstPart")
                                        croTemp.firstPart = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "SecPart")
                                        croTemp.secPart = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "ThPart")
                                        croTemp.thPart = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "StartAngle")
                                        croTemp.startAngle = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "RotateAngle")
                                        croTemp.rotateAngle = int.Parse(ctwoxe.InnerText);
                                    else if (ctwoxe.Name == "FourPart")
                                    {
                                        cThNodeList = ctwoxe.ChildNodes;
                                        foreach (XmlNode cthxn in cThNodeList)
                                        {
                                            XmlElement cthxe = (XmlElement)cthxn;
                                            if (cthxe.Name == "X")
                                                croTemp.fourPart.X = int.Parse(cthxe.InnerText);
                                            else if (cthxe.Name == "Y")
                                                croTemp.fourPart.Y = int.Parse(cthxe.InnerText);
                                        }
                                    }
                                    else if (ctwoxe.Name == "PointList")
                                    {
                                        cThNodeList = ctwoxe.ChildNodes;
                                        foreach (XmlNode cthxn in cThNodeList)
                                        {
                                            XmlElement cthxe = (XmlElement)cthxn;
                                            if (cthxe.Name == "Point")
                                            {
                                                cFNodeList = cthxe.ChildNodes;
                                                foreach (XmlNode cfxn in cFNodeList)
                                                {
                                                    XmlElement cfxe = (XmlElement)cfxn;
                                                    if (cfxe.Name == "X")
                                                        pt.X = int.Parse(cfxe.InnerText);
                                                    else if (cfxe.Name == "Y")
                                                        pt.Y = int.Parse(cfxe.InnerText);
                                                }
                                                croTemp.pointList.Add(pt);
                                            }
                                        }
                                    }
                                }
                                railInfoEleList.Add(croTemp);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return true;
        }

        public void InitRailList()
        {
            List<RailEle> tempList = GetStrEle(railInfoEleList);
            railCodingEleList = ArrangeStrEle(tempList);
        }

        public void DrawRailInfo(Graphics canvas)
        {
            Pen pen = new Pen(Color.Black, 1);
            foreach (RailEle obj in railInfoEleList)
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
            pen.Dispose();
        }

        public void DrawVehicleInfo(Graphics canvas, Int16 offset, List<Vehicle> vList, TestPoint tempTest)
        {
            offset = tempTest.offsetOfText;
            if (offset != -1)
            {
                Pen pen = new Pen(Color.Red, 1);
                Point carrierCoor = ComputeCoordinates(railCodingEleList, Convert.ToUInt16(offset));
                foreach (Vehicle obj in vList)
                {
                    obj.ShowInScreen(canvas, carrierCoor);
                }
                pen.Dispose();
            }
        }

        private Point ComputeCoordinates(List<RailEle> tempList, ushort locationValue)
        {
            Point returnPt = Point.Empty;
            Int32 offsetTemp = 0;
            Int16 section = 0;
            StraightEle strTemp = new StraightEle();
            CurvedEle curTemp = new CurvedEle();
            CrossEle croTemp = new CrossEle();
//            ComputeOffset(locationValue);
            section = ComputeSegmentNumber(locationValue, tempList);
            offsetTemp = ComputeSegmentOffset(locationValue, tempList, section);
            switch (tempList[section].graphType)
            {
                case 1:
                    strTemp = (StraightEle)tempList[section];
                    offsetTemp = offsetTemp * strTemp.lenght / strTemp.tagNumber;
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
                default:
                    break;
            }
            return returnPt;
        }

        private List<RailEle> GetStrEle(List<RailEle> paraList)
        {
            List<RailEle> tempList = new List<RailEle>();
            StraightEle strTemp = new StraightEle();
            Int16 num = Convert.ToInt16(paraList.Count);
            for (Int16 i = 0; i < num; i++)
            {
                if (paraList[i].graphType == 1)
                {
                    strTemp = (StraightEle)paraList[i];
                    if (strTemp.startDot == "first dot")
                    {
                        paraList[i].startPoint = strTemp.pointList[0];
                        paraList[i].endPoint = strTemp.pointList[1];
                    }
                    else if (strTemp.startDot == "sec dot")
                    {
                        paraList[i].startPoint = strTemp.pointList[1];
                        paraList[i].endPoint = strTemp.pointList[0];
                    }
                    tempList.Add(paraList[i]);
                }
            }
            return tempList;
        }

        private List<RailEle> ArrangeStrEle(List<RailEle> paraList)
        {
            List<RailEle> tempList = new List<RailEle>();
            StraightEle strTemp = new StraightEle();
            Int16 num = Convert.ToInt16(paraList.Count);
            for (Int16 i = 0; i < num; i++)
            {
                for (Int16 j = 0; j < num; j++)
                {
                    strTemp = (StraightEle)paraList[j];
                    if (strTemp.segmentNumber == (i + 1))
                    {
                        tempList.Add(paraList[j]);
                        break;
                    }
                }
            }
            return tempList;
        }

        private Int16 ComputeSegmentNumber(ushort value, List<RailEle> paraList)
        {
            Int16 temp = Convert.ToInt16(value);
            Int16 segNum = 0;
            for (Int16 i = 0; i < paraList.Count; i++)
            {
                if (paraList[i].segmentNumber != 0 && temp < paraList[i].tagNumber)
                {
                    segNum = Convert.ToInt16(i);
                    i = Convert.ToInt16(paraList.Count - 1);
                }
                temp -= paraList[i].tagNumber;
            }
            return segNum;
        }

        private Int16 ComputeSegmentOffset(ushort value, List<RailEle> tempList, Int16 segNum)
        {
            Int16 temp = Convert.ToInt16(value);
            for (Int16 i = 0; i < segNum; i++)
            {
                temp -= tempList[i].tagNumber;
            }
            return temp;
        }
    }

    public abstract class RailEle
    {
        public int graphType = 0;
        public float speed = 0;
        public Int16 segmentNumber = 0;
        public Int16 tagNumber = 0;
        public Point startPoint = Point.Empty;
        public Point endPoint = Point.Empty;
    }

    public class StraightEle : RailEle
    {
        public int lenght = 0;
        public int startAngle = 0;
        public string startDot = "";
        public List<Point> pointList = new List<Point>();
    }

    public class CurvedEle : RailEle
    {
        public int startAngle = 0;
        public int sweepAngle = 0;
        public int radiu = 0;
        public Point center = Point.Empty;
        public Point firstDot = Point.Empty;
        public Point secDot = Point.Empty;
    }

    public class CrossEle : RailEle
    {
        public int firstPart = 0;
        public int secPart = 0;
        public int thPart = 0;
        public Point fourPart = Point.Empty;
        public int startAngle = 0;
        public int rotateAngle = 0;
        public List<Point> pointList = new List<Point>();
    }
}
