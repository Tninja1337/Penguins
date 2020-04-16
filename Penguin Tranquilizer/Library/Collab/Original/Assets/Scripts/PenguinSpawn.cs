using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpawn : MonoBehaviour
{

	[SerializeField]
	private GameObject penguins;

	void spawnPenguin()
	{
		//Instantiate random
		//GameObject penguin = Instantiate(penguins);

        PhotonNetwork.InstantiateSceneObject("anamatedPenguin", gameObject.transform.position, gameObject.transform.rotation);
        
	}

	IEnumerator respawnPenguin()
	{
		yield return new WaitForSeconds(2);
		spawnPenguin();
	}
	// Use this for initialization
	void Start()
	{
		spawnPenguin();
	}

	public void PickupPickedUp()
	{
		StartCoroutine("respawnPenguin");
	}
}