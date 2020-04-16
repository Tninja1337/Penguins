using UnityEngine;
using System.Collections;

public class Sniper : Gun {

    public GameObject projectile;
    public GameObject spawnBullet;
    Rigidbody rb;

    override protected void Update() {
		base.Update();
		// Shotgun & Pistol have semi-auto fire rate
		if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) 
			> fireRate) {
			lastFireTime = Time.time;
			Fire();

            if (ammo.HasAmmo(tag))
            {
                // Instantiate the projectile at the position and rotation of this transform
                //GameObject clone;

                var clone = Instantiate(projectile, spawnBullet.transform.position, spawnBullet.transform.rotation);
                clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 70;
            }
        }
	}
}
