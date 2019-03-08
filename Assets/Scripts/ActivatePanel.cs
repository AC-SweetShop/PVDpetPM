using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePanel : MonoBehaviour
{

    public Pet pet;
    public GameObject panel;
    public InteractiveElement panelButton;
    public InteractiveElement button;
    public Text name;
    public Text hunger;
    public Text strength;
    public Text mistake;
    public Text evolutionLvl;

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed)
        {
            button.pressed = false;
            name.text = "NAME:";
            hunger.text = "HUNGER:  ";
            strength.text = "STRENGTH: ";
            mistake.text = "C-M:";
            evolutionLvl.text = "EVOLUTION LVL:  ";
            name.text += pet.name;
            hunger.text += "  "+pet.hunger + "  /  4  MAX";
            strength.text += "  " + pet.strength +"  /  4  MAX";
            mistake.text += "  "+ pet.careMistake;
            evolutionLvl.text += pet.currentEvolution;
            panel.SetActive(true);
        }
        if (panelButton.pressed)
        {
            panelButton.pressed = false;
            panel.SetActive(false);
        }
    }
}
