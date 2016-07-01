using UnityEngine;
using System.Collections;

public class SpeedPickup : Pickup {

	public float speedIncrease;

	public override void OnPickup (PlayerController player)
	{
		// TODO: Increase our speed!
		player.moveSpeed += speedIncrease;

		// Run the OnPickup function from the parent class
		base.OnPickup (player);
	}

}
