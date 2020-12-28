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
    private float tapInterval;
    private UnityEvent onKeyChange;
    private ArrowActive curArrow = ArrowActive.Left;
    private enum ArrowActive
    {
        Left, Right
    }
    // Start is called before the first frame update
    void Start()
    {
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
        }
        else if (Input.GetAxis("Horizontal") < 0 && curArrow == ArrowActive.Right)
        {
            curArrow = ArrowActive.Left;
            onKeyChange.Invoke();
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
