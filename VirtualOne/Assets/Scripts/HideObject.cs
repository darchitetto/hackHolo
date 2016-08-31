using UnityEngine;
using System.Collections;

public class HideObject : MonoBehaviour {
	private bool isOn;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		isOn = false;
		rend = this.GetComponent<Renderer>();
		rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSelect()
	{
		ToggleOnOff();
	}

	public void ToggleOnOff()
	{
		isOn = !isOn;
		rend.enabled = isOn;
	}
}
