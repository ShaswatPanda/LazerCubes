using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBalance : MonoBehaviour
{
    public int coinBalance;
    void Start()
    {
        coinBalance = PlayerPrefs.GetInt("CoinBalance", coinBalance);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("CoinBalance", coinBalance);
    }
}
