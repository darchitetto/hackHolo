using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using HoloToolkit.Unity;

public class wreckThePyramid : MonoBehaviour
{
	public bool isSelected = false;
	public GameObject Story;
	private AudioSource audioSource = null;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.spatialize = true;
		audioSource.spatialBlend = 1.0f;
		audioSource.dopplerLevel = 1.0f;
		audioSource.loop = false;
	}

	// Update is called once per frame
	void OnSelect () {
		audioSource.Play();

		if (isSelected)
		{
			Regex r = new Regex(".*\\(Clone\\)$");

			foreach (GameObject o in FindObjectsOfType<GameObject>().Where(o => r.IsMatch(o.name)))
			{
				o.AddComponent<Rigidbody>();
			}
			audioSource.clip = Resources.Load<AudioClip>("PyramidFalling");

			audioSource.Play();
			isSelected = false;
		}
		else
		{
			audioSource.Stop();
			isSelected = true;
		}

	}
}
