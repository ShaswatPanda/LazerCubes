using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public Text coinText;
    CoinBalance coinBalance;
    
    
    void Start()
    {
        coinBalance = FindObjectOfType<CoinBalance>();
    }


    // Update is called once per frame
    void Update()
    {
        coinText.text = coinBalance.coinBalance.ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
