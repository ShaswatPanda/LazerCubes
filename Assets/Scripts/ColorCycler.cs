using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{
    public Color[] colors;
    int currentIndex = 0;
    Camera cam;
    public bool shouldChange = false;
    public float speed = 5f;



    void Start()
    {
        cam = FindObjectOfType<Camera>();

        currentIndex = Random.Range(0, colors.Length);
        SetColor(colors[currentIndex]);
    }

    void SetColor(Color color)
    {
        cam.backgroundColor = color;
    }


    
    public void cycleColor()
    {
        shouldChange = true;
    }



    void Update()
    {
        if(shouldChange)
        {
            var startColor = cam.backgroundColor;

            var endColor = colors[0];

            if(currentIndex + 1< colors.Length)
            {
                endColor = colors[currentIndex+1];
            }

            var newColor = Color.Lerp(startColor, endColor, Time.deltaTime*speed);
            SetColor(newColor);

            if(newColor == endColor)
            {
                shouldChange = false;
                if(currentIndex + 1< colors.Length)
                {
                    currentIndex++;
                }
                else
                {
                    currentIndex = 0;
                }
            }
        }
                
    }
}
