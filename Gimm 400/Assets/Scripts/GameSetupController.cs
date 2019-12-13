using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameSetupController : MonoBehaviour
{
    public static GameSetupController GS;
    public Transform[] spawnPoints;
    PhotonView photonView;
    public GameObject myAvatar;
    void Awake()
    {
       // photonView = GetComponent<PhotonView>();
    }
    // This script will be added to any multiplayer scene
    void Start()
    {
        
        int spawnPicker = Random.Range(0, GameSetupController.GS.spawnPoints.Length);
            myAvatar=PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"),
                GameSetupController.GS.spawnPoints[spawnPicker].position,
                GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
        //CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
    }
    private void OnEnable()
    {
        if (GameSetupController.GS == null)
        {
            GameSetupController.GS = this;
        }
    }
    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
    }
    private void Update()
    {
        //Debug.Log(photonView);
    }
}