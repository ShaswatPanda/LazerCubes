using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    GameObject powerUp;
    public Text powerUpTime;
    public Text multiplierTime;
    CoinMagnet coinMagnet;
    ScoreMultiplier scoreMultiplier;
   
    
    void Start()
    {
        powerUpTime.enabled = false;
        powerUpTime.transform.GetChild(0).gameObject.SetActive(false);

        multiplierTime.enabled = false;
        multiplierTime.transform.GetChild(0).gameObject.SetActive(false);
    }

    
    void Update()
    {
        
        //powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        coinMagnet = FindObjectOfType<CoinMagnet>();
        scoreMultiplier = FindObjectOfType<ScoreMultiplier>();

        //Coin Magnet
        if (coinMagnet.powerUpIsActive == true)
        {
            powerUpTime.enabled = true;
            powerUpTime.transform.GetChild(0).gameObject.SetActive(true);
            powerUpTime.text = coinMagnet.timeRemaining.ToString("0");
        }
        if(coinMagnet.powerUpIsActive == false)
        {
            powerUpTime.enabled = false;
            powerUpTime.transform.GetChild(0).gameObject.SetActive(false);
        }

        //Score Multiplier
        
        if(scoreMultiplier.powerUpIsActive == true)
        {
            multiplierTime.enabled = true;
        }



    }
}
