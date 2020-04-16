using UnityEngine;
using System.Collections;
using Photon.Pun;

public class Sniper : Gun {

    public GameObject projectile;
    public GameObject spawnBullet;
    Rigidbody rb;
    PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    override protected void Update() {
        base.Update();
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) > fireRate)
        {
            lastFireTime = Time.time; //firerate 
            Fire();

            if (ammo.HasAmmo(tag))
            {
                Debug.Log("5");

                photonView.RPC("RPC_Shoot", RpcTarget.All); //Photon RPC

            }
        }
    }
    [PunRPC]
    void RPC_Shoot()
    {
        //PhotonNetwork.InstantiateSceneObject("Bullet", spawnBullet.transform.position, spawnBullet.transform.rotation, 0);
        var clone = Instantiate(projectile, spawnBullet.transform.position, spawnBullet.transform.rotation); // Instantiate the projectile at the position and rotation of this transform on the network

    }
}
