using UnityEngine;
using System.Collections;
using System.Linq;

// Something to think about
[System.Serializable]
public class WeaponSlot
{
	public Weapon weaponPrefab;
	public bool acquired = false;
	public int bullets = 0;
	public int magazines = 0;
}

public class PlayerData : MonoBehaviour {

	public WeaponSlot[] slots;

	public Weapon weapon;

	// Use this for initialization
	void Start () {

		Weapon prefab;

		WeaponSlot selected = slots.FirstOrDefault (slot => slot.weaponPrefab == prefab);
		if (selected != null) {
			// Equip weapon
			selected.bullets += 100;
			selected.magazines = 10;
		}

	}

	public void EquipSlot(WeaponSlot slot)
	{
		Weapon spawnedWeapon = Instantiate (slot.weaponPrefab) as Weapon;

		// Set position, parent, etc

//		spawnedWeapon.ammoCount = slot.bullets;
//		spawnedWeapon.magazines = slot.magazines;

		spawnedWeapon.data = slot;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
