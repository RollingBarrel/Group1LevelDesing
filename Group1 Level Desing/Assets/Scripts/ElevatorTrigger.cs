using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTrigger : MonoBehaviour
{
    public GameObject endLevelText;
    //private float textTimer = 5.0f;
    //private bool muestraTexto = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //MostrarTexto();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            endLevelText.SetActive(true);
            SceneManager.LoadScene("Mapa entero");
            //muestraTexto = true;
        }
    }

    /*
    void MostrarTexto()
    {
        if(muestraTexto = true)
        {
            // Iniciar la rutina para hacer desaparecer el texto después de un tiempo
            StartCoroutine(EsperarYDesaparecer());
        }
    }

    IEnumerator EsperarYDesaparecer()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(textTimer);

        // Hacer desaparecer el texto
        OcultarTexto();
    }

    void OcultarTexto()
    {
        endLevelText.SetActive(false);
        SceneManager.LoadScene("Test");
    }
    */
}
