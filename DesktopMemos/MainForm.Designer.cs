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
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "吃饭", "21s" }, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "睡觉", "2h" }, -1);
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "打豆豆", "1min" }, -1);
            listView1 = new ListView();
            MemoInfo = new ColumnHeader();
            CountDown = new ColumnHeader();
            newItem = new Button();
            memoMessageTextBox = new TextBox();
            eventMessageLabel = new Label();
            hourLabel = new Label();
            numericUpDownHour = new NumericUpDown();
            numericUpDownMinute = new NumericUpDown();
            minuetLabel = new Label();
            numericUpDownSecond = new NumericUpDown();
            secondLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSecond).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { MemoInfo, CountDown });
            listView1.FullRowSelect = true;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            listView1.Location = new Point(0, 0);
            listView1.Margin = new Padding(0);
            listView1.Name = "listView1";
            listView1.Size = new Size(150, 150);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
    }
}