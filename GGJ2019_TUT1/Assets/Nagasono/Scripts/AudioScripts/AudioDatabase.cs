using UnityEngine;

namespace Nagasono.AudioScripts
{
	[System.Serializable]
	public class AudioElement
	{
		[System.Serializable]
		public class AudioSetting
		{
			public AudioClip Clip;
			public float Volume;
		}

		public string Key;
		public AudioSetting Setting;
	}
	
	// Create->Database->Audio で作成
	[CreateAssetMenu(menuName = "DataBase/Audio", fileName = "New AudioDatabase")]
	public class AudioDatabase : ScriptableObject
	{
		[SerializeField] private AudioElement[] _audioList = null;

		public AudioElement[] GetAudioList()
		{
			return _audioList;
		}
	}
}
