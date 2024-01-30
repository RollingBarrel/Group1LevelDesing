using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoors : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public Transform leftClosedLocation;
    public Transform rightClosedLocation;
    public Transform leftOpenLocation;
    public Transform rightOpenLocation;

    public AudioSource doorSound;
    public AudioSource doorClosedSound;
    //private Shooter shooter;
    //private ThirdPersonController thirdPersonController;

    public float speed = 1.0f;

    bool isOpening = false;
    bool isClosing = false;
    Vector3 distance;

    public bool locked = false; // Indica si necesitamos algún elemento (llave o acción) para desbloquear la puerta

    private void Awake()
    {
        //shooter = GameObject.Find("FPSController").GetComponent<Shooter>();
        //thirdPersonController = GameObject.Find("PlayerArmature").GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        if (isOpening)
        {
            distance = leftDoor.localPosition - leftOpenLocation.localPosition;

            if (distance.magnitude < 0.001f)
            {
                isOpening = false;
                leftDoor.localPosition = leftOpenLocation.localPosition;
                rightDoor.localPosition = rightOpenLocation.localPosition;
            }
            else
            {
                leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftOpenLocation.localPosition, Time.deltaTime * speed);
                rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightOpenLocation.localPosition, Time.deltaTime * speed);
            }
        }
        else if (isClosing)
        {
            distance = leftDoor.localPosition - leftClosedLocation.localPosition;

            if (distance.magnitude < 0.001f)
            {
                isClosing = false;
                leftDoor.localPosition = leftClosedLocation.localPosition;
                rightDoor.localPosition = rightClosedLocation.localPosition;
            }
            else
            {
                leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftClosedLocation.localPosition, Time.deltaTime * speed);
                rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightClosedLocation.localPosition, Time.deltaTime * speed);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (locked == false)
        {
            doorSound.Play();
            isOpening = true;
            isClosing = false;
        }
        else
        {
            //shooter.Message("YOU MUST KILL ALL THE ENEMIES TO UNLOCK THE EXIT ELEVATOR DOOR");
            doorClosedSound.Play();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (locked == false)
        {
            isOpening = true;
            isClosing = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (locked == false)
        {
            doorSound.Play();
            isClosing = true;
            isOpening = false;
        }
    }
}