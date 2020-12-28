﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class SideMovement : MonoBehaviour
    {
        private float horizontal;
        public float moveSpeed;
        public Rigidbody2D rb;
        public float dampenFactor = 1.2f;
        private bool stunned;
        public float stunTime;
        public Animator anim;

        [Header("Cup Collision")]
        private int ingredientsGotten;
        private const int requiredIngredients = 6;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var possibleIngredient = collision.gameObject.GetComponent<Ingredient>();
            if(possibleIngredient != null)
            {
                GotIngredient(possibleIngredient);
            }
        }

        private void FixedUpdate()
        {
            if (!stunned)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    horizontal = -1;
                    var newVel = rb.velocity;
                    newVel.x = horizontal * moveSpeed;
                    rb.velocity = newVel;
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    horizontal = 1;
                    var newVel = rb.velocity;
                    newVel.x = horizontal * moveSpeed;
                    rb.velocity = newVel;
                }

                if (Mathf.Abs((Input.GetAxis("Horizontal"))) < .5f || !Input.anyKey)
                {
                    var dampVel = rb.velocity / dampenFactor;
                    rb.velocity = dampVel;
                }
            }
            else
            {
                var dampVel = rb.velocity / dampenFactor;
                rb.velocity = dampVel;
            }
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
            if (stunned == false)
            {
                stunned = true;
                anim.SetBool("Stunned", stunned);
                StartCoroutine(ResetStunned(stunTime));
            }
        }
        private IEnumerator ResetStunned(float delay)
        {
            yield return new WaitForSeconds(delay);
            stunned = false;
            anim.SetBool("Stunned", stunned);
        }
    }
}