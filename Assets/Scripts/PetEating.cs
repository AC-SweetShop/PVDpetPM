using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetEating : MonoBehaviour
{
    public Pet pet;

    public Texture[] mealsTexture;
    public Texture[] vitamineTexture;

    private GameObject meal;
    private GameObject vitamine;


    public PetMovement petMovement;


    private int foodCount = 0;
    private int vitamCount = 0;

    public GenerateFood generator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("meal"))
        {
            petMovement.isFree = false;
            meal = collision.gameObject;
            gameObject.GetComponent<Animator>().SetBool("isEating", true);
            InvokeRepeating("PetEatingMeal", 0f, 1.5f);
        }

        if (collision.gameObject.CompareTag("vitamine"))
        {
            petMovement.isFree = false;
            vitamine = collision.gameObject;
            gameObject.GetComponent<Animator>().SetBool("isEating", true);
            InvokeRepeating("PetEatingVitamine", 0f, 1.5f);
        }
    }

    private void PetEatingMeal()
    {
        
            if (foodCount < 3)
            {
            
            if (pet.hunger < 4)
            {
                pet.hunger += 1;
            }
                Renderer rend = meal.GetComponent<SpriteRenderer>();
                rend.material.mainTexture = mealsTexture[foodCount];
                foodCount++;
            }
            else
            {
            Destroy(meal);
                CancelInvoke("PetEatingMeal");
                gameObject.GetComponent<Animator>().SetBool("isEating", false);
                petMovement.isFree = true;
                foodCount = 0;
            generator.hasFood = false;
            }
           
        
    }

    private void PetEatingVitamine()
    {
        
            if (vitamCount < 3)
            {
            if (pet.strength < 4)
            {
                pet.strength += 1;
            }
            Renderer rend = vitamine.GetComponent<SpriteRenderer>();
                rend.material.mainTexture = vitamineTexture[vitamCount];
                vitamCount++;
            }
            else
            {
                 Destroy(vitamine);
                CancelInvoke("PetEatingVitamine");
                gameObject.GetComponent<Animator>().SetBool("isEating", false);
                petMovement.isFree = true;
                vitamCount = 0;
                generator.hasVitamine = false;

            }
    }
    
}
