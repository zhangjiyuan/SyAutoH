using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;


namespace BaseRailElement
{
    public abstract class BaseRailEle
    {
        //以下为对象基本属性
        private int _GraphType = 0;
        [Browsable(false)]
        public int GraphType
        {
            get
            {
                return _GraphType;
            }
            set
            {
                _GraphType = value;
            }
        }

        //lock
        protected bool location_lock = false;
        [Description("位置锁定"), Category("锁定")]
        public bool Location_Lock
        {
            get { return location_lock; }
            set { location_lock = value; }
        }

        protected bool size_lock = false;
        [Description("尺寸锁定"), Category("锁定")]
        public bool Size_Lock
        {
            get { return size_lock; }
            set { size_lock = value; }
        }

        private bool _selectable = true;
        [Browsable(false)]
        public bool Selectable
        {
            get { return _selectable; }
            set { _selectable = value; }
        }

        private float _speed = 0;
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private float _angle = 0;
        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        public void Move(Point start, Point end)
        {
            if (location_lock)
                return;
            int x = end.X - start.X;
            int y = end.Y - start.Y;

            Translate(x, y);
        }

        public void MoveHandle(int handle, Point start, Point end)
        {
            if (size_lock)
                return;
            int dx = end.X - start.X;
            int dy = end.Y - start.Y;

            Scale(handle, dx, dy);
        }

        public void ChangeDirection(Point pt , Size sz)
        {
            Rotate(pt, sz);
        }

        internal void OnClick()
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public abstract void Draw(Graphics _canvas);
        public abstract void DrawTracker(Graphics canvas);
        public abstract int HitTest(Point point, bool isSelected);
        protected abstract void Translate(int offsetX, int offsetY);
        protected virtual void Scale(int handle, int dx, int dy) { }
        protected virtual void Rotate(Point pt, Size sz) { }
        public virtual Region GetRedrawRegion() { return null; }
        public virtual void ChangePropertyValue() { }
   

        public event EventHandler Click = null;
    }
}
