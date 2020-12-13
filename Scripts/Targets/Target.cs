using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public int HP = 10;
    public bool immuneToPistol;
    public bool immuneToMachine;
    public AudioClip hitSound;
    AudioSource source;


    public void PistolHit(int  damage)
    {
        if (immuneToPistol == false)
        {
            HP -= damage;
        }
        if (HP <= 0)
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(hitSound);
            Destroy(this.gameObject);

        }
    }
    public void MashineHit(int damage)
    {
        
        if (immuneToMachine == false)
        {
            HP -= damage;
        }
        if (HP <= 0)
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(hitSound);
            Destroy(this.gameObject);
        }
    }
    public void Damage(int damage)
    {
        HP -= damage; 

        if (HP <= 0)
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(hitSound);
            Destroy(this.gameObject);
        }
    }

}
