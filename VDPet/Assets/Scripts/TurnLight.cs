using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnLight : MonoBehaviour, IPointerDownHandler
{

    public GameObject quad;
    public Texture day;
    public Texture night;

    private Renderer rend;
    public bool isDay;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
     
    }

    void Update()
    {
        if (Input.touches.Length <= 0)
        {
            //si no se toca la pantalla no hará nada.
        }
        else
        {
            if (isDay)
            {
                isDay = false;
            }
            else
            {
                isDay = true;
            }
        }

        //el control de flujo inferior asegura según el valor del booleano el cambio de textura en el renderer
        if (isDay)
        {
            rend.material.mainTexture = day;
        }
        else
        {
            rend.material.mainTexture = night;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        isDay = true;
        //addPhysics2DRaycaster();
        this.rend = quad.GetComponent<Renderer>();
    }

   /*
    void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
    */

 


}
