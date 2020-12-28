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
        // Start is called before the first frame update
        void Start()
        {
            
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

            }
            //ingredientsGotten++;
        }
    }
}
