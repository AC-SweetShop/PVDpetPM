using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour
{

    public InteractiveElement button;
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
            PlayerPrefs.DeleteAll();

        }
    }
}
