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

        /// ������ʱ������ʱ���Ϊinterval,��λΪ��
        public void StartTimer(float value)
        {
            interval = value;
            InvokeRepeating("Run", 0, interval);
        }

        /// ֹͣ��ʱ��
        public void StopTimer()
        {
            CancelInvoke("Run");
        }

        /// ��Ӽ�ʱ���¼�
        public void AddTimerEvent(TimerInfo info)
        {
            if (!objects.Contains(info))
            {
                objects.Add(info);
            }
        }

        /// ɾ����ʱ���¼�
        public void RemoveTimerEvent(TimerInfo info)
        {
            if (objects.Contains(info) && info != null)
            {
                info.delete = true;
            }
        }

        /// ֹͣ��ʱ���¼�
        public void StopTimerEvent(TimerInfo info)
        {
            if (objects.Contains(info) && info != null)
            {
                info.stop = true;
            }
        }

        /// ������ʱ���¼�
        public void ResumeTimerEvent(TimerInfo info)
        {
            if (objects.Contains(info) && info != null)
            {
                info.delete = false;
            }
        }

        /// ��ʱ������
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
            /////////////////////////������Ϊɾ�����¼�///////////////////////////
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