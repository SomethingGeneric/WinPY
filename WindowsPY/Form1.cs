using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace WindowsPY
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WebClient webClient = new WebClient();

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir C:\\WinPY\\";
            process.StartInfo = startInfo;
            process.Start();

            MessageBox.Show("We're going to download Python 3 for you. The installer will start. Please make sure to install for all users, and click the check boxes to add to PATH, and install PIP");

            webClient.DownloadFile("https://www.python.org/ftp/python/3.7.2/python-3.7.2.exe", @"c:\temp\pythoninst.exe");

            Process myProcess = new Process();

            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "C:\\WinPy\\pythoninst.exe";
            myProcess.Start();
            // This code assumes the process you are starting will terminate itself.
            // Given that is is started without a window so you cannot terminate it
            // on the desktop, it must terminate itself or you can do it programmatically
            // from this application using the Kill method.

            MessageBox.Show("Now we're going to download a tool called git, as most full python scripts are git repositories. Please accept all default options.");

            webClient.DownloadFile("https://github.com/git-for-windows/git/releases/download/v2.20.1.windows.1/Git-2.20.1-64-bit.exe",@"c:\temp\gitinst.exe");

            Process getgit = new Process();
            getgit.StartInfo.UseShellExecute = false;
            getgit.StartInfo.FileName = "C:\\WinPy\\gitinst.exe";
            getgit.Start();

            MessageBox.Show("All done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = urlbox.Text;
            string path = pathbox.Text;
            Process git = new Process();
            ProcessStartInfo gitinfo = new ProcessStartInfo();

            gitinfo.FileName = "git.exe";
            gitinfo.Arguments = "clone " + url + " C:\\WinPy\\" + path;
            git.StartInfo = gitinfo;
            git.Start();

            Process.Start(@"C:\\WinPY\\");

            MessageBox.Show("Now click the next button, unless the project page says that the requirements are in a different file.");
            thiccboi.GlobalVar = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string final = "C:\\WinPY\\" + thiccboi.GlobalVar + "\\" + textBox1.Text;
            Console.WriteLine(final);
            Directory.SetCurrentDirectory(@"C:\\WinPY\\" + thiccboi.GlobalVar + "\\");
            Process pip = new Process();
            ProcessStartInfo pipinfo = new ProcessStartInfo();
            pipinfo.FileName = "python";
            pipinfo.Arguments = "-m pip install -r " + final;
            pip.StartInfo = pipinfo;
            pip.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            thiccboi.GlobalVar = overridebox.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string script = mainbox.Text;
            Directory.SetCurrentDirectory(@"C:\\WinPY\\" + thiccboi.GlobalVar + "\\");
            Process python = new Process();
            ProcessStartInfo pyinfo = new ProcessStartInfo();
            pyinfo.FileName = "python";
            pyinfo.Arguments = script;
            python.StartInfo = pyinfo;
            python.Start();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    static class thiccboi
    {
        private static string _globalVar = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
}
