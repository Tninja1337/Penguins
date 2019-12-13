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
        Debug.Log("1");
        base.Update();
        Debug.Log("2");
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) > fireRate)
        {
            Debug.Log("3");
            lastFireTime = Time.time;
            Fire();
            Debug.Log("4");

            if (ammo.HasAmmo(tag))
            {
                Debug.Log("5");
                // Instantiate the projectile at the position and rotation of this transform
                //GameObject clone;

                photonView.RPC("RPC_Shoot", RpcTarget.All);

                //GameObject test = PhotonNetwork.InstantiateSceneObject("Bullet", spawnBullet.transform.position, spawnBullet.transform.rotation, 0);
                //var clone = Instantiate(projectile, spawnBullet.transform.position, spawnBullet.transform.rotation);
                //clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 70;
            }
        }
    }
    [PunRPC]
    void RPC_Shoot()
    {
        //PhotonNetwork.InstantiateSceneObject("Bullet", spawnBullet.transform.position, spawnBullet.transform.rotation, 0);
        var clone = Instantiate(projectile, spawnBullet.transform.position, spawnBullet.transform.rotation);

    }
}
