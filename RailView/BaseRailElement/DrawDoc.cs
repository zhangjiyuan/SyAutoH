using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    class DrawDoc
    {
        private string _name = "";
        [Browsable(false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        List<BaseRailEle> _CopyObjectList = new List<BaseRailEle>(2);
        List<BaseRailEle> _drawObjectList = new List<BaseRailEle>(2);

        [
        XmlArrayItem(Type = typeof(StraightRailEle)),
        XmlArrayItem(Type = typeof(CurvedRailEle)),
        XmlArrayItem(Type = typeof(CrossRailEle)),
        ]

        [Browsable(false)]
        public List<BaseRailEle> DrawObjectList
        {
            get { return _drawObjectList; }
        }

        List<BaseRailEle> _selectedDrawObjectList = new List<BaseRailEle>(2);
        [XmlIgnore]
        [Browsable(false)]
        public List<BaseRailEle> SelectedDrawObjectList
        {
            get { return _selectedDrawObjectList; }
        }

  //      public override void Draw(Graphics _canvas)
   //     { 
   //     }

        [XmlIgnore]
        public static DrawDoc EmptyDocument
        {
            get { return new DrawDoc(); }
        }

        public void Select(BaseRailEle obj)
        {
            _selectedDrawObjectList.Clear();
            if (obj != null)
                _selectedDrawObjectList.Add(obj);
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

        public bool MoveSelectionToFront()
        {
            int n;
            int i;
            List<BaseRailEle> tempList = new List<BaseRailEle>();
            n = _drawObjectList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for (i = n - 1; i >= 0; i--)
            {
                if (_selectedDrawObjectList.Contains(_drawObjectList[i]))
                {
                    tempList.Add(_drawObjectList[i]);
                    _drawObjectList.RemoveAt(i);
                }
            }

            // Read temporary list in direct order and insert every item
            // to the beginning of the source list
            n = tempList.Count;

            for (i = 0; i < n; i++)
            {
                _drawObjectList.Insert(0, tempList[i]);
            }

            return (n > 0);
        }

        public bool MoveSelectionToBack()
        {
            int n;
            int i;
            List<BaseRailEle> tempList = new List<BaseRailEle>();

            n = _drawObjectList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for (i = n - 1; i >= 0; i--)
            {
                if (_selectedDrawObjectList.Contains(_drawObjectList[i]))
                {
                    tempList.Add(_drawObjectList[i]);
                    _drawObjectList.RemoveAt(i);
                }
            }

            // Read temporary list in reverse order and add every item
            // to the end of the source list
            n = tempList.Count;

            for (i = n - 1; i >= 0; i--)
            {
                _drawObjectList.Add(tempList[i]);
            }

            return (n > 0);
        }

        public void Cut()
        {
            ;
        }

        public void Copy()
        {
            ;
        }

        public void Paste()
        {
            ;
        }
    }
}
