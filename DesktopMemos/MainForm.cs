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
        private NotifyIcon notifyIcon;
        /// <summary>
        /// ��̨�˵�
        /// </summary>
        private ContextMenuStrip contextMenuStrip;
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

            // ����������ͼ��
            this.ShowInTaskbar = false;

            // ��������ͼ��
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("D:\\BandiZip\\icons\\default\\001.ico");  // �滻Ϊ���Լ���ͼ��
            notifyIcon.Visible = true;
            notifyIcon.Text = "Sticky Notes App";

            // ���������Ҽ��˵�
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("��ʾ", null, ShowApp);
            contextMenuStrip.Items.Add("�ر�", null, HideApp);
            contextMenuStrip.Items.Add("�˳�", null, ExitApp);

            // �� ContextMenuStrip �󶨵� NotifyIcon
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // ˫������ͼ����ʾӦ�ó���
            notifyIcon.DoubleClick += ShowApp;


            
        }

        /// <summary>
        /// ��ʾ֪ͨ��ִ����������ʱ������Ĳ���
        /// </summary>
        /// <param name="title">��ʾ����</param>
        /// <param name="message">��ʾ��Ϣ</param>
        private void ShowNotification(string title, string message)
        {
            using(NotifyIcon notifyIcon = new NotifyIcon())
            {
                notifyIcon.Visible = true;
                notifyIcon.Icon = SystemIcons.Information; // ��������һ���Զ���ͼ��
                notifyIcon.BalloonTipTitle = title;
                notifyIcon.BalloonTipText = message;
                notifyIcon.ShowBalloonTip(3000); // ��ʾ 3 ��
            }
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
        /// <param name="hour">ʱ</param>
        /// <param name="minute">��</param>
        /// <param name="second">��</param>
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
        /// ���ֵ���������µĶ�ʱ��
        /// </summary>
        /// <param name="message">��ʾ��Ϣ</param>
        /// <param name="hour">ʱ</param>
        /// <param name="minute">��</param>
        /// <param name="second">��</param>
        private void addNewMemoToDir(string message,TimeSpan countDown,ListViewItem newItem)
        {
            DateTime targetTime; // Ŀ��ʱ��
            targetTime = DateTime.Now.Add(countDown); // ����Ŀ��ʱ��
            FormTimer timer = new FormTimer();
            timer.Interval = 1000; // ÿ�봥��һ��
            timer.Tick += (sender, e) =>
            {
                if(targetTime - DateTime.Now <= new TimeSpan(0))
                {
                    ShowNotification(message, message);
                    timer.Stop();
                    timers.Remove(timer);
                }
            }; // �� Tick �¼�
            timers[timer] = newItem;
            // ������ʱ��
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
            // ��ȡ�����Panel�е�λ��
            Point mousePosition = this.PointToClient(Cursor.Position);

            // �ж�����Ƿ���Panel��������
            if (this.ClientRectangle.Contains(this.PointToClient(mousePosition)))
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
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            //NotifyIcon notifyIcon = new NotifyIcon();
            //notifyIcon.Visible = true;
            //notifyIcon.Icon = SystemIcons.Information; // ��������һ���Զ���ͼ��
            //notifyIcon.BalloonTipTitle = "��������";
            //notifyIcon.BalloonTipText = "������ı�����������";
            //notifyIcon.ShowBalloonTip(3000); // ��ʾ 3 ��

        }

        // ��ʾ����ķ���
        private void ShowApp(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate(); // �����ʾ����
        }

        // �˳�Ӧ�ó���ķ���
        private void ExitApp(object sender, EventArgs e)
        {
            notifyIcon.Visible = false; // ��������ͼ��
            Application.Exit(); // �˳�Ӧ�ó���
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