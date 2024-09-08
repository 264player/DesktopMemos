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
        private NotifyIcon? notifyIcon;
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
            initialAppNotify();
            ShowInTaskbar = false; // 隐藏任务栏图标
        }

        /// <summary>
        /// 初始化系统托盘图标
        /// </summary>
        private void initialAppNotify()
        {
            // 创建托盘图标
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("D:\\BandiZip\\icons\\default\\001.ico");  // 替换为你自己的图标
            notifyIcon.Visible = true;
            notifyIcon.Text = "桌面待办事项";
            // 双击托盘图标显示应用程序
            notifyIcon.DoubleClick += ShowApp;
            notifyIcon.ContextMenuStrip = createNotifyMenu();
        }

        /// <summary>
        /// 创建用于系统托盘的菜单
        /// </summary>
        /// <returns>系统托盘菜单</returns>
        private ContextMenuStrip createNotifyMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("显示", null, ShowApp);
            contextMenuStrip.Items.Add("关闭", null, HideApp);
            contextMenuStrip.Items.Add("退出", null, ExitApp);
            return contextMenuStrip;
        }

        /// <summary>
        /// 显示通知或执行其他倒计时结束后的操作
        /// </summary>
        /// <param name="title">提示标题</param>
        /// <param name="message">提示信息</param>
        private void ShowNotification(string title, string message)
        {
            if(notifyIcon != null)
            {
                notifyIcon.BalloonTipTitle = title;
                notifyIcon.BalloonTipText = message;
                notifyIcon.ShowBalloonTip(3000); // 显示 3 秒
            }else MessageBox.Show("eror:未正确初始化！");
        }

        /// <summary>
        /// 新增代办事项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newItem_Click(object sender, EventArgs e)
        {
            addNewMemo(memoMessageTextBox.Text, getInputTime());
        }

        /// <summary>
        /// 获取三个数字输入框中输入的时间
        /// </summary>
        /// <returns>返回输入的时间</returns>
        private TimeSpan getInputTime()
        {
            int hour = ((int)numericUpDownHour.Value),
                minute = ((int)numericUpDownMinute.Value),
                second = ((int)numericUpDownSecond.Value);
            return new TimeSpan(hour, minute, second);
        }

        /// <summary>
        /// 添加新待办事项
        /// </summary>
        /// <param name="message">代办事项信息</param>
        /// <param name="countDown">倒计时</param>
        private void addNewMemo(string message,TimeSpan countDown)
        {
            ListViewItem newItem = addNewMemoToList(message, countDown);
            numericUpDownClear();
            addNewMemoToDir(message, countDown, newItem);
        }

        /// <summary>
        /// 向memos列表里面添加新的一项
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="countDown">倒计时</param>
        private ListViewItem addNewMemoToList(string message,TimeSpan countDown)
        {
            ListViewItem newItem = new ListViewItem(message);
            newItem.SubItems.Add($"{countDown}");
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
        /// 向字典里面加入新的定时器，精度为1秒
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="newItem">倒计时</param>
        private void addNewMemoToDir(string message,TimeSpan countDown,ListViewItem newItem)
        {
            DateTime targetTime = DateTime.Now.Add(countDown); // 设置目标时间;
            FormTimer timer = new FormTimer();
            timer.Interval = 1000; // 每秒触发一次
            timer.Tick += (sender, e) =>
            {
                if(targetTime - DateTime.Now <= new TimeSpan(0))
                {
                    ShowNotification("代办事项到期提醒", message);
                    timer.Stop();
                    timers.Remove(timer);
                }
            }; // 绑定 Tick 事件
            timers[timer] = newItem;
            timer.Start();
        }
        #region Events

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        /// <summary>
        /// 在form上鼠标按下时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        /// <summary>
        /// 在form上鼠标移动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // 获取鼠标在Panel中的位置
            Point mousePosition = PointToClient(Cursor.Position);

            // 判断鼠标是否在Panel的区域内
            if (ClientRectangle.Contains(PointToClient(mousePosition)))
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
                Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        /// <summary>
        /// 在form上鼠标起来时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowApp(object? sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate(); // 激活并显示窗体
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApp(object? sender, EventArgs e)
        {
            Application.Exit(); // 退出应用程序
        }

        /// <summary>
        /// 隐藏窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideApp(object? sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notify_Hover(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, 270);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notify_MouseLeave(object sender, EventArgs e)
        {
            if (!isMouseInsidePanel)
            {
                Size = new Size(Size.Width, 150);
            }
        }
        #endregion



    }
}