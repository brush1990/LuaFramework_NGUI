using UnityEngine;
using LuaFramework;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    //所有的管理器都可以通过Facade去访问
    private AppFacade m_Facade;
    protected AppFacade facade
    {
        get
        {
            if (m_Facade == null)
            {
                m_Facade = AppFacade.Instance;
            }
            return m_Facade;
        }
    }

    private LuaManager m_LuaMgr;
    protected LuaManager LuaManager
    {
        get
        {
            if (m_LuaMgr == null)
            {
                m_LuaMgr = facade.GetManager<LuaManager>(ManagerName.Lua);
            }
            return m_LuaMgr;
        }
    }

    private ResourceManager m_ResMgr;
    protected ResourceManager ResManager
    {
        get
        {
            if (m_ResMgr == null)
            {
                m_ResMgr = facade.GetManager<ResourceManager>(ManagerName.Resource);
            }
            return m_ResMgr;
        }
    }

    private NetworkManager m_NetMgr;
    protected NetworkManager NetManager
    {
        get
        {
            if (m_NetMgr == null)
            {
                m_NetMgr = facade.GetManager<NetworkManager>(ManagerName.Network);
            }
            return m_NetMgr;
        }
    }

    private SoundManager m_SoundMgr;
    protected SoundManager SoundManager
    {
        get
        {
            if (m_SoundMgr == null)
            {
                m_SoundMgr = facade.GetManager<SoundManager>(ManagerName.Sound);
            }
            return m_SoundMgr;
        }
    }

    private TimerManager m_TimerMgr;
    protected TimerManager TimerManager
    {
        get
        {
            if (m_TimerMgr == null)
            {
                m_TimerMgr = facade.GetManager<TimerManager>(ManagerName.Timer);
            }
            return m_TimerMgr;
        }
    }
    
    private ThreadManager m_ThreadMgr;
    protected ThreadManager ThreadManager
    {
        get
        {
            if (m_ThreadMgr == null)
            {
                m_ThreadMgr = facade.GetManager<ThreadManager>(ManagerName.Thread);
            }
            return m_ThreadMgr;
        }
    }

    private ObjectPoolManager m_ObjectPoolMgr;
    protected ObjectPoolManager ObjPoolManager
    {
        get
        {
            if (m_ObjectPoolMgr == null)
            {
                m_ObjectPoolMgr = facade.GetManager<ObjectPoolManager>(ManagerName.ObjectPool);
            }
            return m_ObjectPoolMgr;
        }
    }

    /// 注册消息
    protected void RegisterMessage(IView view, List<string> messages)
    {
        if (messages == null || messages.Count == 0)
            return;
        Controller.Instance.RegisterViewCommand(view, messages.ToArray());
    }
    /// 移除消息
    protected void RemoveMessage(IView view, List<string> messages)
    {
        if (messages == null || messages.Count == 0)
            return;
        Controller.Instance.RemoveViewCommand(view, messages.ToArray());
    }
}
