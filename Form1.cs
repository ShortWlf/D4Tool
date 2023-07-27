using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // set this.FormBorderStyle to None here if needed
            // if set to none, make sure you have a way to close the form!
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.CenterToScreen();

            if (D4Tool.Properties.Settings.Default.F1Size.Width == 0 || D4Tool.Properties.Settings.Default.F1Size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                this.WindowState = D4Tool.Properties.Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = D4Tool.Properties.Settings.Default.F1Location;
                this.Size = D4Tool.Properties.Settings.Default.F1Size;
            }
        }

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr

        private static void FocusProcess()
        {
            IntPtr hWnd; //change this to IntPtr
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName == "Diablo IV")
                {
                    hWnd = pr.MainWindowHandle; //use it as IntPtr not int
                    ShowWindow(hWnd, 3);
                    SetForegroundWindow(hWnd); //set to topmost
                }
            }
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            //           BrowserForm BrowserForm = new BrowserForm();
            //           BrowserForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowserForm BrowserForm = new BrowserForm();
            BrowserForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
//            FocusProcess();
//            SendKeys.Send("{ENTER}");
//            SendKeys.Send("/");
//            SendKeys.Send("h");
//            SendKeys.Send("i");
//            SendKeys.Send("d");
//            SendKeys.Send("e");
//            SendKeys.Send("o");
//            SendKeys.Send("u");
//            SendKeys.Send("t");
//            SendKeys.Send("{ENTER}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrowserForm BrowserForm = new BrowserForm();
            BrowserForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
//            FocusProcess();
//            SendKeys.Send("{ENTER}");
//            SendKeys.Send("/");
//            SendKeys.Send("d");
//            SendKeys.Send("n");
//            SendKeys.Send("d");
//            SendKeys.Send("{ENTER}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
//            FocusProcess();
//            SendKeys.Send("{ENTER}");
//            SendKeys.Send("/");
//            SendKeys.Send("a");
//            SendKeys.Send("f");
//            SendKeys.Send("k");
//            SendKeys.Send("{ENTER}");
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.TopMost = true;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            D4Tool.Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                D4Tool.Properties.Settings.Default.F1Location = this.Location;
                D4Tool.Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                D4Tool.Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                D4Tool.Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            D4Tool.Properties.Settings.Default.Save();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.TopMost = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
