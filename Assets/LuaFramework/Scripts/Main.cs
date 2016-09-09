using UnityEngine;

namespace LuaFramework
{
    /// 框架主入口
    public class Main : MonoBehaviour
    {
        void Start()
        {
            AppFacade.Instance.StartUp();   //启动游戏
        }
    }
}