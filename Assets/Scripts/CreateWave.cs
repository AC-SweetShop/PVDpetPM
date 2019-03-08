using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWave : MonoBehaviour
{

    public InteractiveElement button;
    public GameObject wave;

    private bool created = false;
    public GameObject waveAux;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed && !created)
        {
            button.pressed = false;
            waveAux = Instantiate(wave);
            waveAux.SetActive(true);
            created = true;
        }
        if (created)
        {
            waveAux.GetComponent<Rigidbody2D>().transform.Translate(-Vector3.left * -5 * Time.deltaTime);

        }
    }


}
