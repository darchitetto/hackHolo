using UnityEngine;

public class PlaceOnTap : MonoBehaviour
{
    [Tooltip("Game object to place when tapping")]
	public GameObject cubeToPlace;

    [Tooltip("Distance from object.")]
    public float Distance = 2.0f;

    [Tooltip("Immediately move the object")]
    public bool MoveOnPlace = true;

    void OnSelect()
    {
        if (MoveOnPlace)
            OnSelectNextToCamera();
        else
            OnSelectNextToObject();
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelectNextToObject()
    {
        // this makes the objet face the camera
        // transform.LookAt(Camera.main.transform);
        // Camera.main.transform.LookAt(transform);


        // position new object relative to this object
        var direction = transform.forward;

        var origin = transform.position;


        var position = origin + direction * Distance;

        var obj = Instantiate(cubeToPlace, position, Quaternion.identity);
    }

    // this positions the new object relative to camera
    void OnSelectNextToCamera()
	{
		var direction = Camera.main.transform.forward;

		var origin = Camera.main.transform.position;

		var position = origin + direction * Distance;

        var obj = Instantiate(cubeToPlace, position, Quaternion.identity);
        if ( obj is GameObject)
        {
            (obj as GameObject).SendMessage("OnSelect");
        }
	}

}