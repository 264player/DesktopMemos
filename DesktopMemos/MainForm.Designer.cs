namespace DesktopMemos
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listView1 = new ListView();
            MemoInfo = new ColumnHeader();
            CountDown = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItemFontSize = new ToolStripMenuItem();
            smallSize = new ToolStripMenuItem();
            mediaSize = new ToolStripMenuItem();
            largeSize = new ToolStripMenuItem();
            veryLargeSize = new ToolStripMenuItem();
            toolStripMenuItemLock = new ToolStripMenuItem();
            toolStripMenuItemAlwaysOnTop = new ToolStripMenuItem();
            opacityToolStripMenuItem = new ToolStripMenuItem();
            opacity20 = new ToolStripMenuItem();
            opacity40 = new ToolStripMenuItem();
            opacity60 = new ToolStripMenuItem();
            opacity80 = new ToolStripMenuItem();
            opacity100 = new ToolStripMenuItem();
            newItem = new Button();
            memoMessageTextBox = new TextBox();
            eventMessageLabel = new Label();
            hourLabel = new Label();
            numericUpDownHour = new NumericUpDown();
            numericUpDownMinute = new NumericUpDown();
            minuetLabel = new Label();
            numericUpDownSecond = new NumericUpDown();
            secondLabel = new Label();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSecond).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { MemoInfo, CountDown });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(0, 0);
            listView1.Margin = new Padding(0);
            listView1.Name = "listView1";
            listView1.Scrollable = false;
            listView1.Size = new Size(150, 150);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.MouseHover += notify_Hover;
            // 
            // MemoInfo
            // 
            MemoInfo.Text = "备忘信息";
            MemoInfo.Width = 100;
            // 
            // CountDown
            // 
            CountDown.Text = "倒计时";
            CountDown.TextAlign = HorizontalAlignment.Right;
            CountDown.Width = 50;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemFontSize, toolStripMenuItemLock, toolStripMenuItemAlwaysOnTop, opacityToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(207, 92);
            // 
            // toolStripMenuItemFontSize
            // 
            toolStripMenuItemFontSize.DropDownItems.AddRange(new ToolStripItem[] { smallSize, mediaSize, largeSize, veryLargeSize });
            toolStripMenuItemFontSize.Name = "toolStripMenuItemFontSize";
            toolStripMenuItemFontSize.Size = new Size(206, 22);
            toolStripMenuItemFontSize.Text = "Font size";
            // 
            // smallToolStripMenuItem
            // 
            smallSize.Name = "smallToolStripMenuItem";
            smallSize.Size = new Size(136, 22);
            smallSize.Text = "Small";
            smallSize.Click += menuFontSize;
            // 
            // mediaToolStripMenuItem
            // 
            mediaSize.Name = "mediaToolStripMenuItem";
            mediaSize.Size = new Size(136, 22);
            mediaSize.Text = "Media";
            mediaSize.Click += menuFontSize;
            // 
            // largeToolStripMenuItem
            // 
            largeSize.Name = "largeToolStripMenuItem";
            largeSize.Size = new Size(136, 22);
            largeSize.Text = "Large";
            largeSize.Click += menuFontSize;
            // 
            // veryLargeToolStripMenuItem
            // 
            veryLargeSize.Name = "veryLargeToolStripMenuItem";
            veryLargeSize.Size = new Size(136, 22);
            veryLargeSize.Text = "Very large";
            veryLargeSize.Click += menuFontSize;
            // 
            // toolStripMenuItemLock
            // 
            toolStripMenuItemLock.Name = "toolStripMenuItemLock";
            toolStripMenuItemLock.Size = new Size(206, 22);
            toolStripMenuItemLock.Text = "Lock position and size";
            toolStripMenuItemLock.Click += toolStripMenuItemLock_Click;
            // 
            // toolStripMenuItemAlwaysOnTop
            // 
            toolStripMenuItemAlwaysOnTop.Name = "toolStripMenuItemAlwaysOnTop";
            toolStripMenuItemAlwaysOnTop.Size = new Size(206, 22);
            toolStripMenuItemAlwaysOnTop.Text = "Always on top";
            toolStripMenuItemAlwaysOnTop.Click += menuAlwaysOnTop;
            // 
            // opacityToolStripMenuItem
            // 
            opacityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { opacity20, opacity40, opacity60, opacity80, opacity100 });
            opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            opacityToolStripMenuItem.Size = new Size(206, 22);
            opacityToolStripMenuItem.Text = "Opacity";
            // 
            // toolStripMenuItem5
            // 
            opacity20.Name = "toolStripMenuItem5";
            opacity20.Size = new Size(108, 22);
            opacity20.Text = "20%";
            opacity20.Click += menuOpacity;
            // 
            // toolStripMenuItem6
            // 
            opacity40.Name = "toolStripMenuItem6";
            opacity40.Size = new Size(108, 22);
            opacity40.Text = "40%";
            opacity40.Click += menuOpacity;
            // 
            // toolStripMenuItem7
            // 
            opacity60.Name = "toolStripMenuItem7";
            opacity60.Size = new Size(108, 22);
            opacity60.Text = "60%";
            opacity60.Click += menuOpacity;
            // 
            // toolStripMenuItem8
            // 
            opacity80.Name = "toolStripMenuItem8";
            opacity80.Size = new Size(108, 22);
            opacity80.Text = "80%";
            opacity80.Click += menuOpacity;
            // 
            // toolStripMenuItem9
            // 
            opacity100.Name = "toolStripMenuItem9";
            opacity100.Size = new Size(108, 22);
            opacity100.Text = "100%";
            opacity100.Click += menuOpacity;
            // 
            // newItem
            // 
            newItem.Location = new Point(0, 248);
            newItem.Name = "newItem";
            newItem.Size = new Size(150, 23);
            newItem.TabIndex = 1;
            newItem.Text = "新增";
            newItem.UseVisualStyleBackColor = true;
            newItem.Click += newItem_Click;
            newItem.MouseEnter += notify_Hover;
            // 
            // memoMessageTextBox
            // 
            memoMessageTextBox.Location = new Point(0, 173);
            memoMessageTextBox.Name = "memoMessageTextBox";
            memoMessageTextBox.Size = new Size(150, 23);
            memoMessageTextBox.TabIndex = 2;
            // 
            // eventMessageLabel
            // 
            eventMessageLabel.AutoSize = true;
            eventMessageLabel.Location = new Point(0, 153);
            eventMessageLabel.Name = "eventMessageLabel";
            eventMessageLabel.Size = new Size(56, 17);
            eventMessageLabel.TabIndex = 3;
            eventMessageLabel.Text = "备忘信息";
            // 
            // hourLabel
            // 
            hourLabel.AutoSize = true;
            hourLabel.Location = new Point(0, 199);
            hourLabel.Name = "hourLabel";
            hourLabel.Size = new Size(20, 17);
            hourLabel.TabIndex = 4;
            hourLabel.Text = "时";
            // 
            // numericUpDownHour
            // 
            numericUpDownHour.Location = new Point(0, 219);
            numericUpDownHour.Maximum = new decimal(new int[] { 48, 0, 0, 0 });
            numericUpDownHour.Name = "numericUpDownHour";
            numericUpDownHour.Size = new Size(43, 23);
            numericUpDownHour.TabIndex = 5;
            // 
            // numericUpDownMinute
            // 
            numericUpDownMinute.Location = new Point(47, 219);
            numericUpDownMinute.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericUpDownMinute.Name = "numericUpDownMinute";
            numericUpDownMinute.Size = new Size(43, 23);
            numericUpDownMinute.TabIndex = 7;
            // 
            // minuetLabel
            // 
            minuetLabel.AutoSize = true;
            minuetLabel.Location = new Point(47, 199);
            minuetLabel.Name = "minuetLabel";
            minuetLabel.Size = new Size(20, 17);
            minuetLabel.TabIndex = 6;
            minuetLabel.Text = "分";
            // 
            // numericUpDownSecond
            // 
            numericUpDownSecond.Location = new Point(95, 219);
            numericUpDownSecond.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericUpDownSecond.Name = "numericUpDownSecond";
            numericUpDownSecond.Size = new Size(43, 23);
            numericUpDownSecond.TabIndex = 9;
            // 
            // secondLabel
            // 
            secondLabel.AutoSize = true;
            secondLabel.Location = new Point(95, 199);
            secondLabel.Name = "secondLabel";
            secondLabel.Size = new Size(20, 17);
            secondLabel.TabIndex = 8;
            secondLabel.Text = "秒";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(150, 270);
            Controls.Add(numericUpDownSecond);
            Controls.Add(secondLabel);
            Controls.Add(numericUpDownMinute);
            Controls.Add(minuetLabel);
            Controls.Add(numericUpDownHour);
            Controls.Add(hourLabel);
            Controls.Add(eventMessageLabel);
            Controls.Add(memoMessageTextBox);
            Controls.Add(newItem);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "Form";
            MouseDown += Form_MouseDown;
            MouseMove += Form_MouseMove;
            MouseUp += Form_MouseUp;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinute).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSecond).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader MemoInfo;
        private ColumnHeader CountDown;
        private Button newItem;
        private TextBox memoMessageTextBox;
        private Label eventMessageLabel;
        private Label hourLabel;
        private NumericUpDown numericUpDownHour;
        private NumericUpDown numericUpDownMinute;
        private Label minuetLabel;
        private NumericUpDown numericUpDownSecond;
        private Label secondLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItemFontSize;
        private ToolStripMenuItem toolStripMenuItemLock;
        private ToolStripMenuItem toolStripMenuItemAlwaysOnTop;
        private ToolStripMenuItem smallSize;
        private ToolStripMenuItem mediaSize;
        private ToolStripMenuItem largeSize;
        private ToolStripMenuItem veryLargeSize;
        private ToolStripMenuItem opacityToolStripMenuItem;
        private ToolStripMenuItem opacity20;
        private ToolStripMenuItem opacity40;
        private ToolStripMenuItem opacity60;
        private ToolStripMenuItem opacity80;
        private ToolStripMenuItem opacity100;
    }
}