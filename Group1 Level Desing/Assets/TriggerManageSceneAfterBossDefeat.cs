using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManageSceneAfterBossDefeat : MonoBehaviour
{
    public Collider blockAccesToRoom2;
    public Collider blockAccesToRoom5;
    public GameObject activeParticle;
    public GameObject elevatorDoor;
    public GameObject room5_Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            activeParticle.SetActive(true);
            blockAccesToRoom2.enabled = true;
            blockAccesToRoom5.enabled = true;
            elevatorDoor.GetComponent<AutomaticDoors>().locked = false;
            room5_Door.GetComponent<AutomaticDoors>().locked = true;
        }

    }
}
