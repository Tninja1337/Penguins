using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Game game;
	public AudioClip playerDead;
	public int health;
	public GameUI gameUI;
	private GunEquipper gunEquipper;
	private Ammo ammo;

	// Use this for initialization
	void Start () {
		ammo = GetComponent<Ammo> ();
		gunEquipper = GetComponent<GunEquipper> ();
	}

	public void TakeDamage(int amount) {
		int healthDamage = amount;

		health -= healthDamage;
		gameUI.SetHealthText (health);

		if (health <= 0) {
			GetComponent<AudioSource> ().PlayOneShot (playerDead);
			game.GameOver ();
		}
	}

	private void pickupHealth() {
        health += 50;
        if (health > 200) {
            health = 200;
        }

		gameUI.SetPickupText ("Pickup: + Health");
		gameUI.SetHealthText(health);
	}

	private void pickupSniperAmmo() {
		ammo.AddAmmo (Constants.Sniper, 5);
		gameUI.SetPickupText ("Pickup: Ammo +5");
		if (gunEquipper.GetActiveWeapon ().tag == Constants.Sniper) {
			gameUI.SetAmmoText (ammo.GetAmmo (Constants.Sniper));
		}
	}

	public void PickUpItem(int pickupType) {
		switch (pickupType) {
		case Constants.PickUpHealth:
			pickupHealth ();
			break;
		case Constants.PickUpSniperAmmo:
			pickupSniperAmmo ();
			break;
		default:
			Debug.LogError ("Bad pickup type passed " + pickupType);
			break;
		}
	}


}
