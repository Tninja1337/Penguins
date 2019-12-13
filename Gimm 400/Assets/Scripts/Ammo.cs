using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ammo : MonoBehaviour {

	[SerializeField]
	GameUI gameUI;

	[SerializeField]
	private int sniperAmmo = 5;
	public Dictionary<string, int> tagToAmmo;

	void Awake() {
	  tagToAmmo = new Dictionary<string, int> {
	    
			{Constants.Sniper, sniperAmmo}
	  };
	}

	public void AddAmmo(string tag, int ammo) {
	  if (!tagToAmmo.ContainsKey(tag)) {
	    Debug.LogError("Unrecognized gun type passed: " + tag);
	  }

	  tagToAmmo[tag] += ammo;
	}

	public bool HasAmmo(string tag) {
		if (!tagToAmmo.ContainsKey(tag)) {
		  Debug.LogError("Unrecognized gun type passed: " + tag);
		}

		return tagToAmmo[tag] > 0;
	}

	public int GetAmmo(string tag) {
	  if (!tagToAmmo.ContainsKey(tag)) {
	    Debug.LogError("Unrecognized gun type passed:" + tag);
	  }

	  return tagToAmmo[tag];
	}

	public void ConsumeAmmo(string tag) {
		if (!tagToAmmo.ContainsKey (tag)) {
			Debug.LogError ("Unrecognized gun type passed:" + tag);
		}
			Debug.Log ("Consuming ammo" + tag);
	  tagToAmmo[tag]--;
		gameUI.SetAmmoText (tagToAmmo [tag]);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
