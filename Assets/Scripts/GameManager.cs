using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public float restartDelay = 2f;
    public Player movement;
    public GameObject gameOverUI;
    public Text scoreText;
    public float gameOverDelay = 5f;
    public AudioSource deathSound;
    

    void start()
    {
        gameOverUI.SetActive(false);
        
    }
   public void endGame()
    {      
        
        Debug.Log("Game Over!");
        //Invoke("restart", restartDelay);
        gameOver = true;
        gameOverUI.SetActive(true);
        scoreText.color = Color.blue;
       

    }

    /*void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    /*public void completeLevel()
    {
        Debug.Log("Game Complete!");
        levelCompletedUI.SetActive(true);
        movement.enabled = false;
        Invoke("restart", gameOverDelay);

    }*/
}
