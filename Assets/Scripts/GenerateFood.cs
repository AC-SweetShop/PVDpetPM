using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour
{

    public GameObject meal;
    public GameObject vitamin;

    public InteractiveElement buttonMeal;
    public InteractiveElement buttonVitamine;

    public bool hasFood;
    public bool hasVitamine;


    // Start is called before the first frame update
    void Start()
    {
        hasFood = false;
        hasVitamine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonMeal.pressed && !hasFood)
        {
            hasFood = true;
            GameObject mealAux = Instantiate(meal);
            mealAux.SetActive(true);
        }
        buttonMeal.pressed = false;


        if (buttonVitamine.pressed && !hasVitamine)
        {
            hasVitamine = true;
            GameObject vitamineAux = Instantiate(vitamin);
            vitamineAux.SetActive(true);
        }
        buttonVitamine.pressed = false;


    }
}
