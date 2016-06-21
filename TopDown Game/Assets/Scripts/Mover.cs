using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public Transform myTransform;
	public float maxRotateSpeed = 45.0f;
	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RotateToLookAt(Vector3 positionToLookAt)
	{

		// Find the vector from this object to the thing I am looking at.
		Vector3 myVector = positionToLookAt - myTransform.position;

		// Find the quaternion that would tell my object to look down that vector
		Quaternion lookRotation = Quaternion.LookRotation( myVector);

		// Chagne my rotation(quaternion) to be partway towards that quaternion
		myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, lookRotation, maxRotateSpeed * Time.deltaTime);



	}
}
