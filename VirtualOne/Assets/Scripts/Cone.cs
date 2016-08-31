using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.RotateAround(transform.parent.gameObject.transform.position, Vector3.up, 45*Time.deltaTime);
	}
}
