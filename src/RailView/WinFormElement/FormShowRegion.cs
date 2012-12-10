using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace WinFormElement
{
    public class FormShowRegion
    {
        public List<RailEle> railInfoEleList = new List<RailEle>();
        public List<RailEle> railCodingEleList = new List<RailEle>();

        public bool ReadRailSaveFile()
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //try
            //{
            //    xmlDoc.Load("..//config//rails.xml");
            //    //xmlDoc.Load("3.xml");
            //}
            //catch
            //{
            //    MessageBox.Show("文件不存在，请打开组态软件进行配置");
            //    return false;
            //}
            //XmlNode root = xmlDoc.SelectSingleNode("DrawDoc");
            //XmlNodeList rootNodeList = xmlDoc.SelectSingleNode("DrawDoc").ChildNodes;
            //foreach (XmlNode rxn in rootNodeList)
            //{
            //    XmlElement rxe = (XmlElement)rxn;
            //    if (rxe.Name == "DrawObjectList")
            //    {
            //        XmlNodeList childNodeList = rxe.ChildNodes;
            //        foreach (XmlNode cxn in childNodeList)
            //        {
            //            XmlElement cxe = (XmlElement)cxn;
            //            XmlNodeList cTwoNodeList = null;
            //            XmlNodeList cThNodeList = null;
            //            XmlNodeList cFNodeList = null;
            //            Point pt = Point.Empty;
            //            switch (cxe.GetAttribute("xsi:type"))
            //            {
            //                case "StraightRailEle":
            //                    StraightEle strTemp = new StraightEle();
            //                    cTwoNodeList = cxe.ChildNodes;
            //                    foreach (XmlNode ctwoxn in cTwoNodeList)
            //                    {
            //                        XmlElement ctwoxe = (XmlElement)ctwoxn;
            //                        if (ctwoxe.Name == "GraphType")
            //                            strTemp.graphType = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "Speed")
            //                            strTemp.speed = float.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "SegmentNumber")
            //                            strTemp.segmentNumber = Int16.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "TagNumber")
            //                            strTemp.tagNumber = Convert.ToInt16(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "Lenght")
            //                            strTemp.lenght = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "StartAngle")
            //                            strTemp.startAngle = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "StartDot")
            //                            strTemp.startDot = ctwoxe.InnerText;
            //                        else if (ctwoxe.Name == "PointList")
            //                        {
            //                            cThNodeList = ctwoxe.ChildNodes;
            //                            foreach (XmlNode cthxn in cThNodeList)
            //                            {
            //                                XmlElement cthxe = (XmlElement)cthxn;
            //                                if (cthxe.Name == "Point")
            //                                {
            //                                    cFNodeList = cthxe.ChildNodes;
            //                                    foreach (XmlNode cfxn in cFNodeList)
            //                                    {
            //                                        XmlElement cfxe = (XmlElement)cfxn;
            //                                        if (cfxe.Name == "X")
            //                                            pt.X = int.Parse(cfxe.InnerText);
            //                                        else if (cfxe.Name == "Y")
            //                                            pt.Y = int.Parse(cfxe.InnerText);
            //                                    }
            //                                    strTemp.pointList.Add(pt);
            //                                }
            //                            }
            //                        }
            //                    }
            //                    railInfoEleList.Add(strTemp);
            //                    break;
            //                case "CurvedRailEle":
            //                    CurvedEle curTemp = new CurvedEle();
            //                    cTwoNodeList = cxn.ChildNodes;
            //                    foreach (XmlNode ctwoxn in cTwoNodeList)
            //                    {
            //                        XmlElement ctwoxe = (XmlElement)ctwoxn;
            //                        if (ctwoxe.Name == "GraphType")
            //                            curTemp.graphType = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "speed")
            //                            curTemp.speed = float.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "SegmentNumber")
            //                            curTemp.segmentNumber = Convert.ToInt16(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "TagNumber")
            //                            curTemp.tagNumber = Int16.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "StartAngle")
            //                            curTemp.startAngle = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "SweepAngle")
            //                            curTemp.sweepAngle = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "Radiu")
            //                            curTemp.radiu = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "Center")
            //                        {
            //                            cThNodeList = ctwoxe.ChildNodes;
            //                            foreach (XmlNode cthxn in cThNodeList)
            //                            {
            //                                XmlElement cthxe = (XmlElement)cthxn;
            //                                if (cthxe.Name == "X")
            //                                    curTemp.center.X = int.Parse(cthxe.InnerText);
            //                                else if (cthxe.Name == "Y")
            //                                    curTemp.center.Y = int.Parse(cthxe.InnerText);
            //                            }
            //                        }
            //                        else if (ctwoxn.Name == "FirstDot")
            //                        {
            //                            cThNodeList = ctwoxn.ChildNodes;
            //                            foreach (XmlNode cthxn in cThNodeList)
            //                            {
            //                                XmlElement cthxe = (XmlElement)cthxn;
            //                                if (cthxe.Name == "X")
            //                                    curTemp.firstDot.X = int.Parse(cthxe.InnerText);
            //                                else if (cthxe.Name == "Y")
            //                                    curTemp.firstDot.Y = int.Parse(cthxe.InnerText);
            //                            }
            //                        }
            //                        else if (ctwoxn.Name == "SecDot")
            //                        {
            //                            cThNodeList = ctwoxn.ChildNodes;
            //                            foreach (XmlNode cthxn in cThNodeList)
            //                            {
            //                                XmlElement cthxe = (XmlElement)cthxn;
            //                                if (cthxe.Name == "X")
            //                                    curTemp.secDot.X = int.Parse(cthxe.InnerText);
            //                                else if (cthxe.Name == "Y")
            //                                    curTemp.secDot.Y = int.Parse(cthxe.InnerText);
            //                            }
            //                        }
            //                    }
            //                    railInfoEleList.Add(curTemp);
            //                    break;
            //                case "CrossEle":
            //                    CrossEle croTemp = new CrossEle();
            //                    cTwoNodeList = cxn.ChildNodes;
            //                    foreach (XmlNode ctwoxn in cTwoNodeList)
            //                    {
            //                        XmlElement ctwoxe = (XmlElement)ctwoxn;
            //                        if (ctwoxe.Name == "GraphType")
            //                            croTemp.graphType = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "Speed")
            //                            croTemp.speed = float.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "SegmentNumber")
            //                            croTemp.segmentNumber = Convert.ToInt16(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "TagNumber")
            //                            croTemp.tagNumber = Int16.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "FirstPart")
            //                            croTemp.firstPart = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "SecPart")
            //                            croTemp.secPart = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "ThPart")
            //                            croTemp.thPart = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "StartAngle")
            //                            croTemp.startAngle = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "RotateAngle")
            //                            croTemp.rotateAngle = int.Parse(ctwoxe.InnerText);
            //                        else if (ctwoxe.Name == "FourPart")
            //                        {
            //                            cThNodeList = ctwoxe.ChildNodes;
            //                            foreach (XmlNode cthxn in cThNodeList)
            //                            {
            //                                XmlElement cthxe = (XmlElement)cthxn;
            //                                if (cthxe.Name == "X")
            //                                    croTemp.fourPart.X = int.Parse(cthxe.InnerText);
            //                                else if (cthxe.Name == "Y")
            //                                    croTemp.fourPart.Y = int.Parse(cthxe.InnerText);
            //                            }
            //                        }
            //                        else if (ctwoxe.Name == "PointList")
            //                        {
            //                            cThNodeList = ctwoxe.ChildNodes;
            //                            foreach (XmlNode cthxn in cThNodeList)
            //                            {
            //                                XmlElement cthxe = (XmlElement)cthxn;
            //                                if (cthxe.Name == "Point")
            //                                {
            //                                    cFNodeList = cthxe.ChildNodes;
            //                                    foreach (XmlNode cfxn in cFNodeList)
            //                                    {
            //                                        XmlElement cfxe = (XmlElement)cfxn;
            //                                        if (cfxe.Name == "X")
            //                                            pt.X = int.Parse(cfxe.InnerText);
            //                                        else if (cfxe.Name == "Y")
            //                                            pt.Y = int.Parse(cfxe.InnerText);
            //                                    }
            //                                    croTemp.pointList.Add(pt);
            //                                }
            //                            }
            //                        }
            //                    }
            //                    railInfoEleList.Add(croTemp);
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //}
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("..//config//rails.xml");
            }
            catch(Exception exp)
            {
                Debug.WriteLine(string.Format("read xml error is {0}", exp));
            }
            foreach (DataTable dt in ds.Tables)
            {
                DataColumn dc = dt.Columns[0];
                if(dc.ColumnName=="GraphType")
                {
                    switch (dt.Rows[0][0].ToString())
                    {
                        case "1":
                            StraightEle strTemp = new StraightEle();
                            Int16 pointListVolStr = 0;
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                switch (dt.Columns[i].ColumnName)
                                {
                                    case "GraphType":
                                        strTemp.graphType = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "Speed":
                                        strTemp.speed = Convert.ToSingle(dt.Rows[0][i]);
                                        break;
                                    case "SegmentNumber":
                                        strTemp.segmentNumber = Convert.ToInt16(dt.Rows[0][i]);
                                        break;
                                    case "TagNumber":
                                        strTemp.tagNumber = Convert.ToInt16(dt.Rows[0][i]);
                                        break;
                                    case "Lenght":
                                        strTemp.lenght = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "StartAngle":
                                        strTemp.startAngle = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "StartDot":
                                        strTemp.startDot = Convert.ToString(dt.Rows[0][i]);
                                        break;
                                    case "PointListVol":
                                        pointListVolStr = Convert.ToInt16(dt.Rows[0][i]);
                                        for (int j = 0; j < pointListVolStr; j++)
                                        {
                                            string str = dt.Rows[0][i + j + 1].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            string[] strPointArray = str.Split(',');
                                            Point ptTemp = new Point() { X = int.Parse(strPointArray[0].Substring(2)), Y = int.Parse(strPointArray[1].Substring(2)) };
                                            strTemp.pointList.Add(ptTemp);
                                        }
                                        break;
                                }
                            }
                            railInfoEleList.Add(strTemp);
                            break;
                        case "2":
                            CurvedEle curTemp = new CurvedEle();
                            string strcur="";
                            string[] strPointArrayCur={};
                            Point ptcur=Point.Empty;
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                switch (dt.Columns[i].ColumnName)
                                {
                                    case "GraphType":
                                        curTemp.graphType = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "Speed":
                                        curTemp.speed = Convert.ToSingle(dt.Rows[0][i]);
                                        break;
                                    case "SegmentNumber":
                                        curTemp.segmentNumber = Convert.ToInt16(dt.Rows[0][i]);
                                        break;
                                    case "TagNumber":
                                        curTemp.tagNumber = Convert.ToInt16(dt.Rows[0][i]);
                                        break;
                                    case "StartAngle":
                                        curTemp.startAngle = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "SweepAngle":
                                        curTemp.sweepAngle = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "Radiu":
                                        curTemp.radiu = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "Center":
                                        strcur = dt.Rows[0][i].ToString();
                                        strcur = strcur.Substring(1, strcur.Length - 2);
                                        strPointArrayCur = strcur.Split(',');
                                        ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                        curTemp.center = ptcur;
                                        break;
                                    case "FirstDot":
                                        strcur = dt.Rows[0][i].ToString();
                                        strcur = strcur.Substring(1, strcur.Length - 2);
                                        strPointArrayCur = strcur.Split(',');
                                        ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                        curTemp.firstDot = ptcur;
                                        break;
                                    case "SecDot":
                                        strcur = dt.Rows[0][i].ToString();
                                        strcur = strcur.Substring(1, strcur.Length - 2);
                                        strPointArrayCur = strcur.Split(',');
                                        ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                        curTemp.secDot = ptcur;
                                        break;
                                }
                            }
                            railInfoEleList.Add(curTemp);
                            break;
                        case "3":
                            CrossEle croTemp = new CrossEle();
                            string strcro="";
                            string[] strPointArrayCro={};
                            Point ptcro=Point.Empty;
                            Int16 pointListVolCro = 0;
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                switch (dt.Columns[i].ColumnName)
                                {
                                    case "GraphType":
                                        croTemp.graphType = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "Speed":
                                        croTemp.speed = Convert.ToSingle(dt.Rows[0][i]);
                                        break;
                                    case "SegmentNumber":
                                        croTemp.segmentNumber = Convert.ToInt16(dt.Rows[0][i]);
                                        break;
                                    case "TagNumber":
                                        croTemp.tagNumber = Convert.ToInt16(dt.Rows[0][i]);
                                        break;
                                    case "FirstPart":
                                        croTemp.firstPart = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "SecPart":
                                        croTemp.secPart = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "ThPart":
                                        croTemp.thPart = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "FourPart":
                                        strcro = dt.Rows[0][i].ToString();
                                        strcro = strcro.Substring(1, strcro.Length - 2);
                                        strPointArrayCro = strcro.Split(',');
                                        ptcro = new Point() { X = int.Parse(strPointArrayCro[0].Substring(2)), Y = int.Parse(strPointArrayCro[1].Substring(2)) };
                                        croTemp.fourPart = ptcro;
                                        break;
                                    case "StartAngle":
                                        croTemp.startAngle = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "RotateAngle":
                                        croTemp.rotateAngle = Convert.ToInt32(dt.Rows[0][i]);
                                        break;
                                    case "PointListVol":
                                        pointListVolCro = Convert.ToInt16(dt.Rows[0][i]);
                                        for (Int16 j = 0; j < pointListVolCro; j++)
                                        {
                                            strcro = dt.Rows[0][i + j + 1].ToString();
                                            strcro = strcro.Substring(1, strcro.Length - 2);
                                            strPointArrayCro = strcro.Split(',');
                                            ptcro = new Point() { X = int.Parse(strPointArrayCro[0].Substring(2)), Y = int.Parse(strPointArrayCro[1].Substring(2)) };
                                            croTemp.pointList.Add(ptcro);
                                        }
                                        break;
                                }
                            }
                            railInfoEleList.Add(croTemp);
                            break;
                    }
                }
            }
            return true;
        }

        public void InitRailList()
        {
 //           List<RailEle> tempList = GetStrEle(railInfoEleList);
 //           railCodingEleList = ArrangeStrEle(tempList);
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

        public void DrawVehicleInfo(Graphics canvas, Dictionary<uint, Vehicle> vList)
        {
            foreach (KeyValuePair<uint, Vehicle> item in vList)
            {
                Vehicle oht = item.Value;
                //obj.VehiclePosCoding = obj.tempTest.offsetOfText;
                //obj.PosCode += 50;

                if (oht.PosCode > 6100)
                {
                    //obj.VehiclePosCoding = 0;
                }

               // if (obj.VehiclePosCoding != -1)
                {
                    Pen pen = new Pen(Color.Red, 1);
                    Point carrierCoor = ComputeCoordinates(railCodingEleList, Convert.ToUInt32(oht.PosCode));
                    oht.ShowInScreen(canvas, carrierCoor);
                    pen.Dispose();
                }
            }
        }

        private Point ComputeCoordinates(List<RailEle> tempList, uint locationValue)
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

        private Int16 ComputeSegmentNumber(uint value, List<RailEle> paraList)
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

        private Int16 ComputeSegmentOffset(uint value, List<RailEle> tempList, Int16 segNum)
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
