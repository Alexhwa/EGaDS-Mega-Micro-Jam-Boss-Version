using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BeeNice {

    public class ArrowController : MonoBehaviour
    {
        public SpriteRenderer leftArrow;
        public SpriteRenderer rightArrow;
        public Sprite leftInactive;
        public Sprite rightInactive;
        public Sprite leftActive;
        public Sprite rightActive;

        //Tap Variables
        private int tapInterval;
        public int tapStrength;
        public Animator chefFireAnim;
        public Animator rivalFireAnim;
        public Animator chef;
        public Animator rival;
        //Fire thresholds
        public int flameThresholdMid;
        public int flameThresholdSmall;
        public int flameThresholdNone;
        //Win/Lose conditions
        private int tapCount;
        public int requiredTaps;
        public float loseTime;
        private float loseTimeSlice;
        private bool gameOver;

        private UnityEvent onKeyChange;


        private ArrowActive curArrow = ArrowActive.Left;
        private enum ArrowActive
        {
            Left, Right
        }

        private FireState fireState = FireState.None;
        private enum FireState
        {
            None, Small, Medium, Big
        }
        // Start is called before the first frame update
        void Start()
        {
            tapInterval = flameThresholdNone + 1;
            onKeyChange = new UnityEvent();
            onKeyChange.AddListener(ChangeArrow);
            loseTimeSlice = loseTime / 4; //Because there are 4 fire states
        }

        // Update is called once per frame
        void Update()
        {
            loseTime = loseTime - Time.deltaTime;

            if (Input.GetAxis("Horizontal") > 0 && curArrow == ArrowActive.Left)
            {
                curArrow = ArrowActive.Right;
                tapCount++;
                onKeyChange.Invoke();
                if (tapInterval > 0)
                {
                    tapInterval -= tapStrength;
                }
            }
            else if (Input.GetAxis("Horizontal") < 0 && curArrow == ArrowActive.Right)
            {
                curArrow = ArrowActive.Left;
                tapCount++;
                onKeyChange.Invoke();
                if (tapInterval > 0)
                {
                    tapInterval -= tapStrength;
                }
            }

            if (tapInterval < flameThresholdMid)
            {
                fireState = FireState.Big;
            }
            else if (tapInterval >= flameThresholdMid && tapInterval < flameThresholdSmall)
            {
                fireState = FireState.Medium;
            }
            else if (tapInterval >= flameThresholdSmall && tapInterval < flameThresholdNone)
            {
                fireState = FireState.Small;
            }
            else if (tapInterval >= flameThresholdSmall)
            {
                fireState = FireState.None;
            }
            chefFireAnim.SetInteger("FireState", (int)fireState);
            chef.SetFloat("AnimSpeed", (int)fireState);

            if (tapCount >= requiredTaps && !gameOver)
            {
                gameOver = true;
                Stage2.instance.gameEnd.Invoke();
            }

            //Rival chef's flame
            if (loseTime < loseTimeSlice * 1)
            {
                rivalFireAnim.SetInteger("FireState", 3);
                rival.SetFloat("AnimSpeed", 3);
            }
            else if (loseTime < loseTimeSlice * 2)
            {
                rivalFireAnim.SetInteger("FireState", 2);
                rival.SetFloat("AnimSpeed", 2);
            }
            else if (loseTime < loseTimeSlice * 3)
            {
                rivalFireAnim.SetInteger("FireState", 1);
                rival.SetFloat("AnimSpeed", 1);
            }
            else
            {
                rivalFireAnim.SetInteger("FireState", 0);
                rival.SetFloat("AnimSpeed", 0);
            }
        }
        private void FixedUpdate()
        {
            if (tapInterval < flameThresholdNone + 1)
            {
                tapInterval++;
            }
        }
        private void ChangeArrow()
        {
            if (curArrow == ArrowActive.Left)
            {
                leftArrow.sprite = leftActive;
                rightArrow.sprite = rightInactive;
            }
            else if (curArrow == ArrowActive.Right)
            {
                leftArrow.sprite = leftInactive;
                rightArrow.sprite = rightActive;
            }
        }
    }
}
