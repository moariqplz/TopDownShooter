using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator animator;

	public float moveSpeed = 5.0f;
	public Transform tf;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveVector = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		moveVector = Vector3.ClampMagnitude (moveVector, 1);
		moveVector *= moveSpeed;
		//turn this move vector from local to my character into world direction
		moveVector = tf.InverseTransformDirection(moveVector);
		// change the values in the animator based on my inputs

		animator.SetFloat("Horizontal", moveVector.x);
		animator.SetFloat("Vertical", moveVector.z);

		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) {
			animator.SetBool ("Sprinting", true);
		}
		if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift)) {
			animator.SetBool ("Sprinting", false);
		}
		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown (KeyCode.RightControl)) {
			animator.SetBool ("Crouching", true);
		}
		if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp (KeyCode.RightControl)) {
			animator.SetBool ("Crouching", false);
		}
	}
}
