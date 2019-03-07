using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    int hunger;
    [SerializeField]
    int strength;
    [SerializeField]
    int careMistake;
    [SerializeField]
    int currentEvolution;
    [SerializeField]
    int weight;
    [SerializeField]
    int days;
    [SerializeField]
    string name;


    MatrixEvolution matrix;
    PetMovement movement;
    PetSleeping sleeping;
    private bool serverTime;



    // Start is called before the first frame update
    void Start()
    {
        UpdateStatus();
    }


    void UpdateStatus()
    {
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 0;
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
        else
        {
            //updates necesarios
            name = PlayerPrefs.GetString("name");
        }

        updateHungry();

        if (serverTime)
        {
            updateServer();
        }
        else
        {
            InvokeRepeating("updateDevice", 0f, 30f);

        }
    }

    private void updateHungry()
    {
        TimeSpan ts = getTimeSpan();
        int hungryTime;
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
        hunger -= (int)(ts.TotalMinutes * hungryTime);
    }

    private void UpdateDevice()
    {
        PlayerPrefs.SetString("then",getStringTime());
    }

    private void updateServer()
    {
        throw new NotImplementedException();
    }


    private String getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Day+":"+now.Hour+":"+now.Minute+":"+now.Second
    }
    private TimeSpan getTimeSpan()
    {
        if (serverTime)
        {
            return new TimeSpan();
        }
        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
