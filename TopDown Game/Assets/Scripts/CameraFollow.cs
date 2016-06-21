using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float xOffset;
	public float yOffset;
	public float zOffset;

	void LateUpdate() {
		this.transform.position = new Vector3 (target.transform.position.x + xOffset, target.transform.position.y + yOffset, target.transform.position.z + zOffset);
	}
}
