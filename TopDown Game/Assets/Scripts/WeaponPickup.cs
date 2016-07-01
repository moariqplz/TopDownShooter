using UnityEngine;
using System.Collections;

public class WeaponPickup : Pickup {

	public GameObject weapon;
	public Transform weaponTrans;

	public override void OnPickup (GameObject other)
	{
		Debug.Log ("test");
		weapon = (GameObject)Instantiate (weapon, weaponTrans.position, weaponTrans.rotation);
		weapon.transform.parent = other.transform;
		base.OnPickup (other);
	}
}