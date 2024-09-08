using System.Windows.Forms;
using FormTimer = System.Windows.Forms.Timer;

namespace DesktopMemos
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 桌面提示
        /// </summary>
        private NotifyIcon notifyIcon;
        /// <summary>
        /// 后台菜单
        /// </summary>
        private ContextMenuStrip contextMenuStrip;
        /// <summary>
        /// 是否在panel内的标志
        /// </summary>
        private bool isMouseInsidePanel = true;
        /// <summary>
        /// 保存Timer的列表
        /// </summary>
        private Dictionary<FormTimer,ListViewItem> timers = new Dictionary<FormTimer,ListViewItem>();
        /// <summary>
        /// 主窗口构造方法
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // 隐藏任务栏图标
            this.ShowInTaskbar = false;

            // 创建托盘图标
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("D:\\BandiZip\\icons\\default\\001.ico");  // 替换为你自己的图标
            notifyIcon.Visible = true;
            notifyIcon.Text = "Sticky Notes App";

            // 创建托盘右键菜单
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("显示", null, ShowApp);
            contextMenuStrip.Items.Add("关闭", null, HideApp);
            contextMenuStrip.Items.Add("退出", null, ExitApp);

            // 将 ContextMenuStrip 绑定到 NotifyIcon
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // 双击托盘图标显示应用程序
            notifyIcon.DoubleClick += ShowApp;


            
        }

        /// <summary>
        /// 显示通知或执行其他倒计时结束后的操作
        /// </summary>
        /// <param name="title">提示标题</param>
        /// <param name="message">提示信息</param>
        private void ShowNotification(string title, string message)
        {
            using(NotifyIcon notifyIcon = new NotifyIcon())
            {
                notifyIcon.Visible = true;
                notifyIcon.Icon = SystemIcons.Information; // 可以设置一个自定义图标
                notifyIcon.BalloonTipTitle = title;
                notifyIcon.BalloonTipText = message;
                notifyIcon.ShowBalloonTip(3000); // 显示 3 秒
            }
        }

        /// <summary>
        /// 新增代办事项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newItem_Click(object sender, EventArgs e)
        {
            string info = memoMessageTextBox.Text;
            int hour = ((int)numericUpDownHour.Value),
                minute = ((int)numericUpDownMinute.Value),
                second = ((int)numericUpDownSecond.Value);
            ListViewItem newItem = addNewMemoToList(info, hour, minute, second);
            numericUpDownClear();
            addNewMemoToDir(info, hour, minute, second, newItem);
        }

        /// <summary>
        /// 向momo列表里面添加新的一项
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="hour">时</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        private ListViewItem addNewMemoToList(string message,int hour,int minute,int second)
        {
            ListViewItem newItem = new ListViewItem(message);
            newItem.SubItems.Add($"{hour}h{minute}m{second}s");
            listView1.Items.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// 清空数字选择器和textbox
        /// </summary>
        private void numericUpDownClear()
        {
            numericUpDownHour.Value = 0;
            numericUpDownMinute.Value = 0;
            numericUpDownSecond.Value = 0;
            memoMessageTextBox.Text = string.Empty;
        }

        /// <summary>
        /// 向字典里面加入新的定时器
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="hour">时</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        private void addNewMemoToDir(string message,int hour,int minute,int second,ListViewItem newItem)
        {
            DateTime targetTime; // 目标时间
            TimeSpan countdownTime; // 倒计时时长
            countdownTime = new TimeSpan(hour, minute, second); // 倒计时30秒
            targetTime = DateTime.Now.Add(countdownTime); // 设置目标时间
            FormTimer timer = new FormTimer();
            timer.Interval = 1000; // 每秒触发一次
            timer.Tick += (sender, e) =>
            {
                if(targetTime - DateTime.Now <= new TimeSpan(0))
                {
                    ShowNotification(message, message);
                    timer.Stop();
                    timers.Remove(timer);
                }
            }; // 绑定 Tick 事件
            timers[timer] = newItem;
            // 启动定时器
            timer.Start();
        }
        #region Events

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // 获取鼠标在Panel中的位置
            Point mousePosition = this.PointToClient(Cursor.Position);

            // 判断鼠标是否在Panel的区域内
            if (this.ClientRectangle.Contains(this.PointToClient(mousePosition)))
            {
                // 如果鼠标在Panel内，更新标志
                isMouseInsidePanel = true;
            }
            else
            {
                // 如果鼠标不在Panel内，更新标志并手动触发MouseLeave事件
                if (isMouseInsidePanel)
                {
                    isMouseInsidePanel = false;
                    notify_MouseLeave(sender, e);
                }
            }
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            //NotifyIcon notifyIcon = new NotifyIcon();
            //notifyIcon.Visible = true;
            //notifyIcon.Icon = SystemIcons.Information; // 可以设置一个自定义图标
            //notifyIcon.BalloonTipTitle = "备忘提醒";
            //notifyIcon.BalloonTipText = "这是你的备忘提醒内容";
            //notifyIcon.ShowBalloonTip(3000); // 显示 3 秒

        }

        // 显示窗体的方法
        private void ShowApp(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate(); // 激活并显示窗体
        }

        // 退出应用程序的方法
        private void ExitApp(object sender, EventArgs e)
        {
            notifyIcon.Visible = false; // 隐藏托盘图标
            Application.Exit(); // 退出应用程序
        }

        private void HideApp(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notify_Hover(object sender, EventArgs e)
        {
            this.Size = new Size(Size.Width, 270);
        }


        private void notify_MouseLeave(object sender, EventArgs e)
        {
            if (!isMouseInsidePanel)
            {
                this.Size = new Size(Size.Width, 150);
            }
        }
        #endregion



    }
}