using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveElement : MonoBehaviour, IPointerClickHandler
{


    public bool pressed;

    public void OnPointerClick(PointerEventData eventData)
    {
        pressed = true;
    }




}
