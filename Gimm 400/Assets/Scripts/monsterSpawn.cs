using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        print(currentPoint.name);
        spawnIt();
    }
    void spawnIt()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Vector3 origin = currentPoint.transform.position;
            Vector3 range = transform.localScale * 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                              Random.Range(1, 1),
                                              Random.Range(-range.z, range.z));

            Vector3 randomCoordinate = origin + randomRange;

            float randomRotation = Random.Range(-180, 180);
            float randomSize = Random.Range(0.6f, 1);

            GameObject mon = PhotonNetwork.InstantiateSceneObject("mr_fuzz", randomCoordinate, Quaternion.Euler(0, randomRotation, 0), 0, null);
            mon.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        }
    }

}
