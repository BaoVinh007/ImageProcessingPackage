// Course: CS6563
// Student name: Vinh Nguyen
// Student ID: 000200899
// Assignment #: #1
// Due Date: 10/08/2013
// Signature: _Vinh_____________
// (The signature means that the program is your own work)
// Score: ______________
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace imageCsharp
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            version = 1.0;
            changes = "First release";
        }

        public string GetProgrammer()
        {
            return programmer;
        }
    }
    
    [History("Eunsuk (Eric) Chang", version = 1.0, changes = "2013-06-22 The first version released")]
    [History("Eunsuk (Eric) Chang", version = 1.1, changes = "2013-06-25 X,Y point information added")]
    [History("Eunsuk (Eric) Chang", version = 1.2, changes = "2013-06-28 Histogram added, redesign GUI at segmentation part")]
    static class MainApp
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Type type = typeof(MainApp);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);
            Console.WriteLine("ImageCsharp History");
            foreach (Attribute a in attributes)
            {
                History h = a as History;
                if (h != null)
                    Console.WriteLine("Ver:{0}, Programmer:{1}, Changes:{2}", h.version, h.GetProgrammer(), h.changes);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
      
        }
    }
}
