using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    public int hunger;
    [SerializeField]
    public int strength;
    [SerializeField]
    public int careMistake;
    [SerializeField]
    public int currentEvolution;
    [SerializeField]
    public int weight;
    [SerializeField]
    public int days;
    [SerializeField]
    public string name;
    [SerializeField]
    public string initialDate;

    private int hungerRation;


    MatrixEvolution matrix;
    PetMovement movement;
    PetSleeping sleeping;
    private bool serverTime;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        UpdateStatus();
    }


    void UpdateStatus()
    {
        
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 4;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            //updates necesarios
            hunger = PlayerPrefs.GetInt("hunger");
        }

        if (!PlayerPrefs.HasKey("strength"))
        {
            strength = 0;
            PlayerPrefs.SetInt("strength", strength);
        }
        else
        {
            //updates necesarios
            strength = PlayerPrefs.GetInt("strength");
        }

        if (!PlayerPrefs.HasKey("careMistake"))
        {
            careMistake = 0;
            PlayerPrefs.SetInt("careMistake", careMistake);
        }
        else
        {
            //updates necesarios
            careMistake = PlayerPrefs.GetInt("careMistake");
        }

        if (!PlayerPrefs.HasKey("currentEvolution"))
        {
            currentEvolution =0;
            PlayerPrefs.SetInt("currentEvolution", currentEvolution);
        }
        else
        {
            //updates necesarios
            currentEvolution = PlayerPrefs.GetInt("currentEvolution");
        }

        if (!PlayerPrefs.HasKey("weight"))
        {
            weight = 0;
            PlayerPrefs.SetInt("weight", weight);
        }
        else
        {
            //updates necesarios
            weight = PlayerPrefs.GetInt("weight");
        }

        if (!PlayerPrefs.HasKey("days"))
        {
            days =0;
            PlayerPrefs.SetInt("days", days);
        }
        else
        {
            //updates necesarios
            days = PlayerPrefs.GetInt("days");
        }

        if (!PlayerPrefs.HasKey("name"))
        {
            name ="";
            PlayerPrefs.SetString("name", name);
        }
        else
        {
            //updates necesarios
            name = PlayerPrefs.GetString("name");
        }

        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
        }
       
        updateHungry();
        InvokeRepeating("updateDevice", 0f, 30f);
        InvokeRepeating("discountHunger", 0f, 10f);
        //InvokeRepeating("discountHunger", 0f, getHungerTime());
    }

    private void discountHunger()
    {
        hunger -= 1;
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    private void updateHungry()
    {
        TimeSpan ts = getTimeSpan();
        int hungryTime= getHungerTime();
        if ((int)ts.TotalMinutes >= hungryTime)
        {
            int numberDown =(int) ts.TotalMinutes / hungryTime;
            for (int i = 0;i< numberDown; i++)
            {
                hunger -= 1;
            }
        }
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    private int getHungerTime()
    {
        int hungryTime= 0 ;
        switch (currentEvolution)
        {
            case 0:
                hungryTime = 3;
                break;
            case 1:
                hungryTime = 10;
                break;
            case 2:
                hungryTime = 30;
                break;
            case 3:
                hungryTime = 60;
                break;
            case 4:
                hungryTime = 80;
                break;
            default:
                hungryTime = 100;
                break;
        }
        return hungryTime;
    }

    private void UpdateDevice()
    {
        PlayerPrefs.SetString("then",getStringTime());
    }

    private String getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month+"/"+now.Day+"/"+now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    private TimeSpan getTimeSpan()
    {
        return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: probar la implementación del descuento de puntos de hambre llamandolo desde el update
    }
}
