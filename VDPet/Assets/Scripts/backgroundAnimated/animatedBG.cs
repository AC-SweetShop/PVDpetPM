using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedBG : MonoBehaviour
{

    public float speed = 1f; 
    void Start()
    {
        
    }

    void Update()
    {
        moveImage();
    }

void moveImage(){
    transform.Translate (-speed * Time.deltaTime,0,0); 
}
}
