using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetEating : MonoBehaviour
{
    public Pet pet;

    public Texture[] vitamineTexture;

    private GameObject meal;
    private GameObject vitamine;

    public RuntimeAnimatorController mealAnimation;
    public RuntimeAnimatorController vitamineAnimation;

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
            gameObject.GetComponent<Animator>().SetBool("isEating", true);


            meal = collision.gameObject;
            meal.GetComponent<Rigidbody2D>().velocity= new Vector2(0,0);
            meal.GetComponent<Animator>().runtimeAnimatorController = mealAnimation;
            Invoke("PetEatingMeal", 3f);
            
        }

        if (collision.gameObject.CompareTag("vitamine"))
        {
            petMovement.isFree = false;
            gameObject.GetComponent<Animator>().SetBool("isEating", true);


            vitamine = collision.gameObject;
            vitamine.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            vitamine.GetComponent<Animator>().runtimeAnimatorController = vitamineAnimation;
            Invoke("PetEatingVitamine",3f);
        }
    }

    private void PetEatingMeal()
    {           
        if (pet.hunger < 4)
        {
            pet.hunger += 1;
        }
        Destroy(meal);
        gameObject.GetComponent<Animator>().SetBool("isEating", false);
        petMovement.isFree = true;
        generator.hasFood = false;


    }

    private void PetEatingVitamine()
    {

        if (pet.strength < 4)
        {
            pet.strength += 1;
        }
        Destroy(vitamine);
        gameObject.GetComponent<Animator>().SetBool("isEating", false);
        petMovement.isFree = true;
        generator.hasVitamine = false;

    }

}
