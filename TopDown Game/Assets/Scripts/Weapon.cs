using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float shotsPerSecond;
	public AudioClip fireSound;
	public int ammoCount;
	public int maxAmmo;

	public Transform RightHandPosition;
	public Transform LeftHandPosition;
	public Transform RightElbowPosition;
	public Transform LeftElbowPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
