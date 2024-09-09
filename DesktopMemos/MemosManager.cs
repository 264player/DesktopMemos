using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMemos
{
    /// <summary>
    /// 代办事项管理，单例类
    /// </summary>
    public class MemosManager
    {
        private static readonly MemosManager _memosManager = new MemosManager();
        /// <summary>
        /// 代办事项列表
        /// </summary>
        public List<MemoItem> MemoItems {  get; }
        /// <summary>
        /// 隐藏的构造方法
        /// </summary>
        private MemosManager()
        {
            MemoItems = new List<MemoItem>();
        }

        /// <summary>
        /// 获取单例的方法
        /// </summary>
        /// <returns>返回唯一的单例</returns>
        public static MemosManager Instance
        {
            get { return _memosManager; }
        }
        

        /// <summary>
        /// 添加代办事项
        /// </summary>
        /// <param name="item"></param>
        public void AddMemo(MemoItem item)
        {
            MemoItems.Add(item);
        }

        /// <summary>
        /// 删除指定memo
        /// </summary>
        /// <param name="item"></param>
        public void RemoveMemo(MemoItem item)
        {
            MemoItems.Remove(item);
        }

        /// <summary>
        /// 获取所有memo
        /// </summary>
        /// <returns></returns>
        public MemoItem[] GetAllMemos()
        {
            return MemoItems.ToArray();
        }
    }
}
