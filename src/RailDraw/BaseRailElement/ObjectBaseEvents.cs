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

            int hit = _document.HitTest(point, false);

            _hit = hit;
            if (hit > 0)
                _SelectObject = SelectObject.SelectHandle;
            else if (hit == 0)
                _SelectObject = SelectObject.SelectEle;
            else
                _SelectObject = SelectObject.SelectNone;
        }

        public override void OnMouseMove(Point point)
        {
            int n = _document.SelectedDrawObjectList.Count;
            switch (_SelectObject)
            {
                case SelectObject.SelectHandle:
                    if (_document.SelectedDrawObjectList[0].GraphType == 1)
                    {
                        if (n == 1)
                        {
                            _document.SelectedDrawObjectList[0].MoveHandle(_hit, _lastPoint, point);
                        }
                    }
                    else if (_document.SelectedDrawObjectList[0].GraphType == 2)
                    {
                        if (n == 1)
                        {
                            _document.SelectedDrawObjectList[0].MoveHandle(_hit, _lastPoint, point);
                        }
                    }
                    else if (_document.SelectedDrawObjectList[0].GraphType == 3)
                    {
                        if (n == 1)
                        {
                            _document.SelectedDrawObjectList[0].MoveHandle(_hit, _lastPoint, point);
                        }
                    }
                    else if (_document.SelectedDrawObjectList[0].GraphType == 4)
                    {
                        if (n == 1)
                        {
                            _document.SelectedDrawObjectList[0].MoveHandle(_hit, _lastPoint, point);
                        }
                    }
                    break;
                case SelectObject.SelectEle:
                    for (int i = 0; i < n; i++)
                    {
                        if (_document.SelectedDrawObjectList[i].GraphType == 1)
                        {
                            StraightRailEle de = (StraightRailEle)_document.SelectedDrawObjectList[i];
                            _document.SelectedDrawObjectList[i].Move(_lastPoint, point);
                        }
                        else if (_document.SelectedDrawObjectList[i].GraphType == 2)
                        {
                            CurvedRailEle de = (CurvedRailEle)_document.SelectedDrawObjectList[i];
                            _document.SelectedDrawObjectList[i].Move(_lastPoint, point);
                        }
                        else if (_document.SelectedDrawObjectList[i].GraphType == 3)
                        {
                            CrossLeftEle de = (CrossLeftEle)_document.SelectedDrawObjectList[i];
                            _document.SelectedDrawObjectList[i].Move(_lastPoint, point);
                        }
                        else if (_document.SelectedDrawObjectList[i].GraphType == 4)
                        {
                            CrossRightEle de = (CrossRightEle)_document.SelectedDrawObjectList[i];
                            _document.SelectedDrawObjectList[i].Move(_lastPoint, point);
                        }
                    }
                    break;
                case SelectObject.SelectNone:
                    break;
            }
            base.OnMouseMove(point);
        }

        public override void OnMouseDoubleClick(Point point , Size size)
        {
            base.OnMouseDoubleClick(point, size);

            if (_hit >= 0)
            {
                _document.SelectedDrawObjectList[0].ChangeDirection(point , size);
            }
        }
    }
}
