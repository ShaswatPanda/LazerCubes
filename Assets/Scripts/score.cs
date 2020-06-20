using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Player playerObject;
    public Text scoreText;
    public float currentScore = 0f;
    public int difficultyLevel = 100;
    public int maxDifficultyLevel = 50;
    public int scoreToNextLevel = 10;
    private GameObject blockspawner;
    public float multipliedScore = 0f;
    private int multiplier = 1;
    ScoreMultiplier scoreMultiplier;

    void Start()
    {
        currentScore = 0;
        blockspawner = FindObjectOfType<BlockSpawner>().gameObject;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    
    void Update()
    {
        multipliedScore = player.position.z * multiplier;
        if (currentScore >= scoreToNextLevel)
        {
            levelUp();
        }
        currentScore = player.position.z *  multiplier;
        scoreText.text = currentScore.ToString("0");
        //Debug.Log(difficultyLevel);
        //Debug.Log(playerObject.speed);
    }

    void levelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        playerObject.setSpeed(difficultyLevel*2);
        
    }

    public IEnumerator ScoreMultiplier()
    {
        

        scoreMultiplier = FindObjectOfType<ScoreMultiplier>();
        scoreMultiplier.GetComponent<SpriteRenderer>().enabled = false;
        scoreMultiplier.GetComponent<AudioSource>().Play();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        multiplier = 2;

        yield return new WaitForSeconds(scoreMultiplier.powerUpTime);

        multiplier = 1;

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        scoreMultiplier.powerUpIsActive = false;
        //scoreMultiplier.enabled = false;

    }
}
