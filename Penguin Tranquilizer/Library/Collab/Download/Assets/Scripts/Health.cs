using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using static PenguinAI;

public class Health : MonoBehaviour {

	//public const int maxHealth = 100;
    public int currentHealth;
	//public RectTransform healthBar; 
	public bool destroyOnDeath;
    public GameObject parentOBJ;
    public PenguinAI penguinAI;

    void Start(){

        
	}

	public void TakeDamage(int amount){
        


		currentHealth -= amount;

		if (currentHealth <= 0) {
            
			if (destroyOnDeath) {

                penguinAI.currentState = AIState.Dead;
                Destroy (gameObject);
                this.enabled = false;
            } 
			else {
				//currentHealth = maxHealth;
			}

		}

	}

    public void Update()
    {
        
    }

    void OnChangeHealth(int health){
        currentHealth = health;
		//healthBar.sizeDelta = new Vector2 (currentHealth * .02f, healthBar.sizeDelta.y);
        //healthBar.position = new Vector2(health * 2, healthBar.position.y);

    }

}
