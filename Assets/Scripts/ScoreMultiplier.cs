using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public float powerUpTime = 8f;
    score score;
    public float timeRemaining;
    public bool powerUpIsActive = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            powerUpIsActive = true;
            StartCoroutine(score.ScoreMultiplier());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = powerUpTime;
        score = FindObjectOfType<score>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerUpIsActive)
        {
            timeRemaining -= Time.deltaTime;
            
        }
    }
}
