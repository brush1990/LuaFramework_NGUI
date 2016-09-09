using UnityEngine;
using System.Collections.Generic;

namespace LuaFramework
{
    public class TimerInfo
    {
        public long tick;
        public bool stop;
        public bool delete;
        public Object target;
        public string className;

        public TimerInfo(string className, Object target)
        {
            this.className = className;
            this.target = target;
            delete = false;
        }
    }

    public class TimerManager : Manager
    {
        private float interval = 0;
        private List<TimerInfo> objects = new List<TimerInfo>();
        public float Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        void Start()
        {
            StartTimer(AppConst.TimerInterval);
        }

        /// 启动计时器，计时间隔为interval,单位为秒
        public void StartTimer(float value)
        {
            interval = value;
            InvokeRepeating("Run", 0, interval);
        }

        /// 停止计时器
        public void StopTimer()
        {
            CancelInvoke("Run");
        }

        /// 添加计时器事件
        public void AddTimerEvent(TimerInfo info)
        {
            if (!objects.Contains(info))
            {
                objects.Add(info);
            }
        }

        /// 删除计时器事件
        public void RemoveTimerEvent(TimerInfo info)
        {
            if (objects.Contains(info) && info != null)
            {
                info.delete = true;
            }
        }

        /// 停止计时器事件
        public void StopTimerEvent(TimerInfo info)
        {
            if (objects.Contains(info) && info != null)
            {
                info.stop = true;
            }
        }

        /// 继续计时器事件
        public void ResumeTimerEvent(TimerInfo info)
        {
            if (objects.Contains(info) && info != null)
            {
                info.delete = false;
            }
        }

        /// 计时器运行
        void Run()
        {
            if (objects.Count == 0)
                return;
            for (int i = 0; i < objects.Count; i++)
            {
                TimerInfo o = objects[i];
                if (o.delete || o.stop)
                {
                    continue;
                }
                ITimerBehaviour timer = o.target as ITimerBehaviour;
                timer.TimerUpdate();
                o.tick++;
            }
            /////////////////////////清除标记为删除的事件///////////////////////////
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].delete)
                {
                    objects.Remove(objects[i]);
                }
            }
        }
    }
}