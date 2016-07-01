using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator animator;

	public float moveSpeed = 5.0f;
	public Transform tf;
	public Transform weaponMountPoint;
	public PlayerData data;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		tf = GetComponent<Transform> ();
		data = GetComponent <PlayerData> ();
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
	public void EquipWeapon(GameObject weaponPrefab)
	{

		//Creating the weapon from prefab
		GameObject newWeapon = Instantiate (weaponPrefab,weaponMountPoint.position,weaponMountPoint.rotation ) as GameObject;

		//Making a child of the mountpoint
		newWeapon.GetComponent<Transform> ().parent = weaponMountPoint;

		//Saving the weapon I have Equiped
		data.weapon = newWeapon.GetComponent<Weapon> ();
	}

	public void UnequipWeapon()
	{
		//Destroy the weapon
		Destroy (data.weapon.gameObject);
		//Save that we have no weapon
		data.weapon = null;
	}
	public void OnAnimatorIK()
	{
		//If no weapon dont worry about using ik for hands
		if (data.weapon == null)
		{
			return;
		}
		//Set IK for each hand
		if (data.weapon.RightHandPosition != null) {
			animator.SetIKPosition (AvatarIKGoal.RightHand, data.weapon.RightHandPosition.position);
			animator.SetIKRotation (AvatarIKGoal.RightHand, data.weapon.RightHandPosition.rotation);
			animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1.0f);
			animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1.0f);
		} else {
			animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 0.0f);
			animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 0.0f);
		}

		if (data.weapon.LeftHandPosition != null) {
			animator.SetIKPosition (AvatarIKGoal.LeftHand, data.weapon.LeftHandPosition.position);
			animator.SetIKRotation (AvatarIKGoal.LeftHand, data.weapon.LeftHandPosition.rotation);
			animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1.0f);
			animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1.0f);
		} else {
			animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 0.0f);
			animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 0.0f);
		}

	}
}
