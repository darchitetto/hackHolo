using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;

public class CubeManager : MonoBehaviour
{
	public GameObject blueCubePrefab;

	GestureRecognizer recognizer;

	void Start()
	{
		recognizer = new GestureRecognizer();

		recognizer.TappedEvent += Recognizer_TappedEvent;

		recognizer.StartCapturingGestures();
	}

	private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
	{
		var direction = headRay.direction;

		var origin = headRay.origin;

		var position = origin + direction * 2.0f;

		Instantiate(blueCubePrefab, position, Quaternion.identity);
	}
}