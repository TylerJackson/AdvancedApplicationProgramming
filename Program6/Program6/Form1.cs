/* Name: Program 6
 * Author: Tyler Jackson
 * Date: 10/13/14
 * Description: This program creates a simple task manager.  I use system.diagnostics
 *              to get a list of all the current processes and then allow the user to
 *              kill a process, and refresh the current list.  For the selected
 *              process I display the process ID, name, and the window title if there
 *              is one.  
 *
 * Note:        I had the GetProcesses function run async.  Although it was always
 *              fast, but it was still good practice.  This app also includes a
 *              message-box confirmation before killing a process.
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Program6
{
    public partial class Form1 : Form
    {
        public List<Process> processes { get; set; }
        public Form1()
        {
            InitializeComponent();
            
        }
        //when refresh is clicked either in toolbar or file menu refresh the
        //processes lists async and wait to update the ui till this is done
        private async void RefreshClicked(object sender, EventArgs e)
        {
            await Task.Run(() => RefreshProcesses());
            UpdateProcessesListBox();
            LastRefreshLabel.Text = String.Format("Last Refreshed At: {0}", DateTime.Now);
        }

        private void SelectedProcessChanged(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }

        //refresh the processes list
        //notice the LINQ with lambda
        private void RefreshProcesses()
        {
            var unorderedProcesses = Process.GetProcesses().ToList();
            processes = unorderedProcesses.OrderBy(p => p.ProcessName).ToList();
        }
        //reload the processes list box
        private void UpdateProcessesListBox()
        {
            ProcessListBox.DataSource = null;
            ProcessListBox.DataSource = processes;
            ProcessListBox.DisplayMember = "ProcessName";
        }
        //reload the text boxes holding the selected process info
        private void UpdateTextBoxes()
        {
            var selectedProcess = ProcessListBox.SelectedItem as Process;
            if (selectedProcess == null)
                return;
            IdTextBox.Text = selectedProcess.Id.ToString();
            NameTextBox.Text = selectedProcess.ProcessName;
            WindowTitleTextBox.Text = selectedProcess.MainWindowTitle;
            if (WindowTitleTextBox.Text == "")
                WindowTitleTextBox.Text = "--No title--";
        }

        //display confirmation block if kill process tool bar button or file menu
        //items are clicked
        private void KillClicked(object sender, EventArgs e)
        {
            var selectedProcess = ProcessListBox.SelectedItem as Process;
            if (selectedProcess == null)
                return;
            
            DialogResult dr = MessageBox.Show(String.Format("Are you sure you want to kill {0}", selectedProcess.ProcessName),"Kill Process?",MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;
            selectedProcess.Kill();
            processes.Remove(selectedProcess);
            UpdateProcessesListBox();
        }

        private void ExitClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        //async call to refresh the list of processes
        //waits to update ui for first time till after this is done
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(()=>RefreshProcesses());
            UpdateProcessesListBox();
            UpdateTextBoxes();
            LastRefreshLabel.Text = String.Format("Last Refreshed At: {0}", DateTime.Now);
        }
    }
}
