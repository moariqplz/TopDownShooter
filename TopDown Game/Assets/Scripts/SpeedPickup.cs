using UnityEngine;
using System.Collections;

public class SpeedPickup : Pickup {

	public float speedIncrease;

	public override void OnPickup (GameObject other)
	{
		// TODO: Increase our speed!
		other.GetComponent<PlayerController>().moveSpeed += speedIncrease;

		// Run the OnPickup function from the parent class
		base.OnPickup (other);
	}

}
