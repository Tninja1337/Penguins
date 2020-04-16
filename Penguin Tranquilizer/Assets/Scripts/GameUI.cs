
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	[SerializeField]
	Sprite greenReticle;
	[SerializeField]
	Image reticle;

	[SerializeField]
	private Text ammoText;
	[SerializeField]
	private Text healthText;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text pickupText;
	[SerializeField]
	Player player;

	public void UpdateReticle() {
	  switch (GunEquipper.activeWeaponType) {
		case Constants.Sniper:
			reticle.sprite = greenReticle;
			break;
	    default:
	      return;
	  }
	}
    public void update()
    {
        
    }
	// Use this for initialization
	void Start () {
		SetHealthText (player.health);
	}

	public void SetHealthText(int health) {
		healthText.text = "Health: " + health;
	}

	public void SetAmmoText(int ammo) {
		ammoText.text = "Ammo: " + ammo;
	}
    public int tScore = 0;
	public void SetScoreText(int score) {
        Debug.Log(score);
        tScore = score + tScore;
                    Debug.Log(tScore);

        scoreText.text = "Penguins Tagged: " + tScore;
        if(tScore == 8)
        {
            scoreText.text = "You win!";
        }
	}

	public void SetPickupText(string text) {
		pickupText.GetComponent<Text> ().enabled = true;
		pickupText.text = text;
		//restart coroutine so it doesnt end early
		StopCoroutine("hidePickupText");
		StartCoroutine ("hidePickupText");
	}

	IEnumerator hidePickupText() {
		yield return new WaitForSeconds (4);
		pickupText.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
