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

            MessageBox.Show("We're going to download Python 3 for you. The installer will start. 
                Please make sure to install for all users, and click the check boxes to add to PATH, and install PIP");
    //heckin line length trash dingbat
            webClient.DownloadFile("https://www.python.org/ftp/python/3.7.2/python-3.7.2.exe", @"c:\temp\pythoninst.exe");

            Process myProcess = new Process();

            myProcess.StartInfo.UseShellExecute = false;
            //escape sequences dingbat
            myProcess.StartInfo.FileName = @"C:\\WinPy\\pythoninst.exe";
            myProcess.Start();
            // This code assumes the process you are starting will terminate itself.
            // Given that is is started without a window so you cannot terminate it
            // on the desktop, it must terminate itself or you can do it programmatically
            // from this application using the Kill method.

//aaaaaaaaaaaaaaaaaaaa
            MessageBox.Show("Now we're going to download a tool called git, 
                as most full python scripts are git repositories. Please accept all default options.");

            webClient.DownloadFile("https://github.com/git-for-windows/git/releases/download/v2.20.1.windows.1/Git-2.20.1-64-bit.exe",
                @"c:\temp\gitinst.exe");
                // aaaaaaaaaaaaaaaaaAAAAAAAAAAAAAA

            Process getgit = new Process();
            getgit.StartInfo.UseShellExecute = false;
            getgit.StartInfo.FileName = @"C:\WinPy\gitinst.exe";
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            getgit.Start();

            MessageBox.Show("All done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = urlbox.Text;
            string path = pathbox.Text;
            

/*
    DinGbAt Don't just assume that the boxes will be filled on button pressed make sure that they are actually filled first
    Use a messagebox thing to indicate what do, and if boxes not filled don't do
*/
            if(url != "" && path != ""){
                Process git = new Process();
                ProcessStartInfo gitinfo = new ProcessStartInfo();
                gitinfo.FileName = "git.exe";
                gitinfo.Arguments = "clone " + url + @" C:\WinPy\" + path;
                //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                git.StartInfo = gitinfo;
                git.Start();

                Process.Start(@"C:\WinPY\");

                MessageBox.Show("Now click the next button, 
                    unless the project page says that the requirements are in a different file.");
                thiccboi.GlobalVar = path;
            }else{
                MessageBox.Show("Enter the bois before do", "Ya done hecked up LOL", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(thiccboi.GlobalVar != ""){
                string final = @"C:\WinPY\" + thiccboi.GlobalVar + @"\" + textBox1.Text;
                //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                Console.WriteLine(final);
            
                Directory.SetCurrentDirectory(@"C:\WinPY\" + thiccboi.GlobalVar + @"\");
                //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                Process pip = new Process();
                ProcessStartInfo pipinfo = new ProcessStartInfo();
                pipinfo.FileName = "python";
                pipinfo.Arguments = "-m pip install -r " + final;
                pip.StartInfo = pipinfo;
                pip.Start();
            }else{
                MessageBox.Show("do other thing before do", "Ya done hecked up LOL", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
                thiccboi.GlobalVar = overridebox.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string script = mainbox.Text;
            if(thiccboi.GlobalVar != ""){
                Directory.SetCurrentDirectory(@"C:\WinPY\" + thiccboi.GlobalVar + @"\");
                //aaa
                Process python = new Process();
                ProcessStartInfo pyinfo = new ProcessStartInfo();
                pyinfo.FileName = "python";
                pyinfo.Arguments = script;
                python.StartInfo = pyinfo;
                python.Start();
            }
            else{
                MessageBox.Show("do other thing before do", "Ya done hecked up LOL", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
