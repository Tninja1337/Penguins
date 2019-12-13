using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PenguinSpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject penguins;

    PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    // Use this for initialization
    void Start()
    {
        spawnPenguin();
    }
    void spawnPenguin()
    {
        int PEN = Random.Range(1, 10);
        //Instantiate random
        //GameObject penguin = Instantiate(penguins);
        //if (PhotonNetwork.isMasterClient == true)
        //{
        //if (!PhotonNetwork.IsMasterClient)
        //return;
        for (var i = 0; i < PEN; i++)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Vector3 origin = transform.position;
                Vector3 range = transform.localScale * 5.0f;
                Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                                  Random.Range(1, 1),
                                                  Random.Range(-range.z, range.z));

                Vector3 randomCoordinate = origin + randomRange;

                float randomRotation = Random.Range(-180, 180);
                float randomSize = Random.Range(0.6f, 1);           

                GameObject peng = PhotonNetwork.InstantiateSceneObject("anamatedPenguin", randomCoordinate, Quaternion.Euler(0, randomRotation, 0), 0, null);
                peng.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            }

            //penguin.transform.position = transform.position;
            //penguin.transform.parent = transform;
            // }
        }
    }
    IEnumerator respawnPenguin()
    {
        yield return new WaitForSeconds(2);
        spawnPenguin();
    }


    public void PickupPickedUp()
    {
        StartCoroutine("respawnPenguin");
    }
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

}