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
        private static SettingsAdapter settingsAdapter;
        private static Service service = new Service();

        public MainWindow()
        {
            InitializeComponent();
            settingsAdapter = new SettingsAdapter(service);
            if (settingsAdapter.settings.screenBlockStatus == null)
            {
                settingsAdapter.initialSettings();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initialText();
            if (settingsAdapter.settings.switchStatus)
                switchButton_Click(switchButton,null);
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

            usage_checkBox.Checked = settingsAdapter.settings.screenBlockStatus[thisClickedButton.TabIndex*4] == 1;
            if (usage_checkBox.Checked)
                lastClickedButton.ForeColor = System.Drawing.Color.Black;
            else
                lastClickedButton.ForeColor = System.Drawing.Color.Gray;
            wheel_combobox.SelectedIndex = settingsAdapter.settings.screenBlockStatus[thisClickedButton.TabIndex*4+1];
            wheelDown_combobox.SelectedIndex = settingsAdapter.settings.screenBlockStatus[thisClickedButton.TabIndex*4+2];
            stay_combobox.SelectedIndex = settingsAdapter.settings.screenBlockStatus[thisClickedButton.TabIndex*4+3];
            textChange();
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
            if(e.Button == MouseButtons.Right)
            {
                if (service.serviceStatus)
                {
                    switch_ToolStripMenuItem.Text = "停用";
                }
                else
                {
                    switch_ToolStripMenuItem.Text = "启用";
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
            switchButton_Click(switchButton,null);
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
                settingsAdapter.settings.switchStatus = false;
                service.stop();
            }
            else
            {
                switchButton.Text = "运行中";
                switchButton.ForeColor = System.Drawing.Color.ForestGreen;
                settingsAdapter.settings.switchStatus = true;
                service.start();
            }
        }

        private void usage_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int[] tempArray = settingsAdapter.settings.screenBlockStatus;
            if((usage_checkBox.Checked ? 1 : 0) != tempArray[lastClickedButton.TabIndex * 4])
            {
                tempArray[lastClickedButton.TabIndex * 4] =
                usage_checkBox.Checked ? 1 : 0;
                settingsAdapter.settings.screenBlockStatus = tempArray;
            }
            if (usage_checkBox.Checked)
            {
                lastClickedButton.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lastClickedButton.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void wheel_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] tempArray = settingsAdapter.settings.screenBlockStatus;
            if(wheel_combobox.SelectedIndex != tempArray[lastClickedButton.TabIndex * 4 + 1])
            {
                tempArray[lastClickedButton.TabIndex * 4 + 1] = wheel_combobox.SelectedIndex;
                settingsAdapter.settings.screenBlockStatus = tempArray;
            }
            textChange();
        }

        private void wheelDown_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] tempArray = settingsAdapter.settings.screenBlockStatus;
            if(wheelDown_combobox.SelectedIndex != tempArray[lastClickedButton.TabIndex * 4 + 2])
            {
                tempArray[lastClickedButton.TabIndex * 4 + 2] = wheelDown_combobox.SelectedIndex;
                settingsAdapter.settings.screenBlockStatus = tempArray;
            }
            textChange();
        }

        private void stay_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] tempArray = settingsAdapter.settings.screenBlockStatus;
            if(stay_combobox.SelectedIndex != tempArray[lastClickedButton.TabIndex * 4 + 3])
            {
                tempArray[lastClickedButton.TabIndex * 4 + 3] = stay_combobox.SelectedIndex;
                settingsAdapter.settings.screenBlockStatus = tempArray;
            }
            textChange();
        }

        private void textChange()
        {
            string text = "";
            if (wheel_combobox.SelectedIndex != 0)
            {
                text += "滚轮：" + wheel_combobox.Text + "\n";
            }
            if (wheelDown_combobox.SelectedIndex != 0)
            {
                text += "按下滚轮：" + wheelDown_combobox.Text + "\n";
            }
            if (stay_combobox.SelectedIndex != 0)
            {
                text += "不动：" + stay_combobox.Text + "\n";
            }
            lastClickedButton.Text = text;
        }

        private void initialText()
        {
            screenBlock_Click(topMiddle, null);
            screenBlock_Click(topRight, null);
            screenBlock_Click(middleLeft, null);
            screenBlock_Click(middleRight, null);
            screenBlock_Click(bottomLeft, null);
            screenBlock_Click(bottomMiddle, null);
            screenBlock_Click(bottomRight, null);
            screenBlock_Click(topLeft, null);
        }
    }
}
