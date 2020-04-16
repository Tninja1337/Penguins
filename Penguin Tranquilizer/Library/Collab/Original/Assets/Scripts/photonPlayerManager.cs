using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class photonPlayerManager : MonoBehaviour
{
    public GameObject snow;
    PhotonView photonView;


    public Behaviour[] componentsToDisable;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            snow.SetActive(false);
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
                CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
                cc.enabled = false; // Turn off the component
                //ui.SetActive(false);


            }

        }

        if (photonView.IsMine)
        {
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
