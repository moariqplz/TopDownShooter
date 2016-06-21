using UnityEngine;
using System.Collections;

public class PlanecastTest : MonoBehaviour {

	public Transform testSphere;
	public Transform playerTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetButtonDown ("Fire1")) 
		//{
			// Create a plane at the players feet
			Plane feetPlane = new Plane(Vector2.up, playerTransform.position);

			// Create a ray from the mouse pos in the direction the camera is facing
			Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition); //bottem left is 0,0 pixel location

			// Check if that ray hits the plane (if so, save the distance along the ray that we hit)
			float distance;
			feetPlane.Raycast (myRay, out distance);

			// Move sphere to a point on the ray at that distance
			testSphere.position = myRay.GetPoint(distance);

			//rotate our player to look at the position
			playerTransform.gameObject.GetComponent<Mover>().RotateToLookAt(testSphere.position);
		//}
	}
}
