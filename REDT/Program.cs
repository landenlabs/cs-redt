using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace nsREDT
{
	static class Program
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
        static void Main(string[] cmdLineArgs)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(cmdLineArgs));
		}
	}
}