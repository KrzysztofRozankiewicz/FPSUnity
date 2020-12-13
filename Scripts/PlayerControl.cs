using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class PlayerControl : MonoBehaviour
{
    CharacterController x;
    public float playerFast = 20f; // sprint
    public float playerSlow = 7f;
    public float playerJumpPower = 1f;
    public float verticalRotLimit = 90f; 
    float verticalRot = 0; // Default vertical rotation
    float forwardMove; // Forward movement
    float sideMove; // Sideway movement
    float jump;
    public Text gameOver;
    public Text clock;

    public GameObject target;

    public GameObject pistolObject;
    public GameObject machineObject;
    public GameObject grenadeObject;
    public GameObject pistolCross;
    public GameObject machineCross;
    public GameObject grenadeCross;
    bool switchLock = false;

    //Debuging zoom!
    public GameObject cam;
    public GameObject cam2;
    void Start()
    {
        x = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {
        //Weapon switch

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // switch to pistol
            if (grenadeObject.active == true && switchLock == false)
            {

                grenadeObject.active = false;
                pistolObject.active = true;
                grenadeCross.active = false;
                pistolCross.active = true;
                switchLock = true;

            }
            // Switch to machine
            else if (pistolObject.active == true && switchLock == false)
            {
                pistolObject.active = false;
                machineObject.active = true;
                pistolCross.active = false;
                machineCross.active = true;
                switchLock = true;
                cam.GetComponent<Camera>().fieldOfView = 60;
                cam2.GetComponent<Camera>().fieldOfView = 60;
            }
            // switch to grenade
            else if (machineObject.active == true && switchLock == false)
            {
                machineObject.active = false;
                grenadeObject.active = true;
                machineCross.active = false;
                grenadeCross.active = true;
                switchLock = true;
                cam.GetComponent<Camera>().fieldOfView = 60;
                cam2.GetComponent<Camera>().fieldOfView = 60;
            }

        }
        switchLock = false;

        // No targets = win
        target = GameObject.FindGameObjectWithTag("Target");
        if (!target)
        {
            gameOver.text = "You won!";
            StartCoroutine("reset");
        }

        // Looking horizontal
        float horizontRot = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontRot, 0);

        // Looking vertical
        verticalRot -= Input.GetAxis("Mouse Y");
        verticalRot = Mathf.Clamp(verticalRot, -verticalRotLimit, verticalRotLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRot, 0, 0);

        // Movement
        if (x.isGrounded)
        {
            forwardMove = Input.GetAxis("Vertical") * playerSlow;
            sideMove = Input.GetAxis("Horizontal") * playerSlow;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                forwardMove = Input.GetAxis("Vertical") * playerFast;
                sideMove = Input.GetAxis("Horizontal") * playerFast;
            }
        }
        

        // Jump

        jump += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButton("Jump") && x.isGrounded)
        {
            jump = playerJumpPower;
        }

        Vector3 playerMove = new Vector3(sideMove, jump, forwardMove);
        x.Move(transform.rotation * playerMove * Time.deltaTime);

    }

    IEnumerator reset()
    {
        clock.text = "Restarting scene...";
        yield return new WaitForSeconds(5f);
        Application.LoadLevel(Application.loadedLevel);
    }
}
