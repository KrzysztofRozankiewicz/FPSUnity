using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float range;
    public float damage = 4;
    public AudioClip shotSound;
    AudioSource source;
    public GameObject cam;
    public GameObject cam2;
    public Sprite pistolIdle;
    public Sprite pistolShot;
    public float zoomForce;
    bool zoom = false; 

    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1"))
        {
            source.PlayOneShot(shotSound);
            StartCoroutine("shot");
            
            if (Physics.Raycast(ray, out hit, range))
            {
                hit.collider.gameObject.SendMessage("PistolHit", damage, SendMessageOptions.DontRequireReceiver);

            }
        }
        // zoom
        if (Input.GetButtonDown("Fire2"))
        {
            if (zoom == false)
            {
                cam.GetComponent<Camera>().fieldOfView = 40;
                cam2.GetComponent<Camera>().fieldOfView = 40;
                Debug.Log("ZoomIn");
                zoom = true;
            }
            else if (zoom == true)
            {
                cam.GetComponent<Camera>().fieldOfView = 60;
                cam2.GetComponent<Camera>().fieldOfView = 60;
                Debug.Log("ZoomOut");
                zoom = false;
            }
            
        }
    }

    IEnumerator shot()
    {
        GetComponent<SpriteRenderer>().sprite = pistolShot;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().sprite = pistolIdle;
    }
}
