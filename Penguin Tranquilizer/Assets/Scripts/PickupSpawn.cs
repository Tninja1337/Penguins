using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {

	[SerializeField]
	private GameObject[] pickups;

	void spawnPickup() {
		//Instantiate random
		GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
		pickup.transform.position = transform.position;
		pickup.transform.parent = transform;
	}

	IEnumerator respawnPickup() {
		yield return new WaitForSeconds (20);
		spawnPickup();
	}
	// Use this for initialization
	void Start () {
		spawnPickup ();
	}
	
	public void PickupPickedUp() {
		StartCoroutine ("respawnPickup");
	}
}
