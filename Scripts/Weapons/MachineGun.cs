using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public float range = 500;
    public float damage = 2;
    public AudioClip shotSound;
    AudioSource source;
    public Sprite machineIdle;
    public Sprite machineShot;
    public Sprite machineShot2;
    public float fireRate = 0.03f;
    bool canShoot = true;

    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Input.GetButton("Fire1") && canShoot == true)
        {
            source.PlayOneShot(shotSound);
            StartCoroutine("shot");

            if (Physics.Raycast(ray, out hit, range))
            {
                
                hit.collider.gameObject.SendMessage("MashineHit", damage, SendMessageOptions.DontRequireReceiver);

            }
        }
    }

    IEnumerator shot()
    {
        canShoot = false;
        GetComponent<SpriteRenderer>().sprite = machineShot;
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().sprite = machineShot2;
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().sprite = machineIdle;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
