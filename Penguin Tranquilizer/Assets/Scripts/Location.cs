using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    private GameObject locationParent;
    private GameObject textBox;
    private Text locationText;
    private bool locationSwitch = true;
    public string locationName;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (locationParent == null)
        {
            locationParent = GameObject.Find("LocationParent");
        }

        if (other.gameObject.tag == "Player" && locationSwitch == true)
        {
            foreach (Transform child in locationParent.transform)
            {
                child.gameObject.SetActive(true); // or false
            }
        }
        textBox = GameObject.Find("LocationText");
        locationText = textBox.GetComponent<Text>();
        locationText.text = locationName;

        locationSwitch = false;
        StartCoroutine("Countdown");
    }

    private void OnTriggerExit(Collider other)
    {
        locationSwitch = true;
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);

        foreach (Transform child in locationParent.transform)
        {
            child.gameObject.SetActive(false); // or false
        }
    }
    

}
