using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCounter : MonoBehaviour
{
    public Player player;
    public Text coinCount;

    void Start()
    {
        coinCount.text = "0";

    }



    void Update()
    {
        coinCount.text = player.GetComponent<playerCollision>().coinsCollected.ToString();
    }
}
