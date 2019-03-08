using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{


    public float speed = 1f;
    public float maxSpeed = 1f;

    public bool grounded;
    public bool isFree = true;

    public PetSleeping sleeping;

    private CheckGround ground;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && isFree && !sleeping.sleep)
        {
            //anadimos al rigidbody del pet una fuerza con un vector a la derecha por la velocidad
            rb2d.AddForce(Vector2.right * speed);
            //limitamos la velocidad, de tal forma que la velocidad en el eje x puede ser maxSpeed positivo o negativo
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            //establecemos una nueva velocidad al rigidbody del pet
            rb2d.velocity = new Vector2(limitedSpeed, 0);

            //si la velocidad en x es mayor que el numero negativo y menor que el positivo se cambia el sentido de la velocidad
            if (rb2d.velocity.x > -0.1f && rb2d.velocity.x < 0.1f)
            {
                //cambiamos el sentido de la velocidad
                speed = -speed;
                //se lo agregamos a la velocidad del rigidbody del pet
                rb2d.velocity = new Vector2(speed, 0);
            }
        }


        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (!isFree || sleeping.sleep)
        {
            rb2d.velocity = new Vector2(0, 0);
        }


    }
}
