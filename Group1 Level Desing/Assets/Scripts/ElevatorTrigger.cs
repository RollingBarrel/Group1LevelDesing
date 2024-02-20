using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTrigger : MonoBehaviour
{
    public GameObject endLevelText;
    private float textTimer = 3.0f;
    private bool showTxt = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (showTxt == true)
        {
            ShowText();
        }    
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            showTxt = true;
        }
    }

    void ShowText()
    {
            endLevelText.SetActive(true);
            // Init the turine for make disapear the text after a time
            StartCoroutine(WaitAndDissapear());
    }

    IEnumerator WaitAndDissapear()
    {
        // Wait the specified time
        yield return new WaitForSeconds(textTimer);

        HideText();
    }

    void HideText()
    {
        endLevelText.SetActive(false);
        SceneManager.LoadScene("Mapa entero");
    }
}
