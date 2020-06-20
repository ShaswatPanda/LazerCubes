using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDragging = false;

    public Vector2 SwipeDelta
    {
        get { return swipeDelta; }
    }
    public bool SwipeLeft
    {
        get { return swipeLeft; }
    }
    public bool SwipeRight
    {
        get { return swipeRight; }
    }
    public bool SwipeUp
    {
        get { return swipeUp; }
    }
    public bool SwipeDown
    {
        get { return swipeDown; }
    }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Mobile Inputs
        if(Input.touches.Length>0)
        {
            if(Input.touches[0].phase==TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.touches[0].position;
                isDragging = true;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
                isDragging = false;
            }
        }
        #endregion

        //Calculate the distance between swipe
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length>0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            
        }

        //Did we cross dead zone
        if(swipeDelta.magnitude > 20)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x)>Mathf.Abs(y))
            {
                //left or right
                if(x<0)
                {
                    swipeLeft = true;
                }
                if(x>0)
                {
                    swipeRight = true;
                }
            }
            else
            {
                //vertical
                if (y < 0)
                {
                    swipeDown = true;
                }
                if (y > 0)
                {
                    swipeDown = true;
                }
            }
            Reset();
        }
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
