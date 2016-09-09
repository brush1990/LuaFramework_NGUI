using UnityEngine;
using System.Collections;

namespace LuaFramework
{
    public class SoundManager : Manager
    {
        private AudioSource audio;
        private Hashtable sounds = new Hashtable();

        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        /// ���һ������
        void Add(string key, AudioClip value)
        {
            if (sounds[key] != null || value == null) return;
            sounds.Add(key, value);
        }

        /// ��ȡһ������
        AudioClip Get(string key)
        {
            if (sounds[key] == null) return null;
            return sounds[key] as AudioClip;
        }

        /// ����һ����Ƶ
        public AudioClip LoadAudioClip(string path)
        {
            AudioClip ac = Get(path);
            if (ac == null)
            {
                ac = (AudioClip)Resources.Load(path, typeof(AudioClip));
                Add(path, ac);
            }
            return ac;
        }

        /// �Ƿ񲥷ű������֣�Ĭ����1������
        public bool CanPlayBackSound()
        {
            string key = AppConst.AppPrefix + "BackSound";
            int i = PlayerPrefs.GetInt(key, 1);
            return i == 1;
        }

        /// ���ű�������
        public void PlayBacksound(string name, bool canPlay)
        {
            if (audio.clip != null)
            {
                if (name.IndexOf(audio.clip.name) > -1)
                {
                    if (!canPlay)
                    {
                        audio.Stop();
                        audio.clip = null;
                        Util.ClearMemory();
                    }
                    return;
                }
            }
            if (canPlay)
            {
                audio.loop = true;
                audio.clip = LoadAudioClip(name);
                audio.Play();
            }
            else
            {
                audio.Stop();
                audio.clip = null;
                Util.ClearMemory();
            }
        }

        /// �Ƿ񲥷���Ч,Ĭ����1������
        public bool CanPlaySoundEffect()
        {
            string key = AppConst.AppPrefix + "SoundEffect";
            int i = PlayerPrefs.GetInt(key, 1);
            return i == 1;
        }

        /// ������Ƶ����
        public void Play(AudioClip clip, Vector3 position)
        {
            if (!CanPlaySoundEffect()) return;
            AudioSource.PlayClipAtPoint(clip, position);
        }
    }
}