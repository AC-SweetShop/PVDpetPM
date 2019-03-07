using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEgg : MonoBehaviour
{

  public InteractiveElement button;
  public GameObject pet;
  public GameObject egg;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      if(button.pressed){
        Debug.Log("entra");
        button.pressed = false;
        pet.SetActive(true);
        Destroy(egg);
        Destroy(button);
      }
    }
}
