using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bulletBody;
    float delay = 2.0f; //This implies a delay of 2 seconds.
    // Start is called before the first frame update
    public int dMG;
    void Start()
    {
        bulletBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Give the cloned object an initial velocity along the current
        // object's Z axis

        bulletBody.velocity = transform.TransformDirection(Vector3.forward * 70);
        Object.Destroy(gameObject, 30.0f);

    }
    private void OnTriggerEnter(Collider other)
    {
        
        GameObject hit = other.gameObject;
        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            if (this.enabled == true)
            {
                health.TakeDamage(dMG);
                health.TakeDamage(dMG);
                //Debug.Log(other.gameObject.layer);
                this.enabled = false;
            }

        }
        Object.Destroy(gameObject);

    }
}



