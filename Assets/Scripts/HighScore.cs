using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    public Text highScore;
    float score;
    Player player;
    float currentScore = 0f;
    
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        currentScore = FindObjectOfType<score>().currentScore;
    }

    
    void Update()
    {
        score = Mathf.Ceil(currentScore) - 1;
        if (score>PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScore.text = score.ToString(); 
        }
    }
}
