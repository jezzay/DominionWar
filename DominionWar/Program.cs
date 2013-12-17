#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;
using System.Windows.Forms;

#endregion

namespace Dominion_War
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DominionWarForm());
        }
    }
}