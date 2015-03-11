using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using JamesDOND.Data;
using JamesDOND.Controller;
using JamesDOND.Game;

namespace JamesDONDApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            MainForm mainForm = new MainForm();
            mainForm.Visible = false;

            Overlay overlay = new Overlay(mainForm);
            overlay.Visible = false;

            EventForm eventForm = new EventForm(overlay);
            eventForm.Visible = false;

            StartMenu mainMenu = new StartMenu(mainForm);
            mainMenu.Visible = false;


            List<int> moneyValues =  new List<int>() { 1, 5, 10, 15, 25, 50, 75, 100, 200, 300, 
                                                       400, 500, 750, 1000, 5000, 10000, 25000, 
                                                       50000, 75000, 100000, 200000, 300000, 
                                                       400000, 500000, 750000, 1000000 };

            List<int> caseNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 
                                                      14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

            DONDData gameData = new DONDData("", moneyValues, caseNumbers, 6, 1, 0, 0, 0);

            DONDController controller = new DONDController(mainForm, overlay, eventForm, mainMenu, gameData);


            //mainForm.Visible = true;
            mainMenu.ShowDialog();
            mainForm.ShowDialog();
          


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new MainForm());
        }
    }
}
