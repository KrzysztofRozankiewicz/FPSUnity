using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public LayerMask lm;
    public GameObject explosion;
    public AudioClip explosionSound;

    public float damage;
    public float radius;
    public float delay = 5; 

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Collider[] hitColliders = Physics.OverlapSphere(contact.point, radius, lm);
        // Creating boom
        GameObject explosionInstantiate = (GameObject)Instantiate(explosion, contact.point, Quaternion.identity);
        explosionInstantiate.GetComponent<Boom>().explosionSound = explosionSound;

        foreach(Collider col in hitColliders)
        {
            col.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
        }
        Destroy(this.gameObject);
    }
}
