using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManageSceneAfterBossDefeat : MonoBehaviour
{

    public Collider blockAccesToRoom2;
    public Collider blockAccesToRoom5;
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
            Debug.Log("Entering collider!");
            blockAccesToRoom2.enabled = true;
            blockAccesToRoom5.enabled = true;
        }

    }
}
