using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowController : MonoBehaviour
{
    public SpriteRenderer leftArrow;
    public SpriteRenderer rightArrow;
    public Sprite leftInactive;
    public Sprite rightInactive;
    public Sprite leftActive;
    public Sprite rightActive;

    private int tapInterval;
    public int tapStrength;
    public Animator chefFireAnim;
    public int flameThresholdMid;
    public int flameThresholdSmall;
    public int flameThresholdNone;

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
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Horizontal") > 0 && curArrow == ArrowActive.Left)
        {
            curArrow = ArrowActive.Right;
            onKeyChange.Invoke();
            if (tapInterval > 0)
            {
                tapInterval -= tapStrength;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0 && curArrow == ArrowActive.Right)
        {
            curArrow = ArrowActive.Left;
            onKeyChange.Invoke();
            if (tapInterval > 0)
            {
                tapInterval -= tapStrength;
            }
        }

        if(tapInterval < flameThresholdMid)
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
        else if (tapInterval>= flameThresholdSmall)
        {
            fireState = FireState.None;
        }
        chefFireAnim.SetInteger("FireState", (int) fireState);
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
        if(curArrow == ArrowActive.Left)
        {
            leftArrow.sprite = leftActive;
            rightArrow.sprite = rightInactive;
        }
        else if(curArrow == ArrowActive.Right)
        {
            leftArrow.sprite = leftInactive;
            rightArrow.sprite = rightActive;
        }
    }
}
