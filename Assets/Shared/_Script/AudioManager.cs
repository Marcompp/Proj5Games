using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public MySound[] sounds;


	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			
		}
		DontDestroyOnLoad(gameObject);

		foreach (MySound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			//s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    public void Update(){
        foreach(MySound s in sounds){
            Debug.Log($"{s.name} : {s.source.isPlaying}");
        }
    }

	public void Play(string sound)
	{
		MySound s = Array.Find(sounds, item => item.name == sound);
        Debug.Log(JsonUtility.ToJson(s));
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = 1.0f;//s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = 1.0f; //s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}
	public void Stop(string sound){
        Debug.Log($"Stopping {sound}");
		MySound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop();
	}

}
