using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private VideoPlayer vp;
    private GameObject controller;
    private Player player;
    public Canvas pauseCanvas;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        vp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VideoPlayer>();
        player = FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuEnable();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        vp.Pause();
        player.movement.enabled = false;
        FindObjectOfType<AudioManager>().pause("MainTheme");        
        GameIsPaused = true;
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().play("MainTheme");
        player.movement.enabled = true;
        vp.Play();
        GameIsPaused = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void pauseMenuEnable()
    {
        pauseMenuUI.SetActive(true);
        if (GameIsPaused == true)
        {
            Resume();
            
        }
        else if(GameIsPaused == false)
        {
            Pause();
            
        }
        pauseCanvas.GetComponent<AudioSource>().Play();
    }
}
