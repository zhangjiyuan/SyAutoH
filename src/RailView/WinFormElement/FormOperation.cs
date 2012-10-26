using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFormElement
{
    public class FormOperation
    {
        FormShowRegion formShowRegion = new FormShowRegion();
        List<Vehicle> vehicleList = new List<Vehicle>();

        TestPoint tempTest = new TestPoint();     //test using,finally delete
        Int16 offset = -1;                                      //test using,finally delete
        Vehicle vehicleOne = new Vehicle(0);                     //using for test

        public FormOperation()
        {
            vehicleList.Add(vehicleOne);
        }

        public void FormShowRegionInit()
        {
            if (formShowRegion.ReadRailSaveFile())
            {
                formShowRegion.InitRailList();
            }
        }

        public void ShowRegion(Graphics canvas)
        {
            formShowRegion.DrawRailInfo(canvas);
            formShowRegion.DrawVehicleInfo(canvas, offset, vehicleList, tempTest);
        }

        public void Test()
        {
            tempTest.Show();
        }
    }
}
