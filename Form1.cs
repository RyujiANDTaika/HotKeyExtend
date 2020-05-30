using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotkeyExtend
{
    public partial class MainWindow : Form
    {
        ServiceCtrl serviceCtrl = new ServiceCtrl();

        public MainWindow()
        {
            InitializeComponent();
            if(serviceCtrl.settings.screenBlockStatus == null)
            {
                serviceCtrl.initialSettings();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            screenBlock_Click(topLeft, null);
        }

        private void Form1_FormCLosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private Button lastClickedButton;

        private void screenBlock_Click(object sender, EventArgs e)
        {
            Button thisClickedButton = sender as Button;
            thisClickedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            selectedText.Text = thisClickedButton.Tag.ToString();
            if(lastClickedButton != null)
                lastClickedButton.BackColor = System.Drawing.Color.White;
            lastClickedButton = thisClickedButton;

            usage_checkBox.Checked = serviceCtrl.settings.screenBlockStatus[thisClickedButton.TabIndex, 0] == 1;
            wheel_combobox.SelectedIndex = serviceCtrl.settings.screenBlockStatus[thisClickedButton.TabIndex, 1];
            wheelDown_combobox.SelectedIndex = serviceCtrl.settings.screenBlockStatus[thisClickedButton.TabIndex, 2];
            stay_combobox.SelectedIndex = serviceCtrl.settings.screenBlockStatus[thisClickedButton.TabIndex, 3];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    this.Activate();
                    return;
                }
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    return;
                }
            }
        }

        private void showForm(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Activate();
            }
            else
            {
                this.Activate();
            }
        }

        private void changeUsingStatus(object sender, EventArgs e)
        {

        }

        private void exit(object sender, EventArgs e)
        {
            HotkeyExtendIcon.Dispose();
            this.Dispose();
            this.Close();
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            if(switchButton.Text == "运行中")
            {
                switchButton.Text = "已关闭";
                switchButton.ForeColor = System.Drawing.Color.OrangeRed;
                serviceCtrl.settings.switchStatus = false;
                //serviceCtrl.stopService();
            }
            else
            {
                switchButton.Text = "运行中";
                switchButton.ForeColor = System.Drawing.Color.ForestGreen;
                serviceCtrl.settings.switchStatus = true;
                //serviceCtrl.startService();
            }
        }

        private void usage_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            serviceCtrl.settings.screenBlockStatus[lastClickedButton.TabIndex, 0] = 
                usage_checkBox.Checked ? 1 : 0;
        }
    }
}
