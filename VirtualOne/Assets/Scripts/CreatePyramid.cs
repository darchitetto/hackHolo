using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

public class CreatePyramid : MonoBehaviour {


	[Tooltip("Game object to place when tapping")]
	public GameObject startGame;

	public GameObject testToPlace;
	public GameObject taskToPlace;
	public GameObject defectToPlace;
	public GameObject storyToPlace;
	public GameObject epicToPlace;
	public GameObject projectToPlace;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnSelect () {
		
		Instantiate(taskToPlace, new Vector3((float).0, 0, 0), Quaternion.identity);
		Instantiate(taskToPlace, new Vector3((float).25, 0, 0), Quaternion.identity);
		Instantiate(taskToPlace, new Vector3((float).5, 0, 0), Quaternion.identity);
		Instantiate(taskToPlace, new Vector3((float).75, 0, 0), Quaternion.identity);
		Instantiate(taskToPlace, new Vector3((float)1, 0, 0), Quaternion.identity);
		Instantiate(taskToPlace, new Vector3((float)1.25, 0, 0), Quaternion.identity);

		Instantiate(testToPlace, new Vector3((float).125, (float) .25, 0), Quaternion.identity);
		Instantiate(testToPlace, new Vector3((float).375, (float).25, 0), Quaternion.identity);
		Instantiate(testToPlace, new Vector3((float).625, (float).25, 0), Quaternion.identity);
		Instantiate(testToPlace, new Vector3((float).875, (float).25, 0), Quaternion.identity);
		Instantiate(testToPlace, new Vector3((float)1.125, (float).25, 0), Quaternion.identity);

		Instantiate(defectToPlace, new Vector3((float).25, (float).5, 0), Quaternion.identity);
		Instantiate(defectToPlace, new Vector3((float).5, (float).5, 0), Quaternion.identity);
		Instantiate(defectToPlace, new Vector3((float).75, (float).5, 0), Quaternion.identity);
		Instantiate(defectToPlace, new Vector3(1, (float).5, 0), Quaternion.identity);

		Instantiate(storyToPlace, new Vector3((float).375, (float).75, 0), Quaternion.identity);
		Instantiate(storyToPlace, new Vector3((float).625, (float).75, 0), Quaternion.identity);
		Instantiate(storyToPlace, new Vector3((float).875, (float).75, 0), Quaternion.identity);

		Instantiate(epicToPlace, new Vector3((float).5, (float)1, 0), Quaternion.identity);
		Instantiate(epicToPlace, new Vector3((float).75, (float)1, 0), Quaternion.identity);

		Instantiate(projectToPlace, new Vector3((float).6, (float)1.25, 0), Quaternion.identity);

		//Rigidbody rigid = new Rigidbody();
//		Regex r = new Regex(".*\\(Clone\\)$");
//
//		foreach (GameObject o in FindObjectsOfType<GameObject>().Where(o => r.IsMatch(o.name)))
//		{
//			o.AddComponent<Rigidbody>();
//		}
		

	}


}
