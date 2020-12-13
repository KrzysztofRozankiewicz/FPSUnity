using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{


    public AudioClip explosionSound;
    AudioSource source;

    float howLong = 3;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        source.PlayOneShot(explosionSound);
    }

    void Update()
    {
        howLong -= Time.deltaTime;
        if (howLong < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
