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
        private int graphType = 0;
        [Browsable(false)]
        public int GraphType
        {
            get { return graphType; }
            set { graphType = value; }
        }

        //lock
        protected bool locationLock = false;
        [Description("位置锁定"), Category("锁定")]
        public bool LocationLock
        {
            get { return locationLock; }
            set { locationLock = value; }
        }

        protected bool sizeLock = false;
        [Description("尺寸锁定"), Category("锁定")]
        public bool SizeLock
        {
            get { return sizeLock; }
            set { sizeLock = value; }
        }

        private bool selectable = true;
        [Browsable(false)]
        public bool Selectable
        {
            get { return selectable; }
            set { selectable = value; }
        }

        private float speed = 0;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
      
        private int drawMultiFactor = 1;
        [XmlIgnore]
        [Browsable(false)]
        public int DrawMultiFactor
        {
            get { return drawMultiFactor; }
            set { drawMultiFactor = value; }
        }

        public void Move(Point start, Point end)
        {
            if (locationLock)
                return;
            int x = (end.X - start.X) / drawMultiFactor;
            int y = (end.Y - start.Y) / drawMultiFactor;
            Translate(x, y);
        }

        public void MoveHandle(int handle, Point start, Point end)
        {
            if (sizeLock)
                return;
            int dx = (end.X - start.X) / drawMultiFactor;
            int dy = (end.Y - start.Y) / drawMultiFactor;
            Scale(handle, dx, dy);
        }

        internal void OnClick()
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public abstract void Draw(Graphics _canvas);
        public virtual void DrawTracker(Graphics canvas) { }
        public virtual int HitTest(Point point, bool isSelected) { return 1; }
        protected virtual void Translate(int offsetX, int offsetY) { }
        protected virtual void Scale(int handle, int dx, int dy) { }
        protected virtual void Rotate(Point pt, Size sz) { }
        public virtual Region GetRedrawRegion() { return null; }
        public virtual void ChangePropertyValue() { }
        public virtual void RotateCounterClw() { }
        public virtual void RotateClw() { }
        public virtual void DrawEnlargeOrShrink(float draw_multi_factor) { }
        public virtual void ObjectMirror() { }
        public virtual bool ChosedInRegion(Rectangle rect) { return false; }
        public event EventHandler Click = null;
    }
}
