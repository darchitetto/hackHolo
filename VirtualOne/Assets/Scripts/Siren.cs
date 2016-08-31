using UnityEngine;
using System.Collections;

public class Siren : MonoBehaviour
{
	private Renderer rend;
	private bool isOn;
	private int count;
	private Color darkred = new Color32(150,0,0,1);
	private Color lightred = new Color32(255,50,50,1);
	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer>();
		isOn = false;
		rend.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isOn && count>35)
		{
			var color = rend.material.color;
			if (color == lightred)
			{
				rend.material.color = darkred;
			}
			else
			{
				rend.material.color = lightred;
			}

			count = 0;
		}
		count++;
	}

	void OnSelect()
	{
		ToggleOnOff();
	}

	public void ToggleOnOff()
	{
		if (isOn)
		{
			rend.material.color = Color.green;
		}
		else
		{
			rend.material.color = Color.red;
		}
		isOn = !isOn;
	}
}
