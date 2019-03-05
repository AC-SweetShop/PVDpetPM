using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSleeping : MonoBehaviour
{
    private Animator anim;
    public InteractiveElement lightButton;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightButton.pressed)
        {
            anim.SetBool("isSleep", true);
        }
        else
        {
            anim.SetBool("isSleep", false);
        }
        
    }
}
