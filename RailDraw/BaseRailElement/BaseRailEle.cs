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

        //name
        protected string _id = "";
        [Description("名称"), Category("名称")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //lock
        protected bool _lock = false;
        [Description("锁定"), Category("锁定")]
        public bool Lock
        {
            get { return _lock; }
            set { _lock = value; }
        }

        //visible
        protected bool _visible = true;
        [Description("可见"), Category("可见")]
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        protected Point _rotatePoint = Point.Empty;
        //[Description("旋转围绕的点"), Category("旋转角度")]
        [Browsable(false)]
        public virtual Point RotatePoint
        {
            get { return _rotatePoint; }
            set { _rotatePoint = value; }
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

        [Browsable(false)]
        private bool _iscreat = false;
        public bool IsCreat
        {
            get { return _iscreat; }
            set { _iscreat = value; }
        }

        public void Move(Point start, Point end)
        {
            if (_lock)
                return;
            int x = end.X - start.X;
            int y = end.Y - start.Y;

            Translate(x, y);
        }

        public void MoveHandle(int handle, Point start, Point end)
        {
            if (_lock)
                return;
            int dx = end.X - start.X;
            int dy = end.Y - start.Y;

            Scale(handle, dx, dy);
        }

        public void ChangeDirection(Point pt , Size sz)
        {
            Rotate(pt, sz);
        }
  //      public void Rotate(float angle)
  //      {
  //          RotateAt(angle, RotatePoint);
  //      }

        public void RotateAt(float angle, Point point)
        {
            _rotatePoint = point;
            //         CustomRotate(angle, point);
        }

        //      protected abstract void CustomRotate(float angle, Point point);

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
   

        public event EventHandler Click = null;
    }
}
