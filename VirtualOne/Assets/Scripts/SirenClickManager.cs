using UnityEngine;
using System.Collections;

public class SirenClickManager : MonoBehaviour
{
	private int timer;
	// Use this for initialization
	void Start ()
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnSelect()
	{
		this.BroadcastMessage("ToggleOnOff");
	}
}
