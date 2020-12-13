using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject grenadeThrowed;
    public GameObject explosion;
    public GameObject spawn;

    public int ammo = 3; // only 3 grenades!

    public float force;
    public float explosionRadius;
    public float explosionDamage;
    public LayerMask explosion_lm;
    AudioSource source;

    public Text ammoText;
    int ammoLeft;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        ammoLeft = ammo;
    }


    void Update()
    {
        //ammoText.text = ammoLeft + "x";

        if (Input.GetButtonDown("Fire1") && ammoLeft > 0)
        {
            
            GameObject grenadeinstance = (GameObject)Instantiate(grenadeThrowed, spawn.transform.position, Quaternion.identity);
            grenadeinstance.GetComponent<Grenade>().damage = explosionDamage;
            grenadeinstance.GetComponent<Grenade>().radius = explosionRadius;
            grenadeinstance.GetComponent<Grenade>().lm = explosion_lm;
            grenadeinstance.GetComponent<Grenade>().explosion = explosion;
            ammoLeft--;

            Rigidbody grenadeRB = grenadeinstance.GetComponent<Rigidbody>();
            grenadeRB.AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
        }
    }
}
