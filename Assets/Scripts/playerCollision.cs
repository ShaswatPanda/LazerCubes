using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class playerCollision : MonoBehaviour
{
    public Player movement;
    public int coinsCollected;
    GameObject coin;
    public AudioSource coinSound;
    public CoinBalance coinBalance;
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.gameObject.name);

        if(collisionInfo.gameObject.tag == "Obstacle")
        {
            movement.enabled = false;
        }
        
    }


    private void OnTriggerEnter(Collider coin)
    {
        if(coin.gameObject.tag=="Coin")
        {
            coinsCollected += 1;
            coinSound.Play();
            coin.gameObject.SetActive(false);
            //Debug.Log(coinsCollected);

            coinBalance.coinBalance++;
            //Debug.Log(coinBalance.coinBalance);
        }
    }

    private void Start()
    {
        coinBalance = FindObjectOfType<CoinBalance>();
        coinsCollected = 0;
    }



}
