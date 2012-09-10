using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace BaseRailElement
{
    public class RailLabal : BaseRailEle
    {
        private ObjectLabelOp objectLabelOp = new ObjectLabelOp();
        private Font font = null;
        [XmlIgnore]
        [Description("文本字体"), Category("文本")]
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        private string text = "Label";
        [Description("文本内容"), Category("文本")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private Rectangle rect = new Rectangle();

        private Point rectOrigionLoca = new Point();
        public Point RectOrigionLoca
        {
            get { return rectOrigionLoca; }
            set { rectOrigionLoca = value; }
        }


        public RailLabal() { GraphType = 4; }

        public RailLabal CreatEle(int multiFactor)
        {
            DrawMultiFactor = multiFactor;
            Point rectLocation = new Point(10, 10);
            Size rectSize = new Size(50, 15);
            rect.Location = rectLocation;
            rect.Size = rectSize;
            rectOrigionLoca = rectLocation;
            return this;
        }

        public override void Draw(Graphics canvas)
        {
            if (font == null)
            {
                font = new Font("新宋体", 12, FontStyle.Regular);
            }
            RectangleF rc = rect;
            SolidBrush bsh = new SolidBrush(Color.Black);
            canvas.DrawString(text, font, bsh, rc);
        }

        public override void DrawTracker(Graphics canvas)
        {
            objectLabelOp.DrawTracker(canvas, rect);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectLabelOp.HitTest(point, isSelected, rect);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = rect.Location;
            pt.Offset(offsetX, offsetY);
            rect.Location = pt;
            rectOrigionLoca.X = pt.X / DrawMultiFactor;
            rectOrigionLoca.Y = pt.Y / DrawMultiFactor;
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            rect = objectLabelOp.Scale(handle, rect, dx, dy);
            rectOrigionLoca.X = rect.X / DrawMultiFactor;
            rectOrigionLoca.Y = rect.Y / DrawMultiFactor;
        }

        public object Clone()
        {
            RailLabal cl = new RailLabal();
            Point pt = rect.Location;
            pt.Offset(10, 10);
            cl.rect = rect;
            cl.rect.Location = pt;
            cl.DrawMultiFactor = DrawMultiFactor;
            cl.Font = font;
            cl.GraphType = GraphType;
            cl.LocationLock = locationLock;
            cl.RectOrigionLoca = RectOrigionLoca;
            cl.SizeLock = SizeLock;
            cl.Text = text;
            return cl;
        }

        public override void DrawEnlargeOrShrink(float multiFactor)
        {
            Point pt = RectOrigionLoca;
            if (multiFactor > 1)
            {
                pt.X *= DrawMultiFactor;
                pt.Y *= DrawMultiFactor;               
            }
            rect.Location = pt;
        }

        public override bool ChosedInRegion(Rectangle rc)
        { 
            if(rc.Contains(rect))
                return true;
            return false;
        }
    }
}
