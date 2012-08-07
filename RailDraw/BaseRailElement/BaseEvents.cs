using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BaseRailElement
{
    public abstract class BaseEvents
    {
        protected static DrawDoc _document = DrawDoc.EmptyDocument;
        public static DrawDoc Document
        {
            get { return _document; }
            set { _document = value; }
        }

        protected static Point _downPoint = Point.Empty;
        public static Point DownPoint
        {
            get { return _downPoint; }
            set { _downPoint = value; }
        }

        protected static Point _lastPoint = Point.Empty;
        public static Point LastPoint
        {
            get { return _lastPoint; }
            set { _lastPoint = value; }
        }

        public virtual void OnLButtonDown(Point point)
        {
            _downPoint = point;
            _lastPoint = point;
        }
        public virtual void OnMouseMove(Point point)
        {
            _lastPoint = point;
        }

        public virtual void OnMouseDoubleClick(Point point, Size size)
        {
            _downPoint = point;
            _lastPoint = point;
        }
    }
}
