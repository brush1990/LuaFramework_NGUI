using UnityEngine;
using System.IO;
using System;

namespace LuaFramework
{
    public class ResourceManager : Manager
    {
        private AssetBundle shared;

        /// ��ʼ��
        public void initialize(Action func)
        {
            if (AppConst.ExampleMode)
            {
                byte[] stream;
                string uri = string.Empty;
                //------------------------------------Shared--------------------------------------
                uri = Util.DataPath + "shared" + AppConst.ExtName;
                Debug.LogWarning("LoadFile::>> " + uri);

                stream = File.ReadAllBytes(uri);
                shared = AssetBundle.CreateFromMemoryImmediate(stream);
#if UNITY_5
        shared.LoadAsset("Dialog", typeof(GameObject));
#else
                shared.Load("Dialog", typeof(GameObject));
#endif
            }
            if (func != null) func();    //��Դ��ʼ����ɣ��ص���Ϸ��������ִ�к������� 
        }

        /// �����ز�
        public AssetBundle LoadBundle(string name)
        {
            byte[] stream = null;
            AssetBundle bundle = null;
            string uri = Util.DataPath + name.ToLower() + AppConst.ExtName;
            stream = File.ReadAllBytes(uri);
            bundle = AssetBundle.CreateFromMemoryImmediate(stream); //�������ݵ��زİ�
            return bundle;
        }

        /// ������Դ
        void OnDestroy()
        {
            if (shared != null)
                shared.Unload(true);
            Debug.Log("~ResourceManager was destroy!");
        }
    }
}