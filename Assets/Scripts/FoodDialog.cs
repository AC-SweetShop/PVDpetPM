using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDialog : MonoBehaviour
{


    public InteractiveElement button;
    public GameObject panel;
    public InteractiveElement buttonMeal;
    public InteractiveElement buttonVitamin;


    private bool dialogOpen;
    // Start is called before the first frame update
    void Start()
    {
        dialogOpen = false;
        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed && !dialogOpen)
        {
           button.pressed = false;
            dialogOpen = true;
           panel.SetActive(true);
           
        }else if(button.pressed && dialogOpen)
        {
            button.pressed = false;
            dialogOpen = false;
            panel.SetActive(false);
        }
    }
}
