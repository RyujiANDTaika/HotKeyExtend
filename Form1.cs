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
        private static Service service = new Service();
        private static SettingsAdapter settingsAdapter = new SettingsAdapter(service);

        public MainWindow()
        {
            InitializeComponent();
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

            if(settingsAdapter.settings.searchTextStatus == null)
            {
                List<string> tempText = new List<string>() {
                    "Google","G","D1","https://google.com/search?q=%s",
                    "百度","B","D1","https://www.baidu.com/s?wd=%s",
                    "微博","W","D2","https://google.com/search?q=%s",
                    "知乎","Z","D2","http://www.zhihu.com/search?q=%s",
                    "Bilibili","L","D3","http://www.bilibili.com/search?keyword=%s",
                    "Youtube","Y","D3","https://www.youtube.com/results?search_query=%s",
                    "豆瓣电影","D","","http://movie.douban.com/subject_search?search_text=%s",
                    "QR-Code","Q","","http://api.qrserver.com/v1/create-qr-code/?data=%s",
                    "打开B站视频(av号)","Alt_L","","https://www.bilibili.com/video/%s/",
                };
                List<bool> tempStatus = new List<bool>() {
                    true,true,false,false,false,false,false,false,false
                };

                settingsAdapter.settings.searchText = tempText;
                settingsAdapter.settings.searchTextStatus = tempStatus;
            }

            List<string> searchText = settingsAdapter.settings.searchText;
            foreach (bool b in settingsAdapter.settings.searchTextStatus)
            {
                int index = searchText_DataGridView.Rows.Add();
                searchText_DataGridView.Rows[index].Cells[0].Value = b;
                searchText_DataGridView.Rows[index].Cells[1].Value = searchText[index * 4];
                searchText_DataGridView.Rows[index].Cells[2].Value = searchText[index * 4 + 1];
                searchText_DataGridView.Rows[index].Cells[3].Value = searchText[index * 4 + 2];
                searchText_DataGridView.Rows[index].Cells[4].Value = searchText[index * 4 + 3];
            }

            if (settingsAdapter.settings.replaceTextStatus == null)
            {
                List<string> tempText = new List<string>() {
                    "..g","your-email-address@gmail.com",
                    "input_some","Auto replace to string, 输出可以是中文",
                    "输入不能是中文","Input CANNOT be chars outside english keyboard, like Chinese.",
                    "输入长度限制","输入字串长度不要超过10个字符。（Input Length Limit: 10 chars.）",
                };
                List<bool> tempStatus = new List<bool>() {
                    true,false,false,false,
                };

                settingsAdapter.settings.replaceText = tempText;
                settingsAdapter.settings.replaceTextStatus = tempStatus;
            }

            List<string> replaceText = settingsAdapter.settings.replaceText;
            foreach (bool b in settingsAdapter.settings.replaceTextStatus)
            {
                int index = replaceText_DataGridView.Rows.Add();
                replaceText_DataGridView.Rows[index].Cells[0].Value = b;
                replaceText_DataGridView.Rows[index].Cells[1].Value = replaceText[index * 2];
                replaceText_DataGridView.Rows[index].Cells[2].Value = replaceText[index * 2 + 1];
            }

            searchText_DataGridView.CellValueChanged += this.searchText_DataGridView_CellValueChanged;
            replaceText_DataGridView.CellValueChanged += this.replaceText_DataGridView_CellValueChanged;
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mainTabControl.SelectedIndex == 0)
                addEdit_Button.Enabled = deleteEdit_Button.Enabled = false;
            else
                addEdit_Button.Enabled = deleteEdit_Button.Enabled = true;
        }

        private void addEdit_Button_Click(object sender, EventArgs e)
        {
            if(mainTabControl.SelectedIndex == 1)
            {
                int index = searchText_DataGridView.Rows.Add();
                searchText_DataGridView.Rows[index].Cells[0].Value = true;
                searchText_DataGridView.Rows[index].Cells[1].Value = "<new>";
                searchText_DataGridView.Rows[index].Cells[2].Value = "";
                searchText_DataGridView.Rows[index].Cells[3].Value = "";
                searchText_DataGridView.Rows[index].Cells[4].Value = "%s";
                searchText_DataGridView.Rows[index].Selected = true;

                List<bool> tempStatus = settingsAdapter.settings.searchTextStatus;
                tempStatus.Add(true);
                settingsAdapter.settings.searchTextStatus = tempStatus;
                List<string> tempText = settingsAdapter.settings.searchText;
                tempText.Add("<new>");
                tempText.Add("");
                tempText.Add("");
                tempText.Add("%s");
                settingsAdapter.settings.searchText = tempText;
            }
            if(mainTabControl.SelectedIndex == 2)
            {
                int index = replaceText_DataGridView.Rows.Add();
                replaceText_DataGridView.Rows[index].Cells[0].Value = true;
                replaceText_DataGridView.Rows[index].Cells[1].Value = "input";
                replaceText_DataGridView.Rows[index].Cells[2].Value = "output";
                replaceText_DataGridView.Rows[index].Selected = true;

                List<bool> tempStatus = settingsAdapter.settings.replaceTextStatus;
                tempStatus.Add(true);
                settingsAdapter.settings.replaceTextStatus = tempStatus;
                List<string> tempText = settingsAdapter.settings.replaceText;
                tempText.Add("input");
                tempText.Add("output");
                settingsAdapter.settings.replaceText = tempText;
            }
        }

        private void deleteEdit_Button_Click(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 1)
            {
                if(searchText_DataGridView.SelectedRows.Count != 0)
                {
                    int index = searchText_DataGridView.SelectedRows[0].Index;
                    if (index > 0)
                    {
                        searchText_DataGridView.Rows.RemoveAt(index);
                        if (index > 0)
                            searchText_DataGridView.Rows[index - 1].Selected = true;

                        List<bool> tempStatus = settingsAdapter.settings.searchTextStatus;
                        tempStatus.RemoveAt(index);
                        settingsAdapter.settings.searchTextStatus = tempStatus;
                        List<string> tempText = settingsAdapter.settings.searchText;
                        tempText.RemoveAt(index * 4);
                        tempText.RemoveAt(index * 4);
                        tempText.RemoveAt(index * 4);
                        tempText.RemoveAt(index * 4);
                        settingsAdapter.settings.searchText = tempText;
                    }
                }
            }
            if (mainTabControl.SelectedIndex == 2)
            {
                if(replaceText_DataGridView.SelectedRows.Count != 0)
                {
                    int index = replaceText_DataGridView.SelectedRows[0].Index;
                    if (index >= 0)
                    {
                        replaceText_DataGridView.Rows.RemoveAt(index);
                        if (index > 0)
                            replaceText_DataGridView.Rows[index - 1].Selected = true;

                        List<bool> tempStatus = settingsAdapter.settings.replaceTextStatus;
                        tempStatus.RemoveAt(index);
                        settingsAdapter.settings.replaceTextStatus = tempStatus;
                        List<string> tempText = settingsAdapter.settings.replaceText;
                        tempText.RemoveAt(index * 2);
                        tempText.RemoveAt(index * 2);
                        settingsAdapter.settings.replaceText = tempText;
                    }
                }
            }

        }

        private void searchText_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                editNameTextBox.Enabled = editHotkeyButton.Enabled = editGroupButton.Enabled = editURLTextBox.Enabled = true;
                editNameTextBox.Text = searchText_DataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                editHotkeyButton.Text = searchText_DataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                editGroupButton.Text = searchText_DataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                editURLTextBox.Text = searchText_DataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            else
            {
                editNameTextBox.Text = editHotkeyButton.Text = editGroupButton.Text = editURLTextBox.Text = null;
                editNameTextBox.Enabled = editHotkeyButton.Enabled = editGroupButton.Enabled = editURLTextBox.Enabled = false;
            }
        }

        private void editNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = searchText_DataGridView.SelectedRows[0].Index;
            searchText_DataGridView.Rows[index].Cells[1].Value = editNameTextBox.Text;
            List<string> tempText = settingsAdapter.settings.searchText;
            tempText[index * 4] = editNameTextBox.Text;
            settingsAdapter.settings.searchText = tempText;
        }

        private void editURLTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = searchText_DataGridView.SelectedRows[0].Index;
            searchText_DataGridView.Rows[index].Cells[4].Value = editURLTextBox.Text;
            List<string> tempText = settingsAdapter.settings.searchText;
            tempText[index * 4 + 3] = editURLTextBox.Text;
            settingsAdapter.settings.searchText = tempText;

        }

        private List<Keys> hotkeyList = new List<Keys>();

        private void editHotkeyButton_KeyDown(object sender, KeyEventArgs e)
        {
            int index = searchText_DataGridView.SelectedRows[0].Index;

            if (!hotkeyList.Contains(e.KeyCode) && hotkeyList.Count < 3)
            {
                hotkeyList.Add(e.KeyCode);
            }

            string text = "";
            foreach (Keys key in hotkeyList)
            {
                text += key.ToString();
                text += "_";
            }
            editHotkeyButton.Text = text.Remove(text.Length - 1).Replace("ControlKey", "Ctrl").Replace("Menu", "Alt").Replace("ShiftKey", "Shift").Replace("LWin", "Win");

            Keys last = hotkeyList.Last();
            if (last != Keys.ControlKey && last != Keys.Menu && last != Keys.ShiftKey && last != Keys.LWin)
            {
                List<string> tempText = settingsAdapter.settings.searchText;
                tempText[index * 4 + 1] = editHotkeyButton.Text;
                settingsAdapter.settings.searchText = tempText;
                searchText_DataGridView.Rows[index].Cells[2].Value = editHotkeyButton.Text;
                editHotkeyButton_Click(sender, null);
                hotkeyList = new List<Keys>();
            }
            
        }

        private bool editHotkeyButtonStatus = false;

        private void editHotkeyButton_Click(object sender, EventArgs e)
        {
            if (editHotkeyButtonStatus)
            {
                editHotkeyButtonStatus = false;
                editHotkeyButton.KeyDown -= editHotkeyButton_KeyDown;
                editHotkeyButton.KeyUp -= editHotkeyButton_KeyUp;
                editHotkeyButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                editHotkeyButtonStatus = true;
                editHotkeyButton.KeyDown += editHotkeyButton_KeyDown;
                editHotkeyButton.KeyUp += editHotkeyButton_KeyUp;
                editHotkeyButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }

        private void editHotkeyButton_KeyUp(object sender, KeyEventArgs e)
        {
            int index = searchText_DataGridView.SelectedRows[0].Index;

            if (hotkeyList.Contains(e.KeyCode))
                hotkeyList.Remove(e.KeyCode);
                string text = "";
                foreach (Keys key in hotkeyList)
                {
                    text += key.ToString();
                    text += "_";
                }
            if (hotkeyList.Count > 0)
                text.Remove(text.Length - 1);
            else
                text = searchText_DataGridView.Rows[index].Cells[2].Value.ToString();
            editHotkeyButton.Text = text.Replace("ControlKey", "Ctrl").Replace("Menu", "Alt").Replace("ShiftKey", "Shift").Replace("LWin", "Win");
        }

        private void editHotkeyButton_Leave(object sender, EventArgs e)
        {
            editHotkeyButtonStatus = false;
            editHotkeyButton.KeyDown -= editHotkeyButton_KeyDown;
            editHotkeyButton.KeyUp -= editHotkeyButton_KeyUp;
            editHotkeyButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            int index = searchText_DataGridView.SelectedRows[0].Index;
            editHotkeyButton.Text = searchText_DataGridView.Rows[index].Cells[2].Value.ToString();
        }

        private List<int> groupList = new List<int>();
        private bool editGroupButtonStaus = false;

        private void editGroupButton_KeyDown(object sender, KeyEventArgs e)
        {
            int index = searchText_DataGridView.SelectedRows[0].Index;

            if (!groupList.Contains(e.KeyValue) && groupList.Count < 1)
            {
                groupList.Add(e.KeyValue);
            }

            editGroupButton.Text = ((Keys)groupList[0]).ToString();

            if (e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                List<string> tempText = settingsAdapter.settings.searchText;
                tempText[index * 4 + 2] = editGroupButton.Text;
                settingsAdapter.settings.searchText = tempText;
                searchText_DataGridView.Rows[index].Cells[3].Value = editGroupButton.Text;
                editGroupButton_Click(sender, null);
                groupList = new List<int>();
            }
        }
        private void editGroupButton_KeyUp(object sender, KeyEventArgs e)
        {
            int index = searchText_DataGridView.SelectedRows[0].Index;
            if (groupList.Contains(e.KeyValue))
                groupList.Remove(e.KeyValue);
            if (groupList.Count == 0)
                editGroupButton.Text = searchText_DataGridView.Rows[index].Cells[3].Value.ToString();
        }

        private void editGroupButton_Click(object sender, EventArgs e)
        {
            if (editGroupButtonStaus)
            {
                editGroupButtonStaus = false;
                editGroupButton.KeyDown -= editGroupButton_KeyDown;
                editGroupButton.KeyUp -= editGroupButton_KeyUp;
                editGroupButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                editGroupButtonStaus = true;
                editGroupButton.KeyDown += editGroupButton_KeyDown;
                editGroupButton.KeyUp += editGroupButton_KeyUp;
                editGroupButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }

        private void editGroupButton_Leave(object sender, EventArgs e)
        {
            editGroupButtonStaus = false;
            editGroupButton.KeyDown -= editGroupButton_KeyDown;
            editGroupButton.KeyUp -= editGroupButton_KeyUp;
            editGroupButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            int index = searchText_DataGridView.SelectedRows[0].Index;
            editGroupButton.Text = searchText_DataGridView.Rows[index].Cells[3].Value.ToString();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.Handled = true;
        }

        private void replaceText_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                editInputTextBox.Enabled = editOutputTextBox.Enabled = true;
                editInputTextBox.Text = replaceText_DataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                editOutputTextBox.Text = replaceText_DataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else
            {
                editInputTextBox.Text = editOutputTextBox.Text = null;
                editInputTextBox.Enabled = editOutputTextBox.Enabled = false;
            }
        }

        private void editInputTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = replaceText_DataGridView.SelectedRows[0].Index;
            replaceText_DataGridView.Rows[index].Cells[1].Value = editInputTextBox.Text;
            List<string> tempText = settingsAdapter.settings.replaceText;
            tempText[index * 2] = editInputTextBox.Text;
            settingsAdapter.settings.replaceText = tempText;
        }

        private void editOutputTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = replaceText_DataGridView.SelectedRows[0].Index;
            replaceText_DataGridView.Rows[index].Cells[2].Value = editOutputTextBox.Text;
            List<string> tempText = settingsAdapter.settings.replaceText;
            tempText[index * 2 + 1] = editOutputTextBox.Text;
            settingsAdapter.settings.replaceText = tempText;
        }

        private void searchText_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<bool> tempStatus = settingsAdapter.settings.searchTextStatus;
                tempStatus[e.RowIndex] = Convert.ToBoolean(searchText_DataGridView.Rows[e.RowIndex].Cells[0].EditedFormattedValue);
                settingsAdapter.settings.searchTextStatus = tempStatus;
            }
        }

        private void replaceText_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<bool> tempStatus = settingsAdapter.settings.replaceTextStatus;
                tempStatus[e.RowIndex] = Convert.ToBoolean(replaceText_DataGridView.Rows[e.RowIndex].Cells[0].EditedFormattedValue);
                settingsAdapter.settings.replaceTextStatus = tempStatus;
            }
        }
    }
}
