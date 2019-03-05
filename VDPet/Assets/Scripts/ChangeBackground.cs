using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{

    public GameObject quad;
    public Texture day;
    public Texture night;
    public InteractiveElement button;

    private Renderer rend;
    public bool isDay;

    void Update()
    {
        if (button.pressed){
            //el control de flujo inferior asegura según el valor del booleano el cambio de textura en el renderer
            if (isDay)
            {
                isDay = false;
                rend.material.mainTexture = night;
            }
            else
            {
                isDay = true;
                rend.material.mainTexture = day;
            }
            button.pressed = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        isDay = true;
        this.rend = quad.GetComponent<Renderer>();
    }
}
