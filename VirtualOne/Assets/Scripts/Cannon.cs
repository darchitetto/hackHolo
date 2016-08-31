//using UnityEngine;
//using System.Collections;
//
//public class Cannon : MonoBehaviour
//{
//	private Rigidbody rigidbody;
//	private bool gravity;
//	private float time; 
//	// Use this for initialization
//	void Start () {
//		rigidbody = this.gameObject.AddComponent<Rigidbody>();
//		gravity = true;
//		time = Time.time;
//	}
//	
//	// Update is called once per frame
//	void FixedUpdate () {
//		if (gravity)
//		{
//			rigidbody.AddForce(Vector3.zero);
//		}
//		else if (Time.time - time > 3)
//		{
//			rigidbody.angularVelocity = Vector3.zero;
//			rigidbody.velocity = Vector3.zero;
//			gravity = !gravity;
//		}
//		else
//		{
//			rigidbody.AddForce(Camera.main.transform.forward*45.0F);
//		}
//	}
//
//	void OnSelect()
//	{
//		gravity = !gravity;
//		time = Time.time;
//	}
//}



// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity;
using UnityEngine;

// Modified MS example 

/// <summary>
/// The TapToPlace class is a basic way to enable users to move objects 
/// and place them on real world surfaces.
/// Put this script on the object you want to be able to move. 
/// Users will be able to tap objects, gaze elsewhere, and perform the
/// tap gesture again to place.
/// This script is used in conjunction with GazeManager, GestureManager,
/// and SpatialMappingManager.
/// </summary>

public partial class Cannon : MonoBehaviour
{
	[Tooltip("Set to attach the object to the world instead of camera.")]
	public bool AttachToWorld = false;

	[Tooltip("Distance in front of camera if AttachToWorld is false.")]
	public float CameraDistance = 2.0f;

	[Tooltip("Attach a rigid body to the gameobject.")]
	public bool AttachRigidBody = true;

	[Tooltip("Show world mesh when placing object")]
	public bool ShowMesh = false;

	[HideInInspector]
	public bool placing = false;


	bool reattachedRigidBody = false;

	private Rigidbody rigidbody = null;
	private bool gravity = true;
	private float time = 0; 
	private Vector3 direction = Vector3.zero;

	public void Placed()
	{
		placing = false;
		if (ShowMesh)
			SpatialMappingManager.Instance.DrawVisualMeshes = false;

		if (reattachedRigidBody)
		{
			rigidbody = gameObject.AddComponent<Rigidbody>();
			reattachedRigidBody = false;
		}
	}

	void Start()
	{
		if (AttachRigidBody && gameObject.GetComponent<Rigidbody>() == null)
		{
			rigidbody = gameObject.AddComponent<Rigidbody>();
		}
	}


	// Called by GazeGestureManager when the user performs a tap gesture.
	void OnSelect()
	{
		if (SpatialMappingManager.Instance != null)
		{
			// On each tap gesture, toggle whether the user is in placing mode.
			placing = !placing;

			// If the user is in placing mode, display the spatial mapping mesh.
			if (placing)
			{
				if (ShowMesh)
					SpatialMappingManager.Instance.DrawVisualMeshes = true;

				var rb = gameObject.GetComponent<Rigidbody>();
				if (rb != null)
				{
					Destroy(rb);
					reattachedRigidBody = true;
					rigidbody = null;
				}
			}
			// If the user is not in placing mode, hide the spatial mapping mesh.
			else
			{
				gravity = false;
				direction = Camera.main.transform.forward;
				time = Time.time;
				Placed();
			}
		}
		else
		{
			Debug.Log("TapToPlace requires spatial mapping.  Try adding SpatialMapping prefab to project.");
		}
	}

	// Update is called once per frame.
	void Update()
	{
		// If the user is in placing mode,
		// update the placement to match the user's gaze.
		if (placing)
		{
			// Do a raycast into the world that will only hit the Spatial Mapping mesh.
			var headPosition = Camera.main.transform.position;
			var gazeDirection = Camera.main.transform.forward;

			RaycastHit hitInfo;

			if (AttachToWorld)
			{
				// this attaches it to the world

				if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
					30.0f, SpatialMappingManager.Instance.LayerMask))
				{
					// Move this object to where the raycast
					// hit the Spatial Mapping mesh.
					// Here is where you might consider adding intelligence
					// to how the object is placed.  For example, consider
					// placing based on the bottom of the object's
					// collider so it sits properly on surfaces.
					this.transform.position = hitInfo.point;

					// Rotate this object to face the user.
					Quaternion toQuat = Camera.main.transform.localRotation;
					toQuat.x = 0;
					toQuat.z = 0;
					this.transform.rotation = toQuat;
				}
			}
			else
			{
				// put in front of camera
				var direction = Camera.main.transform.forward;

				var origin = Camera.main.transform.position;

				var position = origin + direction * CameraDistance;
				this.transform.position = position;

				// Rotate this object to face the user.
				Quaternion toQuat = Camera.main.transform.localRotation;
				toQuat.x = 0;
				toQuat.z = 0;
				this.transform.rotation = toQuat;
			}
		}
	}
	void FixedUpdate () {
		if (rigidbody != null)
		{
			if (gravity)
			{
				rigidbody.AddForce(Vector3.zero);
			}
			else if (Time.time - time > 10)
			{
				rigidbody.angularVelocity = Vector3.zero;
				rigidbody.velocity = Vector3.zero;
				gravity = true;
			}
			else
			{
				rigidbody.AddForce(direction*10.0F);
			}
		}
	}
}
