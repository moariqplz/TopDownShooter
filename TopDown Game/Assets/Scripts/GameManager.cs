using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Pickup[] arrayOfPickups;
	public GameObject[] weaponPrefabs;
	public PlayerData[] players;


	// Use this for initialization
	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	//
	public void Start () {
		players = FindObjectsOfType<PlayerData> ();
	}

	// Update is called once per frame
	void Update () {
	}
}
