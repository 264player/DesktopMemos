using System.Windows.Forms;
using FormTimer = System.Windows.Forms.Timer;

namespace DesktopMemos
{
    /// <summary>
    /// ������
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// ������ʾ
        /// </summary>
        private NotifyIcon? notifyIcon;
        /// <summary>
        /// �Ƿ���panel�ڵı�־
        /// </summary>
        private bool isMouseInsidePanel = true;
        /// <summary>
        /// ����Timer���б�
        /// </summary>
        private Dictionary<FormTimer,ListViewItem> timers = new Dictionary<FormTimer,ListViewItem>();
        /// <summary>
        /// �����ڹ��췽��
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            initialAppNotify();
            ShowInTaskbar = false; // ����������ͼ��
        }

        /// <summary>
        /// ��ʼ��ϵͳ����ͼ��
        /// </summary>
        private void initialAppNotify()
        {
            // ��������ͼ��
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("D:\\BandiZip\\icons\\default\\001.ico");  // �滻Ϊ���Լ���ͼ��
            notifyIcon.Visible = true;
            notifyIcon.Text = "�����������";
            // ˫������ͼ����ʾӦ�ó���
            notifyIcon.DoubleClick += ShowApp;
            notifyIcon.ContextMenuStrip = createNotifyMenu();
        }

        /// <summary>
        /// ��������ϵͳ���̵Ĳ˵�
        /// </summary>
        /// <returns>ϵͳ���̲˵�</returns>
        private ContextMenuStrip createNotifyMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("��ʾ", null, ShowApp);
            contextMenuStrip.Items.Add("�ر�", null, HideApp);
            contextMenuStrip.Items.Add("�˳�", null, ExitApp);
            return contextMenuStrip;
        }

        /// <summary>
        /// ��ʾ֪ͨ��ִ����������ʱ������Ĳ���
        /// </summary>
        /// <param name="title">��ʾ����</param>
        /// <param name="message">��ʾ��Ϣ</param>
        private void ShowNotification(string title, string message)
        {
            if(notifyIcon != null)
            {
                notifyIcon.BalloonTipTitle = title;
                notifyIcon.BalloonTipText = message;
                notifyIcon.ShowBalloonTip(3000); // ��ʾ 3 ��
            }else MessageBox.Show("eror:δ��ȷ��ʼ����");
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newItem_Click(object sender, EventArgs e)
        {
            addNewMemo(memoMessageTextBox.Text, getInputTime());
        }

        /// <summary>
        /// ��ȡ��������������������ʱ��
        /// </summary>
        /// <returns>���������ʱ��</returns>
        private TimeSpan getInputTime()
        {
            int hour = ((int)numericUpDownHour.Value),
                minute = ((int)numericUpDownMinute.Value),
                second = ((int)numericUpDownSecond.Value);
            return new TimeSpan(hour, minute, second);
        }

        /// <summary>
        /// ����´�������
        /// </summary>
        /// <param name="message">����������Ϣ</param>
        /// <param name="countDown">����ʱ</param>
        private void addNewMemo(string message,TimeSpan countDown)
        {
            ListViewItem newItem = addNewMemoToList(message, countDown);
            numericUpDownClear();
            addNewMemoToDir(message, countDown, newItem);
        }

        /// <summary>
        /// ��memos�б���������µ�һ��
        /// </summary>
        /// <param name="message">��Ϣ</param>
        /// <param name="countDown">����ʱ</param>
        private ListViewItem addNewMemoToList(string message,TimeSpan countDown)
        {
            ListViewItem newItem = new ListViewItem(message);
            newItem.SubItems.Add($"{countDown}");
            listView1.Items.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// �������ѡ������textbox
        /// </summary>
        private void numericUpDownClear()
        {
            numericUpDownHour.Value = 0;
            numericUpDownMinute.Value = 0;
            numericUpDownSecond.Value = 0;
            memoMessageTextBox.Text = string.Empty;
        }

        /// <summary>
        /// ���ֵ���������µĶ�ʱ��������Ϊ1��
        /// </summary>
        /// <param name="message">��ʾ��Ϣ</param>
        /// <param name="newItem">����ʱ</param>
        private void addNewMemoToDir(string message,TimeSpan countDown,ListViewItem newItem)
        {
            DateTime targetTime = DateTime.Now.Add(countDown); // ����Ŀ��ʱ��;
            FormTimer timer = new FormTimer();
            timer.Interval = 1000; // ÿ�봥��һ��
            timer.Tick += (sender, e) =>
            {
                if(targetTime - DateTime.Now <= new TimeSpan(0))
                {
                    ShowNotification("�������������", message);
                    timer.Stop();
                    timers.Remove(timer);
                }
            }; // �� Tick �¼�
            timers[timer] = newItem;
            timer.Start();
        }
        #region Events

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        /// <summary>
        /// ��form����갴��ʱ
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
        /// ��form������ƶ�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // ��ȡ�����Panel�е�λ��
            Point mousePosition = PointToClient(Cursor.Position);

            // �ж�����Ƿ���Panel��������
            if (ClientRectangle.Contains(PointToClient(mousePosition)))
            {
                // ��������Panel�ڣ����±�־
                isMouseInsidePanel = true;
            }
            else
            {
                // �����겻��Panel�ڣ����±�־���ֶ�����MouseLeave�¼�
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
        /// ��form���������ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowApp(object? sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate(); // �����ʾ����
        }

        /// <summary>
        /// �˳�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApp(object? sender, EventArgs e)
        {
            Application.Exit(); // �˳�Ӧ�ó���
        }

        /// <summary>
        /// ���ش���
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