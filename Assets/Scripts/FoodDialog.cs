using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDialog : MonoBehaviour
{


    public InteractiveElement button;
    public GameObject panel;
    public InteractiveElement buttonMeal;
    public InteractiveElement buttonVitamin;



    private bool thisOpen;
    // Start is called before the first frame update
    void Start()
    {
        thisOpen = false;
        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed && !thisOpen)
        {
           button.pressed = false;
            thisOpen = true;
           panel.SetActive(true);
           
        }else if(button.pressed && thisOpen)
        {
            button.pressed = false;
            thisOpen = false;
            panel.SetActive(false);
        }

    }
}
