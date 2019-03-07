using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixEvolution : MonoBehaviour
{
    public RuntimeAnimatorController[] evolveLine = new RuntimeAnimatorController[24];

  //  public Stats stats;
    public bool evolve = false;
    private int phase = 0;
    public GameObject pet;
    private BoxCollider collider;


    public void Start()
    {
        /*
       if(stats.line == "first")
        {

        }
        else if(stats.line == "second")
        {

        }
        */
    }

    public void Update()
    {
        if (evolve)
        {
            evolve = false;
            phase++;
            pet.GetComponent<Animator>().runtimeAnimatorController = evolveLine[phase];
            /*
            //obtenemos el tamano del sprite
            Vector3 size = pet.GetComponent<SpriteRenderer>().sprite.rect.size;

            //modificamos el collider.
            var collider = pet.GetComponent<BoxCollider2D>();
            collider.size = size;
            */

        }
    }
}
