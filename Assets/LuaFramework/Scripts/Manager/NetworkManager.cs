using UnityEngine;
using System.Collections.Generic;

namespace LuaFramework
{
    public class NetworkManager : Manager
    {
        private SocketClient socket;
        static Queue<KeyValuePair<int, ByteBuffer>> sEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

        SocketClient SocketClient
        {
            get
            {
                if (socket == null)
                    socket = new SocketClient();
                return socket;
            }
        }

        void Awake()
        {
            Init();
        }

        void Init()
        {
            SocketClient.OnRegister();
        }

        public void OnInit()
        {
            CallMethod("Start");
        }

        public void Unload()
        {
            CallMethod("Unload");
        }

        /// 执行Lua方法
        public object[] CallMethod(string func, params object[] args)
        {
            return Util.CallMethod("Network", func, args);
        }

        ///------------------------------------------------------------------------------------
        public static void AddEvent(int _event, ByteBuffer data)
        {
            sEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
        }

        /// 交给Command，这里不想关心发给谁。
        void Update()
        {
            if (sEvents.Count > 0)
            {
                while (sEvents.Count > 0)
                {
                    KeyValuePair<int, ByteBuffer> _event = sEvents.Dequeue();
                    facade.SendMessageCommand(NotiConst.DISPATCH_MESSAGE, _event);
                }
            }
        }

        /// 发送链接请求
        public void SendConnect()
        {
            SocketClient.SendConnect();
        }

        /// 发送SOCKET消息
        public void SendMessage(ByteBuffer buffer)
        {
            SocketClient.SendMessage(buffer);
        }

        /// 析构函数
        new void OnDestroy()
        {
            SocketClient.OnRemove();
            Debug.Log("~NetworkManager was destroy");
        }
    }
}