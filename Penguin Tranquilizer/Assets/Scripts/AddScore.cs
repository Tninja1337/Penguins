using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {
    public GameObject player;
    public GameUI gameUI;
    //public string gameUI;
    public GameObject[] allUI;
    
    int numPenguins;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("UI");
        gameUI = player.GetComponent<GameUI>();

        Debug.Log("Game Start");

        if (allUI == null)
            Debug.Log("allUI is null");
            allUI = GameObject.FindGameObjectsWithTag("Player");
        
        

        foreach(GameObject allUI in allUI)
        {
            Debug.Log("Added UI");

        }

        numPenguins = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet") 

        {
        numPenguins++;
            Debug.Log(numPenguins);
        gameUI.SetScoreText(numPenguins);
        //this.GetComponent<GameUI>().SetScoreText(numPenguins);
            Debug.Log("Adding Score");
            
        }
    }
}
