using UnityEngine;

public class PlaceOnTap : MonoBehaviour
{
	public GameObject cubeToPlace;

	// Called by GazeGestureManager when the user performs a Select gesture
	void OnSelect()
	{
		var direction = Camera.main.transform.forward;

		var origin = Camera.main.transform.position;

		var position = origin + direction * 2.0f;

		Instantiate(cubeToPlace, position, Quaternion.identity);
	}

}