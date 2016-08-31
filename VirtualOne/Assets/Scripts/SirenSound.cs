using UnityEngine;
using System.Collections;

public class SirenSound : MonoBehaviour {
	private AudioSource audioSource = null;
	private bool isOn;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.spatialize = true;
		audioSource.spatialBlend = 1.0f;
		audioSource.dopplerLevel = 1.0f;
		audioSource.clip = Resources.Load<AudioClip>("Siren_Noise");
		audioSource.loop = true;
		isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleOnOff()
	{
		if (isOn)
		{
			audioSource.Stop();
		}
		else
		{
			audioSource.Play();
		}
		isOn = !isOn;
	}
}
