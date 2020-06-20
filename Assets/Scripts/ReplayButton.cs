using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    BlockSpawner blockSpawner;

    private void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
    }

    public void restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(1);
        blockSpawner.GetComponent<BlockSpawner>().enabled = false;
        blockSpawner.GetComponent<BlockSpawner>().enabled = true;
        Debug.Log("Replay!");
    }
    public void replay()
    {
        Invoke("restart", FindObjectOfType<GameManager>().restartDelay);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
