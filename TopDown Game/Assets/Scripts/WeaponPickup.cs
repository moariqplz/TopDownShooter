using UnityEngine;
using System.Collections;

public class WeaponPickup : Pickup {

	public Weapon weapon;
//	public Transform weaponTrans;

	public override void OnPickup (PlayerController player)
	{
		Debug.Log ("test");
//		weapon = (GameObject)Instantiate (weapon, weaponTrans.position, weaponTrans.rotation);
//		weapon.transform.parent = other.transform;
		player.EquipWeapon(weapon);
		base.OnPickup (player);
	}
}