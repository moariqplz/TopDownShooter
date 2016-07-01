using UnityEngine;
using System.Collections;

public abstract class Pickup : MonoBehaviour {

	private Transform tf;
	[SerializeField] private float rotateSpeed;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		tf.Rotate (Vector3.up * (rotateSpeed * Time.deltaTime));
	}

	// Runs when an object enters the trigger
	void OnTriggerEnter (Collider other) {
		OnPickup (other.gameObject);
	}

	// Virtual means this function is intended to be overwritten in the child class
	public virtual void OnPickup (GameObject other) {
		Destroy (gameObject);
	}
}
