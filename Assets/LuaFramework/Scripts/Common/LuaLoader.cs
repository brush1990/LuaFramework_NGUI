using UnityEngine;
using System.IO;
using LuaInterface;

namespace LuaFramework
{
    /// 继承自LuaFileUtils，重写里面的ReadFile，
    public class LuaLoader : LuaFileUtils
    {
        public LuaLoader()
        {
            instance = this;
            //beZip = false 在search path 中查找读取lua文件。否则从外部设置过来bundel文件中读取lua文件
            beZip = AppConst.LuaBundleMode;
        }

        /// 添加打入Lua代码的AssetBundle
        public void AddBundle(string bundleName)
        {
            string url = Util.DataPath + bundleName.ToLower(); ;
            if (File.Exists(url))
            {
                AssetBundle bundle = AssetBundle.CreateFromFile(url);
                if (bundle != null)
                {
                    bundleName = bundleName.Replace("lua/", "").Replace(".unity3d", "");
                    base.AddSearchBundle(bundleName.ToLower(), bundle);
                }
            }
        }

        /// 当LuaVM加载Lua文件的时候，这里就会被调用，
        /// 用户可以自定义加载行为，只要返回byte[]即可。
        public override byte[] ReadFile(string fileName)
        {
            return base.ReadFile(fileName);
        }
    }
}