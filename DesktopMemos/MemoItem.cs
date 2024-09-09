using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMemos
{
    /// <summary>
    /// 代办事项
    /// </summary>
    public class MemoItem
    {
        /// <summary>
        /// 使用代办事项和目标时间初始化类
        /// </summary>
        /// <param name="message">待办事项</param>
        /// <param name="targetTime">提醒时间</param>
        public MemoItem(string message,DateTime targetTime)
        {
            Message = message;
            TargetTime = targetTime;
        }
        /// <summary>
        /// 代办事项内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 待办事项提醒时间
        /// </summary>
        public DateTime TargetTime { get; set; }
    }
}
