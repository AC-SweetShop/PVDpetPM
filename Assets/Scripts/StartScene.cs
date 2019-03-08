using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
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
            if (PlayerPrefs.HasKey("currentEvolution"))
            {
                SceneManager.LoadScene("interfaz-principal-animada");

            }
            else
            {
                SceneManager.LoadScene("seleccion-digimon");

            }
        }
    }
}
