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
        //borramos los playerPrefs como testeo
        PlayerPrefs.DeleteAll();
        currentEvolution = 0;
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
            strength = 4;
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
        InvokeRepeating("discountHunger", 0f, getRatioTime());

        updateStrenght();
        InvokeRepeating("discountStrength", 0f, getRatioTime());


        InvokeRepeating("updateDevice", 0f, 30f);
        //InvokeRepeating("discountHunger", 0f, getHungerTime());
    }


    /**
     * Metodo encargado de sacar el ratio de tiempo que pasa hambre y necesita vitaminas según el estado de evolución
     **/
    private int getRatioTime()
    {
        int ratioTime = 0;
        switch (currentEvolution)
        {
            case 0:
                ratioTime = 180;
                break;
            case 1:
                ratioTime = 600;
                break;
            case 2:
                ratioTime = 1800;
                break;
            case 3:
                ratioTime = 3600;
                break;
            case 4:
                ratioTime = 4800;
                break;
            default:
                ratioTime = 6000;
                break;
        }
        return ratioTime;
    }


    /**
     * Metodo encargado de actualizar el hambre según el último horario
    * registrado en el dispositivo antes de cerrar la aplicación
    * */
    private void updateStrenght()
    {
        TimeSpan ts = getTimeSpan();
        int strengthTime = getRatioTime();
        if ((int)ts.TotalMinutes >= strengthTime)
        {
            //cantidad de veces que se ha pasado el tiempo de hambre
            int numberDown = (int)ts.TotalMinutes / strengthTime;
            for (int i = 0; i < numberDown; i++)
            {
                strength -= 1;
            }
        }
        if (strength < 0)
        {
            strength = 0;
        }
    }
    /**
    * Metodo encargado de descontar unidades de hambre. Este metodo se llamará desde
    * el método UpdateStatus(), de tal forma que se repetirá cada "n" tiempo
    * donde n se obtiene del metodo getHungerTime()
    * */
    private void discountStrength()
    {
        strength -= 1;
        if (strength < 0)
        {
            strength = 0;
        }
    }


    /**
     * Metodo encargado de actualizar el hambre según el último horario
     * registrado en el dispositivo antes de cerrar la aplicación
     * */
    private void updateHungry()
    {
        TimeSpan ts = getTimeSpan();
        int hungryTime = getRatioTime();
        if ((int)ts.TotalMinutes >= hungryTime)
        {
            //cantidad de veces que se ha pasado el tiempo de hambre
            int numberDown = (int)ts.TotalMinutes / hungryTime;
            for (int i = 0; i < numberDown; i++)
            {
                hunger -= 1;
            }
        }
        if (hunger < 0)
        {
            hunger = 0;
        }
    }
    /**
     * Metodo encargado de descontar unidades de hambre. Este metodo se llamará desde
     * el método UpdateStatus(), de tal forma que se repetirá cada "n" tiempo
     * donde n se obtiene del metodo getHungerTime()
     * */
    private void discountHunger()
    {
        hunger -= 1;
        if (hunger < 0)
        {
            hunger = 0;
        }
    }


    /**
     * Metodo encargado de actualizar la fecha del sistema en la información del juego
     * para actualizar los valores en caso de desconexión
     * */
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
