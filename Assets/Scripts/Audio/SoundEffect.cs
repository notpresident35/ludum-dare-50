using UnityEngine;
using UnityEngine.Events;

public class SoundEffect : MonoBehaviour
{
	public UnityEvent<GameObject> CompleteCallback;
	AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (!source.isPlaying)
		{
			CompleteCallback?.Invoke(gameObject);
		}
	}
}
