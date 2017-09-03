using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program created by eLF the nigger");
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search.Enabled = false;
            UrlBox.Enabled = false;
            webBrowser1.Navigate("www.google.com/search?q="+UrlBox.Text);
            strip.Text = "Started";
        }

        private void UrlBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                Search_Click(sender,e);          
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Search.Enabled = true;
            UrlBox.Enabled = true;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress == 0 || (e.MaximumProgress < e.CurrentProgress))
            {
                bar.ProgressBar.Value = 100;
            }
            else
            {
                bar.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
            
           
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UrlBox.Text = Convert.ToString(webBrowser1.Url);
            strip.Text = "Finished";
        }

        private void google_Click(object sender, EventArgs e)
        {
            Search.Enabled = false;
            UrlBox.Enabled = false;
            webBrowser1.Navigate("www.google.com");
            strip.Text = "Started";
        }
    }
}
