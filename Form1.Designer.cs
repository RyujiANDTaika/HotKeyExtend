﻿namespace HotkeyExtend
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.ScreenBorder = new System.Windows.Forms.TabPage();
            this.selectedText = new System.Windows.Forms.Label();
            this.stay_combobox = new System.Windows.Forms.ComboBox();
            this.wheelDown_combobox = new System.Windows.Forms.ComboBox();
            this.wheel_combobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usage_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bottomRight = new System.Windows.Forms.Button();
            this.middleRight = new System.Windows.Forms.Button();
            this.topRight = new System.Windows.Forms.Button();
            this.bottomMiddle = new System.Windows.Forms.Button();
            this.topMiddle = new System.Windows.Forms.Button();
            this.bottomLeft = new System.Windows.Forms.Button();
            this.middleLeft = new System.Windows.Forms.Button();
            this.topLeft = new System.Windows.Forms.Button();
            this.copySearch = new System.Windows.Forms.TabPage();
            this.editGroupButton = new System.Windows.Forms.Button();
            this.editHotkeyButton = new System.Windows.Forms.Button();
            this.editURLTextBox = new System.Windows.Forms.TextBox();
            this.editNameTextBox = new System.Windows.Forms.TextBox();
            this.searchText_DataGridView = new System.Windows.Forms.DataGridView();
            this.usageColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotkeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.phraseReplace = new System.Windows.Forms.TabPage();
            this.editOutputTextBox = new System.Windows.Forms.TextBox();
            this.editInputTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.replaceText_DataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotkeyExtendIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.show_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switch_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchButton = new System.Windows.Forms.Button();
            this.addEdit_Button = new System.Windows.Forms.Button();
            this.deleteEdit_Button = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.ScreenBorder.SuspendLayout();
            this.copySearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchText_DataGridView)).BeginInit();
            this.phraseReplace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.replaceText_DataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.ScreenBorder);
            this.mainTabControl.Controls.Add(this.copySearch);
            this.mainTabControl.Controls.Add(this.phraseReplace);
            this.mainTabControl.Location = new System.Drawing.Point(9, 50);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(966, 402);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // ScreenBorder
            // 
            this.ScreenBorder.Controls.Add(this.selectedText);
            this.ScreenBorder.Controls.Add(this.stay_combobox);
            this.ScreenBorder.Controls.Add(this.wheelDown_combobox);
            this.ScreenBorder.Controls.Add(this.wheel_combobox);
            this.ScreenBorder.Controls.Add(this.label4);
            this.ScreenBorder.Controls.Add(this.label3);
            this.ScreenBorder.Controls.Add(this.label2);
            this.ScreenBorder.Controls.Add(this.usage_checkBox);
            this.ScreenBorder.Controls.Add(this.label1);
            this.ScreenBorder.Controls.Add(this.textBox8);
            this.ScreenBorder.Controls.Add(this.textBox7);
            this.ScreenBorder.Controls.Add(this.textBox6);
            this.ScreenBorder.Controls.Add(this.textBox5);
            this.ScreenBorder.Controls.Add(this.textBox4);
            this.ScreenBorder.Controls.Add(this.textBox3);
            this.ScreenBorder.Controls.Add(this.textBox2);
            this.ScreenBorder.Controls.Add(this.textBox1);
            this.ScreenBorder.Controls.Add(this.bottomRight);
            this.ScreenBorder.Controls.Add(this.middleRight);
            this.ScreenBorder.Controls.Add(this.topRight);
            this.ScreenBorder.Controls.Add(this.bottomMiddle);
            this.ScreenBorder.Controls.Add(this.topMiddle);
            this.ScreenBorder.Controls.Add(this.bottomLeft);
            this.ScreenBorder.Controls.Add(this.middleLeft);
            this.ScreenBorder.Controls.Add(this.topLeft);
            this.ScreenBorder.Font = new System.Drawing.Font("宋体", 12F);
            this.ScreenBorder.Location = new System.Drawing.Point(4, 22);
            this.ScreenBorder.Margin = new System.Windows.Forms.Padding(0);
            this.ScreenBorder.Name = "ScreenBorder";
            this.ScreenBorder.Size = new System.Drawing.Size(958, 376);
            this.ScreenBorder.TabIndex = 0;
            this.ScreenBorder.Text = "屏幕边缘";
            this.ScreenBorder.UseVisualStyleBackColor = true;
            // 
            // selectedText
            // 
            this.selectedText.AutoSize = true;
            this.selectedText.Font = new System.Drawing.Font("宋体", 20F);
            this.selectedText.Location = new System.Drawing.Point(729, 34);
            this.selectedText.Name = "selectedText";
            this.selectedText.Size = new System.Drawing.Size(0, 27);
            this.selectedText.TabIndex = 25;
            // 
            // stay_combobox
            // 
            this.stay_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stay_combobox.FormattingEnabled = true;
            this.stay_combobox.Items.AddRange(new object[] {
            "无",
            "音量加",
            "音量减",
            "静音",
            "多媒体：上一首",
            "多媒体：下一首",
            "播放/暂停",
            "窗口：不透明度增",
            "窗口：不透明度减",
            "窗口：切换置顶",
            "屏幕：关",
            "电源：休眠",
            "电源：睡眠"});
            this.stay_combobox.Location = new System.Drawing.Point(675, 233);
            this.stay_combobox.Name = "stay_combobox";
            this.stay_combobox.Size = new System.Drawing.Size(255, 24);
            this.stay_combobox.TabIndex = 24;
            this.stay_combobox.SelectedIndexChanged += new System.EventHandler(this.stay_combobox_SelectedIndexChanged);
            // 
            // wheelDown_combobox
            // 
            this.wheelDown_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wheelDown_combobox.FormattingEnabled = true;
            this.wheelDown_combobox.Items.AddRange(new object[] {
            "无",
            "音量加",
            "音量减",
            "静音",
            "多媒体：上一首",
            "多媒体：下一首",
            "播放/暂停",
            "窗口：不透明度增",
            "窗口：不透明度减",
            "窗口：切换置顶",
            "屏幕：关",
            "电源：休眠",
            "电源：睡眠"});
            this.wheelDown_combobox.Location = new System.Drawing.Point(675, 179);
            this.wheelDown_combobox.Name = "wheelDown_combobox";
            this.wheelDown_combobox.Size = new System.Drawing.Size(255, 24);
            this.wheelDown_combobox.TabIndex = 23;
            this.wheelDown_combobox.SelectedIndexChanged += new System.EventHandler(this.wheelDown_combobox_SelectedIndexChanged);
            // 
            // wheel_combobox
            // 
            this.wheel_combobox.BackColor = System.Drawing.SystemColors.Window;
            this.wheel_combobox.Cursor = System.Windows.Forms.Cursors.Default;
            this.wheel_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wheel_combobox.FormattingEnabled = true;
            this.wheel_combobox.Items.AddRange(new object[] {
            "无",
            "音量",
            "多媒体",
            "标签页",
            "应用",
            "虚拟桌面",
            "翻页",
            "页头/页尾"});
            this.wheel_combobox.Location = new System.Drawing.Point(675, 126);
            this.wheel_combobox.Name = "wheel_combobox";
            this.wheel_combobox.Size = new System.Drawing.Size(255, 24);
            this.wheel_combobox.TabIndex = 22;
            this.wheel_combobox.SelectedIndexChanged += new System.EventHandler(this.wheel_combobox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "不动";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "按下滚轮";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(589, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "滚轮";
            // 
            // usage_checkBox
            // 
            this.usage_checkBox.AutoSize = true;
            this.usage_checkBox.Location = new System.Drawing.Point(592, 73);
            this.usage_checkBox.Name = "usage_checkBox";
            this.usage_checkBox.Size = new System.Drawing.Size(59, 20);
            this.usage_checkBox.TabIndex = 18;
            this.usage_checkBox.Text = "启用";
            this.usage_checkBox.UseVisualStyleBackColor = true;
            this.usage_checkBox.CheckedChanged += new System.EventHandler(this.usage_checkBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(587, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 17;
            this.label1.Text = "屏幕边缘：";
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox8.Location = new System.Drawing.Point(350, 176);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(24, 22);
            this.textBox8.TabIndex = 16;
            this.textBox8.Text = "→";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox7.Location = new System.Drawing.Point(194, 176);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 22);
            this.textBox7.TabIndex = 15;
            this.textBox7.Text = "←";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox6.Location = new System.Drawing.Point(272, 226);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(24, 22);
            this.textBox6.TabIndex = 14;
            this.textBox6.Text = "↓";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.Location = new System.Drawing.Point(272, 128);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(24, 22);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "↑";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(350, 226);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(24, 22);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = "↘";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(350, 128);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(24, 22);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "↗";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(194, 226);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(24, 22);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "↙";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(194, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(24, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "↖";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bottomRight
            // 
            this.bottomRight.BackColor = System.Drawing.Color.White;
            this.bottomRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bottomRight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bottomRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomRight.Font = new System.Drawing.Font("宋体", 12F);
            this.bottomRight.Location = new System.Drawing.Point(380, 250);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(180, 120);
            this.bottomRight.TabIndex = 7;
            this.bottomRight.Tag = "右下角";
            this.bottomRight.UseVisualStyleBackColor = true;
            this.bottomRight.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // middleRight
            // 
            this.middleRight.BackColor = System.Drawing.Color.White;
            this.middleRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.middleRight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.middleRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.middleRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.middleRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.middleRight.Font = new System.Drawing.Font("宋体", 12F);
            this.middleRight.Location = new System.Drawing.Point(380, 128);
            this.middleRight.Name = "middleRight";
            this.middleRight.Size = new System.Drawing.Size(180, 120);
            this.middleRight.TabIndex = 4;
            this.middleRight.Tag = "右边缘";
            this.middleRight.UseVisualStyleBackColor = true;
            this.middleRight.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // topRight
            // 
            this.topRight.BackColor = System.Drawing.Color.White;
            this.topRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topRight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.topRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topRight.Font = new System.Drawing.Font("宋体", 12F);
            this.topRight.Location = new System.Drawing.Point(380, 2);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(180, 120);
            this.topRight.TabIndex = 2;
            this.topRight.Tag = "右上角";
            this.topRight.UseVisualStyleBackColor = true;
            this.topRight.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // bottomMiddle
            // 
            this.bottomMiddle.BackColor = System.Drawing.Color.White;
            this.bottomMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bottomMiddle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bottomMiddle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomMiddle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomMiddle.Font = new System.Drawing.Font("宋体", 12F);
            this.bottomMiddle.Location = new System.Drawing.Point(194, 250);
            this.bottomMiddle.Name = "bottomMiddle";
            this.bottomMiddle.Size = new System.Drawing.Size(180, 120);
            this.bottomMiddle.TabIndex = 6;
            this.bottomMiddle.Tag = "下边缘";
            this.bottomMiddle.UseVisualStyleBackColor = true;
            this.bottomMiddle.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // topMiddle
            // 
            this.topMiddle.BackColor = System.Drawing.Color.White;
            this.topMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topMiddle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.topMiddle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topMiddle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topMiddle.Font = new System.Drawing.Font("宋体", 12F);
            this.topMiddle.Location = new System.Drawing.Point(194, 2);
            this.topMiddle.Name = "topMiddle";
            this.topMiddle.Size = new System.Drawing.Size(180, 120);
            this.topMiddle.TabIndex = 1;
            this.topMiddle.Tag = "上边缘";
            this.topMiddle.UseVisualStyleBackColor = true;
            this.topMiddle.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // bottomLeft
            // 
            this.bottomLeft.BackColor = System.Drawing.Color.White;
            this.bottomLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bottomLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bottomLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomLeft.Font = new System.Drawing.Font("宋体", 12F);
            this.bottomLeft.Location = new System.Drawing.Point(8, 250);
            this.bottomLeft.Name = "bottomLeft";
            this.bottomLeft.Size = new System.Drawing.Size(180, 120);
            this.bottomLeft.TabIndex = 5;
            this.bottomLeft.Tag = "左下角";
            this.bottomLeft.UseVisualStyleBackColor = true;
            this.bottomLeft.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // middleLeft
            // 
            this.middleLeft.BackColor = System.Drawing.Color.White;
            this.middleLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.middleLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.middleLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.middleLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.middleLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.middleLeft.Font = new System.Drawing.Font("宋体", 12F);
            this.middleLeft.Location = new System.Drawing.Point(8, 126);
            this.middleLeft.Name = "middleLeft";
            this.middleLeft.Size = new System.Drawing.Size(180, 120);
            this.middleLeft.TabIndex = 3;
            this.middleLeft.Tag = "左边缘";
            this.middleLeft.UseVisualStyleBackColor = true;
            this.middleLeft.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // topLeft
            // 
            this.topLeft.BackColor = System.Drawing.Color.White;
            this.topLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.topLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topLeft.Font = new System.Drawing.Font("宋体", 12F);
            this.topLeft.Location = new System.Drawing.Point(8, 2);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(180, 120);
            this.topLeft.TabIndex = 0;
            this.topLeft.Tag = "左上角";
            this.topLeft.UseVisualStyleBackColor = true;
            this.topLeft.Click += new System.EventHandler(this.screenBlock_Click);
            // 
            // copySearch
            // 
            this.copySearch.Controls.Add(this.editGroupButton);
            this.copySearch.Controls.Add(this.editHotkeyButton);
            this.copySearch.Controls.Add(this.editURLTextBox);
            this.copySearch.Controls.Add(this.editNameTextBox);
            this.copySearch.Controls.Add(this.searchText_DataGridView);
            this.copySearch.Controls.Add(this.label5);
            this.copySearch.Location = new System.Drawing.Point(4, 22);
            this.copySearch.Name = "copySearch";
            this.copySearch.Padding = new System.Windows.Forms.Padding(3);
            this.copySearch.Size = new System.Drawing.Size(958, 376);
            this.copySearch.TabIndex = 1;
            this.copySearch.Text = "复制搜索";
            this.copySearch.UseVisualStyleBackColor = true;
            // 
            // editGroupButton
            // 
            this.editGroupButton.BackColor = System.Drawing.Color.Transparent;
            this.editGroupButton.Enabled = false;
            this.editGroupButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editGroupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.editGroupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editGroupButton.Font = new System.Drawing.Font("宋体", 14F);
            this.editGroupButton.ForeColor = System.Drawing.Color.Black;
            this.editGroupButton.Location = new System.Drawing.Point(458, 306);
            this.editGroupButton.Name = "editGroupButton";
            this.editGroupButton.Size = new System.Drawing.Size(218, 26);
            this.editGroupButton.TabIndex = 6;
            this.editGroupButton.UseVisualStyleBackColor = false;
            this.editGroupButton.Click += new System.EventHandler(this.editGroupButton_Click);
            this.editGroupButton.Leave += new System.EventHandler(this.editGroupButton_Leave);
            // 
            // editHotkeyButton
            // 
            this.editHotkeyButton.BackColor = System.Drawing.Color.Transparent;
            this.editHotkeyButton.Enabled = false;
            this.editHotkeyButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editHotkeyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.editHotkeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editHotkeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editHotkeyButton.Font = new System.Drawing.Font("宋体", 14F);
            this.editHotkeyButton.ForeColor = System.Drawing.Color.Black;
            this.editHotkeyButton.Location = new System.Drawing.Point(234, 306);
            this.editHotkeyButton.Name = "editHotkeyButton";
            this.editHotkeyButton.Size = new System.Drawing.Size(218, 26);
            this.editHotkeyButton.TabIndex = 4;
            this.editHotkeyButton.UseVisualStyleBackColor = false;
            this.editHotkeyButton.Click += new System.EventHandler(this.editHotkeyButton_Click);
            this.editHotkeyButton.Leave += new System.EventHandler(this.editHotkeyButton_Leave);
            // 
            // editURLTextBox
            // 
            this.editURLTextBox.Enabled = false;
            this.editURLTextBox.Font = new System.Drawing.Font("宋体", 14F);
            this.editURLTextBox.Location = new System.Drawing.Point(10, 338);
            this.editURLTextBox.Name = "editURLTextBox";
            this.editURLTextBox.Size = new System.Drawing.Size(666, 29);
            this.editURLTextBox.TabIndex = 5;
            this.editURLTextBox.TextChanged += new System.EventHandler(this.editURLTextBox_TextChanged);
            // 
            // editNameTextBox
            // 
            this.editNameTextBox.Enabled = false;
            this.editNameTextBox.Font = new System.Drawing.Font("宋体", 14F);
            this.editNameTextBox.Location = new System.Drawing.Point(10, 306);
            this.editNameTextBox.Name = "editNameTextBox";
            this.editNameTextBox.Size = new System.Drawing.Size(218, 29);
            this.editNameTextBox.TabIndex = 2;
            this.editNameTextBox.TextChanged += new System.EventHandler(this.editNameTextBox_TextChanged);
            // 
            // searchText_DataGridView
            // 
            this.searchText_DataGridView.AllowUserToAddRows = false;
            this.searchText_DataGridView.AllowUserToDeleteRows = false;
            this.searchText_DataGridView.AllowUserToResizeRows = false;
            this.searchText_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchText_DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchText_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.searchText_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchText_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usageColumn,
            this.nameColumn,
            this.hotkeyColumn,
            this.groupColumn,
            this.URLColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.searchText_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.searchText_DataGridView.Location = new System.Drawing.Point(10, 32);
            this.searchText_DataGridView.MultiSelect = false;
            this.searchText_DataGridView.Name = "searchText_DataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchText_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.searchText_DataGridView.RowHeadersVisible = false;
            this.searchText_DataGridView.RowHeadersWidth = 15;
            this.searchText_DataGridView.RowTemplate.Height = 23;
            this.searchText_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchText_DataGridView.Size = new System.Drawing.Size(942, 268);
            this.searchText_DataGridView.TabIndex = 1;
            this.searchText_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchText_DataGridView_CellClick);
            this.searchText_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchText_DataGridView_CellContentClick);
            // 
            // usageColumn
            // 
            this.usageColumn.FillWeight = 25F;
            this.usageColumn.HeaderText = "启用";
            this.usageColumn.Name = "usageColumn";
            // 
            // nameColumn
            // 
            this.nameColumn.FillWeight = 75F;
            this.nameColumn.HeaderText = "名字";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // hotkeyColumn
            // 
            this.hotkeyColumn.FillWeight = 75F;
            this.hotkeyColumn.HeaderText = "热键";
            this.hotkeyColumn.Name = "hotkeyColumn";
            this.hotkeyColumn.ReadOnly = true;
            // 
            // groupColumn
            // 
            this.groupColumn.FillWeight = 75F;
            this.groupColumn.HeaderText = "分组热键";
            this.groupColumn.Name = "groupColumn";
            this.groupColumn.ReadOnly = true;
            // 
            // URLColumn
            // 
            this.URLColumn.FillWeight = 200F;
            this.URLColumn.HeaderText = "URL（启动命令）";
            this.URLColumn.Name = "URLColumn";
            this.URLColumn.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(6, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(670, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "按两下 Ctrl+C 复制文本，再按下自定义按键触发运行 （%s代表剪贴板内容）";
            // 
            // phraseReplace
            // 
            this.phraseReplace.Controls.Add(this.editOutputTextBox);
            this.phraseReplace.Controls.Add(this.editInputTextBox);
            this.phraseReplace.Controls.Add(this.label6);
            this.phraseReplace.Controls.Add(this.replaceText_DataGridView);
            this.phraseReplace.Location = new System.Drawing.Point(4, 22);
            this.phraseReplace.Name = "phraseReplace";
            this.phraseReplace.Padding = new System.Windows.Forms.Padding(3);
            this.phraseReplace.Size = new System.Drawing.Size(958, 376);
            this.phraseReplace.TabIndex = 2;
            this.phraseReplace.Text = "短语替换";
            this.phraseReplace.UseVisualStyleBackColor = true;
            // 
            // editOutputTextBox
            // 
            this.editOutputTextBox.Enabled = false;
            this.editOutputTextBox.Font = new System.Drawing.Font("宋体", 14F);
            this.editOutputTextBox.Location = new System.Drawing.Point(277, 330);
            this.editOutputTextBox.Name = "editOutputTextBox";
            this.editOutputTextBox.Size = new System.Drawing.Size(675, 29);
            this.editOutputTextBox.TabIndex = 7;
            this.editOutputTextBox.TextChanged += new System.EventHandler(this.editOutputTextBox_TextChanged);
            // 
            // editInputTextBox
            // 
            this.editInputTextBox.Enabled = false;
            this.editInputTextBox.Font = new System.Drawing.Font("宋体", 14F);
            this.editInputTextBox.Location = new System.Drawing.Point(10, 330);
            this.editInputTextBox.Name = "editInputTextBox";
            this.editInputTextBox.Size = new System.Drawing.Size(261, 29);
            this.editInputTextBox.TabIndex = 6;
            this.editInputTextBox.TextChanged += new System.EventHandler(this.editInputTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.Location = new System.Drawing.Point(6, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(484, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "将输入的字符串替换为常用于，例如你的地址，邮箱等。";
            // 
            // replaceText_DataGridView
            // 
            this.replaceText_DataGridView.AllowUserToAddRows = false;
            this.replaceText_DataGridView.AllowUserToDeleteRows = false;
            this.replaceText_DataGridView.AllowUserToResizeRows = false;
            this.replaceText_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.replaceText_DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.replaceText_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.replaceText_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.replaceText_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.replaceText_DataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.replaceText_DataGridView.Location = new System.Drawing.Point(10, 32);
            this.replaceText_DataGridView.MultiSelect = false;
            this.replaceText_DataGridView.Name = "replaceText_DataGridView";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.replaceText_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.replaceText_DataGridView.RowHeadersVisible = false;
            this.replaceText_DataGridView.RowHeadersWidth = 15;
            this.replaceText_DataGridView.RowTemplate.Height = 23;
            this.replaceText_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.replaceText_DataGridView.Size = new System.Drawing.Size(942, 286);
            this.replaceText_DataGridView.TabIndex = 4;
            this.replaceText_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.replaceText_DataGridView_CellClick);
            this.replaceText_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.replaceText_DataGridView_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 25F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "启用";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "键入";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "替换为";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // HotkeyExtendIcon
            // 
            this.HotkeyExtendIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.HotkeyExtendIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("HotkeyExtendIcon.Icon")));
            this.HotkeyExtendIcon.Text = "HotKeyExtend";
            this.HotkeyExtendIcon.Visible = true;
            this.HotkeyExtendIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.iconClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.show_ToolStripMenuItem,
            this.switch_ToolStripMenuItem,
            this.exit_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // show_ToolStripMenuItem
            // 
            this.show_ToolStripMenuItem.Name = "show_ToolStripMenuItem";
            this.show_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.show_ToolStripMenuItem.Text = "显示窗口";
            this.show_ToolStripMenuItem.Click += new System.EventHandler(this.showForm);
            // 
            // switch_ToolStripMenuItem
            // 
            this.switch_ToolStripMenuItem.Name = "switch_ToolStripMenuItem";
            this.switch_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.switch_ToolStripMenuItem.Text = "启用";
            this.switch_ToolStripMenuItem.Click += new System.EventHandler(this.changeUsingStatus);
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exit_ToolStripMenuItem.Text = "退出";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit);
            // 
            // switchButton
            // 
            this.switchButton.BackColor = System.Drawing.Color.Azure;
            this.switchButton.FlatAppearance.BorderSize = 0;
            this.switchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.switchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.switchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.switchButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.switchButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.switchButton.Location = new System.Drawing.Point(9, 13);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(75, 28);
            this.switchButton.TabIndex = 1;
            this.switchButton.Text = "已关闭";
            this.switchButton.UseVisualStyleBackColor = false;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // addEdit_Button
            // 
            this.addEdit_Button.BackColor = System.Drawing.Color.Azure;
            this.addEdit_Button.Enabled = false;
            this.addEdit_Button.FlatAppearance.BorderSize = 0;
            this.addEdit_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addEdit_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addEdit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEdit_Button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addEdit_Button.ForeColor = System.Drawing.Color.Black;
            this.addEdit_Button.Location = new System.Drawing.Point(113, 13);
            this.addEdit_Button.Name = "addEdit_Button";
            this.addEdit_Button.Size = new System.Drawing.Size(50, 28);
            this.addEdit_Button.TabIndex = 2;
            this.addEdit_Button.Text = "添加";
            this.addEdit_Button.UseVisualStyleBackColor = false;
            this.addEdit_Button.Click += new System.EventHandler(this.addEdit_Button_Click);
            // 
            // deleteEdit_Button
            // 
            this.deleteEdit_Button.BackColor = System.Drawing.Color.Azure;
            this.deleteEdit_Button.Enabled = false;
            this.deleteEdit_Button.FlatAppearance.BorderSize = 0;
            this.deleteEdit_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deleteEdit_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deleteEdit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteEdit_Button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteEdit_Button.ForeColor = System.Drawing.Color.Black;
            this.deleteEdit_Button.Location = new System.Drawing.Point(169, 13);
            this.deleteEdit_Button.Name = "deleteEdit_Button";
            this.deleteEdit_Button.Size = new System.Drawing.Size(50, 28);
            this.deleteEdit_Button.TabIndex = 3;
            this.deleteEdit_Button.Text = "删除";
            this.deleteEdit_Button.UseVisualStyleBackColor = false;
            this.deleteEdit_Button.Click += new System.EventHandler(this.deleteEdit_Button_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.deleteEdit_Button);
            this.Controls.Add(this.addEdit_Button);
            this.Controls.Add(this.switchButton);
            this.Controls.Add(this.mainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotkeyExtend";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormCLosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.mainTabControl.ResumeLayout(false);
            this.ScreenBorder.ResumeLayout(false);
            this.ScreenBorder.PerformLayout();
            this.copySearch.ResumeLayout(false);
            this.copySearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchText_DataGridView)).EndInit();
            this.phraseReplace.ResumeLayout(false);
            this.phraseReplace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.replaceText_DataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage ScreenBorder;
        private System.Windows.Forms.TabPage copySearch;
        private System.Windows.Forms.TabPage phraseReplace;
        private System.Windows.Forms.Button topLeft;
        private System.Windows.Forms.Button bottomLeft;
        private System.Windows.Forms.Button middleLeft;
        private System.Windows.Forms.Button bottomRight;
        private System.Windows.Forms.Button middleRight;
        private System.Windows.Forms.Button topRight;
        private System.Windows.Forms.Button bottomMiddle;
        private System.Windows.Forms.Button topMiddle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox usage_checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox stay_combobox;
        private System.Windows.Forms.ComboBox wheelDown_combobox;
        private System.Windows.Forms.ComboBox wheel_combobox;
        private System.Windows.Forms.Label selectedText;
        private System.Windows.Forms.NotifyIcon HotkeyExtendIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem show_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switch_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView searchText_DataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn usageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotkeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn URLColumn;
        private System.Windows.Forms.Button addEdit_Button;
        private System.Windows.Forms.Button deleteEdit_Button;
        private System.Windows.Forms.TextBox editURLTextBox;
        private System.Windows.Forms.TextBox editNameTextBox;
        private System.Windows.Forms.Button editGroupButton;
        private System.Windows.Forms.Button editHotkeyButton;
        private System.Windows.Forms.TextBox editOutputTextBox;
        private System.Windows.Forms.TextBox editInputTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView replaceText_DataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}

