using System.Collections.Generic;
using UnityEngine;

namespace Nagasono.AudioScripts
{
	public class AudioManager : MonoBehaviour
	{
		private static AudioManager _instance;

		private Dictionary<string, AudioElement.AudioSetting> _audioList;

		[SerializeField] private AudioSource _soundEffectPlayer = null;

		[SerializeField] private AudioDatabase _database = null;

		private void Awake()
		{
			if (_instance)
			{
				Destroy(gameObject);
				return;
			}

			_instance = this;

			_audioList = new Dictionary<string, AudioElement.AudioSetting>();
			var list = _database.GetAudioList();
			foreach (var t in list)
			{
				_audioList[t.Key] = t.Setting;
			}
		}

		// サウンド再生
		public static void PlayAudio(string key)
		{
			_instance.playAudio(key);
		}

		// 音量を指定してサウンド再生
		public static void PlayAudio(string key, float audioLevel, bool isConstant)
		{
			_instance.playAudio(key, audioLevel, isConstant);
		}

		private void playAudio(string key)
		{
			if (_audioList.Count == 0) return;
			if (!_audioList.ContainsKey(key))
			{
				Debug.Log("Key Not Found! :" + key);
				return;
			}

			var setting = _audioList[key];
			_soundEffectPlayer.PlayOneShot(setting.Clip, setting.Volume);
		}

		private void playAudio(string key, float audioLevel, bool isConstant)
		{
			if (_audioList.Count == 0) return;
			if (!_audioList.ContainsKey(key))
			{
				Debug.Log("Key Not Found! :" + key);
				return;
			}

			var setting = _audioList[key];
			_soundEffectPlayer.PlayOneShot(setting.Clip, isConstant ? audioLevel : audioLevel * setting.Volume);
		}
	}
}
