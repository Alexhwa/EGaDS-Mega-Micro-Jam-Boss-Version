using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class SideMovement : MonoBehaviour
    {
        private float horizontal;
        public float moveSpeed;
        public Rigidbody2D rb;

        private bool stunned;

        [Header("Cup Collision")]
        private int ingredientsGotten;
        private const int requiredIngredients = 5;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GotIngredient(collision.gameObject.GetComponent<Ingredient>());
        }

        private void FixedUpdate()
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
            }
            else
            {
                horizontal = 0;
            }

            var newVel = rb.velocity;
            newVel.x = horizontal * moveSpeed;
            rb.velocity = newVel;
        }

        public void GotIngredient(Ingredient ingredient)
        {
            if (ingredient.dangerous)
            {
                Stun();
            }
            else
            {
                ingredientsGotten++;
                if(ingredientsGotten == requiredIngredients)
                {
                    Stage1.instance.gameEnd.Invoke();
                }
            }
            Destroy(ingredient.gameObject);
        }
        private void Stun()
        {

        }
    }
}
