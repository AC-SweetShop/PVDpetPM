using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSleeping : MonoBehaviour
{
    private Animator anim;
    public ChangeBackground sky;

    private bool sleep;
    // Start is called before the first frame update
    void Start()
    {
        sleep = true;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sky.isDay && sleep)
        {
            anim.SetBool("isSleep", false);
            sleep = false;
        }
        
        if(!sky.isDay && !sleep)
        {
            anim.SetBool("isSleep", true);
            sleep = true;
        }
        
    }
}
