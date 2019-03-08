using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washing : MonoBehaviour
{


    public InteractiveElement button;
    public CreateWave generator;
    public GameObject wave;
    private GameObject waveAux;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("poop"))
        {
            GameObject poopAux = collision.gameObject;
            Destroy(poopAux);
        }

        if (collision.gameObject.CompareTag("destroyer"))
        {
            Debug.Log("entra en destroyer");
            Destroy(generator.waveAux);
        }

    }
}
