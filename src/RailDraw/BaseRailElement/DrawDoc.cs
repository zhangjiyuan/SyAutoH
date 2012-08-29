using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    [XmlInclude(typeof(StraightRailEle))]
    [XmlInclude(typeof(CurvedRailEle))]
    [XmlInclude(typeof(CrossLeftEle))]
    [XmlInclude(typeof(CrossRightEle))]

    public class DrawDoc:BaseRailEle
    {
        private string _name = "";
        [Browsable(false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        [
        XmlArrayItem(Type = typeof(StraightRailEle)),
        XmlArrayItem(Type = typeof(CurvedRailEle)),
        XmlArrayItem(Type = typeof(CrossLeftEle)),
        XmlArrayItem(Type = typeof(CrossRightEle)),
        ]

        [XmlIgnore]
        public static DrawDoc EmptyDocument
        {
            get { return new DrawDoc(); }
        }

        List<BaseRailEle> _CutAndCopyObjectList = new List<BaseRailEle>();

        List<BaseRailEle> _drawObjectList = new List<BaseRailEle>();  
        [Browsable(false)]
        public List<BaseRailEle> DrawObjectList
        {
            get { return _drawObjectList; }
        }
       
        List<BaseRailEle> _selectedDrawObjectList = new List<BaseRailEle>();
        [XmlIgnore]
        [Browsable(false)]
        public List<BaseRailEle> SelectedDrawObjectList
        {
            get { return _selectedDrawObjectList; }
        }

        private BaseRailEle _lastHitedObject = null;
        [XmlIgnore]
        [Browsable(false)]
        public BaseRailEle LastHitedObject
        {
            get { return _lastHitedObject; }
        }

        private enum CutOrCopy
        {
            CutOp, CopyOp, NoneOp
        }
        private CutOrCopy _CutOrCopy = CutOrCopy.NoneOp;

        public override void Draw(Graphics _canvas)
        {
            int n = _drawObjectList.Count;
            for (int i = 0; i < n; i++)
            {
                if (this.DrawMultiFactor != -1)
                {
                    _drawObjectList[i].DrawEnlargeOrShrink(DrawMultiFactor);
                }
                _drawObjectList[i].Draw(_canvas);
                if (_selectedDrawObjectList.Contains(_drawObjectList[i]))
                    _drawObjectList[i].DrawTracker(_canvas);        
            }
            this.DrawMultiFactor = -1;
        }

        public override int HitTest(Point point, bool isSelected)
        {
            int n = 0;
            int hit = -1;
            n = _selectedDrawObjectList.Count;
            for (int i = 0; i < n; i++)
            {
                hit = _selectedDrawObjectList[i].HitTest(point, true);
                if (hit >= 0)
                {
                    _lastHitedObject = _selectedDrawObjectList[i];
                    return hit;
                }
            }

            n = _drawObjectList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                hit = _drawObjectList[i].HitTest(point, false);
                if (hit >= 0)
                {
                    _lastHitedObject = _drawObjectList[i];

                    if (_drawObjectList[i].Selectable)
                    {
                        _selectedDrawObjectList.Clear();
                        _selectedDrawObjectList.Add(_drawObjectList[i]);

                        return hit;
                    }
                    break;
                }

            }
            if (hit == -1) _lastHitedObject = null;
            _selectedDrawObjectList.Clear();
            return -1;
        }

        public void Select(BaseRailEle obj)
        {
            _selectedDrawObjectList.Clear();
            if (obj != null)
                _selectedDrawObjectList.Add(obj);
        }

        public void Cut()
        {
            _CutAndCopyObjectList.Clear();
            if (_selectedDrawObjectList.Count > 0)
            {
                foreach (BaseRailEle o in _selectedDrawObjectList)
                {
                    _CutAndCopyObjectList.Add(o);
                }
                _CutOrCopy = CutOrCopy.CutOp;
            }
        }

        public void Copy()
        {
            _CutAndCopyObjectList.Clear();
            if (_selectedDrawObjectList.Count > 0)
            {
                foreach (BaseRailEle o in _selectedDrawObjectList)
                {
                    _CutAndCopyObjectList.Add(o);
                }
                _CutOrCopy = CutOrCopy.CopyOp;
            }
        }

        public void Paste()
        {
            if (_CutAndCopyObjectList.Count > 0)
            {
                if (_CutOrCopy == CutOrCopy.CutOp)
                {
                    int n = _selectedDrawObjectList.Count;
                    foreach (BaseRailEle obj in _selectedDrawObjectList)
                    {
                        _drawObjectList.Remove(obj);
                    }
                }
                foreach (BaseRailEle o in _CutAndCopyObjectList)
                {
                    if (1 == o.GraphType)
                    {
                        StraightRailEle cl = (StraightRailEle)o;
                        StraightRailEle n = (StraightRailEle)cl.Clone();
                        _drawObjectList.Add(n);
                        Select(n);
                    }
                    else if (2 == o.GraphType)
                    {
                        CurvedRailEle cl = (CurvedRailEle)o;
                        CurvedRailEle n = (CurvedRailEle)cl.Clone();
                        n.ShowCenterDoc = new Point(n.ShowCenterDoc.X + 20, n.ShowCenterDoc.Y + 20);
                        n.ShowFirstDoc = new Point(n.ShowFirstDoc.X + 20, n.ShowFirstDoc.Y + 20);
                        n.ShowSecondDot = new Point(n.ShowSecondDot.X + 20, n.ShowSecondDot.Y + 20);
                        _drawObjectList.Add(n);
                        Select(n);
                    }
                    else if (3 == o.GraphType)
                    {
                        CrossLeftEle cl = (CrossLeftEle)o;
                        CrossLeftEle n = (CrossLeftEle)cl.Clone();
                        n.CenterDoc = new Point(n.CenterDoc.X + 20, n.CenterDoc.Y + 20);
                        int num = n.PointList.Count;
                        for (int i = 0; i < num; i++)
                        {
                            Point pt = n.PointList[i];
                            pt.Offset(20, 20);
                            n.PointList[i] = pt;
                        }
                        _drawObjectList.Add(n);
                        Select(n);
                    }
                    else if (4 == o.GraphType)
                    {
                        CrossRightEle cl = (CrossRightEle)o;
                        CrossRightEle n = (CrossRightEle)cl.Clone();
                        n.CenterDoc = new Point(n.CenterDoc.X + 20, n.CenterDoc.Y + 20);
                        int num = n.PointList.Count;
                        for (int i = 0; i < num; i++)
                        {
                            Point pt = n.PointList[i];
                            pt.Offset(20, 20);
                            n.PointList[i] = pt;
                        }
                        _drawObjectList.Add(n);
                        Select(n);
                    }
                }
            }
        }

        public void Delete()
        {
            int n = _selectedDrawObjectList.Count;
            foreach (BaseRailEle obj in _selectedDrawObjectList)
            {
                _drawObjectList.Remove(obj);
            }
            _selectedDrawObjectList.Clear();
        }
      
        public override void DrawTracker(Graphics _canvas)
        {
        }

        protected override void Translate(int offsetX, int offsetY)
        {
        }
    }
}
