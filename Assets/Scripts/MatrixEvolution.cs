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
    public Pet petStats;


    public void Start()
    {
        phase = -1;

    }

    public void Update()
    {
        if (evolve)
        {
            evolve = false;
            phase++;
            pet.GetComponent<Animator>().runtimeAnimatorController = evolveLine[phase];
            petStats.currentEvolution = phase;
        }
    }

    public int getPhase(){
      return phase;
    }
}
