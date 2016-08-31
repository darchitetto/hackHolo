using UnityEngine;

public class PlaceOnTap : MonoBehaviour
{
    [Tooltip("Game object to place when tapping")]
	public GameObject cubeToPlace;

    [Tooltip("Distance in front of camera.")]
    public float CameraDistance = 2.0f;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
	{
		var direction = Camera.main.transform.forward;

		var origin = Camera.main.transform.position;

		var position = origin + direction * CameraDistance;

		Instantiate(cubeToPlace, position, Quaternion.identity);
	}

}