using UnityEngine;
using System.Collections;

public class GunEquipper : MonoBehaviour {

	public static string activeWeaponType;
	public GameObject sniper;

	[SerializeField]
	GameUI gameUI;
	GameObject activeGun;

	[SerializeField]
	Ammo ammo;

	// Use this for initialization
	void Start () {
	activeWeaponType = Constants.Sniper;
	activeGun = sniper;
}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown ("4")) {
			loadWeapon (sniper);
			activeWeaponType = Constants.Sniper;
			gameUI.UpdateReticle ();
		}
	}

	private void loadWeapon(GameObject weapon) {
		sniper.SetActive (false);

	  weapon.SetActive(true);
	  activeGun = weapon;
		gameUI.SetAmmoText (ammo.GetAmmo (activeGun.tag));
	}

	public GameObject GetActiveWeapon() {
  	return activeGun;
	}

}
