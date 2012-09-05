using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BaseRailElement
{
    public class ObjectBaseEvents : BaseEvents
    {
        public enum SelectObject
        {
            SelectEle, SelectHandle, SelectNone
        }
        private SelectObject _SelectObject = SelectObject.SelectNone;

        private int _hit = -1;
        
        public override void OnLButtonDown(Point point)
        {
            base.OnLButtonDown(point);
            int hit = document.HitTest(point, false);
            _hit = hit;
            if (hit > 0)
                _SelectObject = SelectObject.SelectHandle;
            else if (hit == 0)
                _SelectObject = SelectObject.SelectEle;
            else
                _SelectObject = SelectObject.SelectNone;
            document.changeChooseSign(true, point);
        }

        public override void OnLButtonUp(Point point)
        {
            base.OnLButtonUp(point);
            document.changeChooseSign(false, point);
        }

        public override void OnMouseMove(Point point)
        {
            int n = document.SelectedDrawObjectList.Count;
            switch (_SelectObject)
            {
                case SelectObject.SelectHandle:
                    if (document.SelectedDrawObjectList[0].GraphType == 1)
                    {
                        if (n == 1)
                        {
                            document.SelectedDrawObjectList[0].MoveHandle(_hit, lastPoint, point);
                        }
                    }
                    else if (document.SelectedDrawObjectList[0].GraphType == 2)
                    {
                        if (n == 1)
                        {
                            document.SelectedDrawObjectList[0].MoveHandle(_hit, lastPoint, point);
                        }
                    }
                    else if (document.SelectedDrawObjectList[0].GraphType == 3)
                    {
                        if (n == 1)
                        {
                            document.SelectedDrawObjectList[0].MoveHandle(_hit, lastPoint, point);
                        }
                    }
                    else if (document.SelectedDrawObjectList[0].GraphType == 4)
                    {
                        if (n == 1)
                        {
                            document.SelectedDrawObjectList[0].MoveHandle(_hit, lastPoint, point);
                        }
                    }
                    else if (document.SelectedDrawObjectList[0].GraphType == 5)
                    {
                        if (n == 1)
                        {
                            document.SelectedDrawObjectList[0].MoveHandle(_hit, lastPoint, point);
                        }
                    }
                    break;
                case SelectObject.SelectEle:
                    for (int i = 0; i < n; i++)
                    {
                        if (document.SelectedDrawObjectList[i].GraphType == 1)
                        {
                            StraightRailEle de = (StraightRailEle)document.SelectedDrawObjectList[i];
                            document.SelectedDrawObjectList[i].Move(lastPoint, point);
                        }
                        else if (document.SelectedDrawObjectList[i].GraphType == 2)
                        {
                            CurvedRailEle de = (CurvedRailEle)document.SelectedDrawObjectList[i];
                            document.SelectedDrawObjectList[i].Move(lastPoint, point);
                        }
                        else if (document.SelectedDrawObjectList[i].GraphType == 4)
                        {
                            RailLabal de = (RailLabal)document.SelectedDrawObjectList[i];
                            document.SelectedDrawObjectList[i].Move(lastPoint, point);
                        }
                        else if (document.SelectedDrawObjectList[i].GraphType == 5)
                        {
                            CrossEle de = (CrossEle)document.SelectedDrawObjectList[i];
                            document.SelectedDrawObjectList[i].Move(lastPoint, point);
                        }
                    }
                    break;
                case SelectObject.SelectNone:
                    document.changeChooseSign(true, point);
                    break;
            }
            base.OnMouseMove(point);
        }

        public override Point DrapDrawRegion(Point point)
        {
            Point pt_offset = Point.Empty;
            pt_offset.X = point.X - lastPoint.X;
            pt_offset.Y = point.Y - lastPoint.Y;
            base.DrapDrawRegion(point);
            return pt_offset;
        }
        public override void ChangePropertyValue()
        {
            int n = document.SelectedDrawObjectList.Count;
            document.SelectedDrawObjectList[n - 1].ChangePropertyValue();
        }
    }
}
