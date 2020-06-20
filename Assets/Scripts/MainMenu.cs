using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            play();
        }
    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void upgrades()
    {
        SceneManager.LoadScene(3);
    }

    public void options()
    {
        SceneManager.LoadScene(2);
    }
}
