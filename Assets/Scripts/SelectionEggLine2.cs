using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionEggLine2 : MonoBehaviour
{
    public InteractiveElement button;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed)
        {
            button.pressed = false;
            SceneManager.LoadScene("interfaz-principal-animada-egg");
        }
    }
}
