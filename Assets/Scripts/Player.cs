using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float speed = 25f;
    private Rigidbody rb;
    //private float mapWidth = 1.5f;

    private CharacterController controller;
    private Vector3 moveVector;

    public Player movement;
    private GameManager gameManager;

    public PauseMenu pauseMenu;
    public ParticleSystem PlayerDeathEffect;

    public Swipe swipe;
    public Color myColor;

    CoinMagnet coinMagnet;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        FindObjectOfType<AudioManager>().play("MainTheme");
        pauseMenu = FindObjectOfType<PauseMenu>();
        pauseMenu.Pause();
        pauseMenu.Resume();
    }

    private void Awake()
    {

    }
    /*   void FixedUpdate()
       {
           float x = Input.GetAxis("Horizontal") * Time.deltaTime;
           Vector3 newPosition = rb.position + Vector3.right * x;
           newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
           rb.MovePosition(newPosition);       
       }*/

    private void Update()
    {



        moveVector = Vector3.zero;
        //moveVector.x = Mathf.Ceil(Input.GetAxisRaw("Horizontal")) * 15f * Time.deltaTime;

        if(transform.position.x > -0.95f && transform.position.x < 1.05f)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || swipe.SwipeLeft)
            {
                moveVector.x = -1f;
            }
        }
        if(transform.position.x < 0.05f && transform.position.x > -1.05f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || swipe.SwipeRight)
            {
                moveVector.x = 1f;
            }
        }
        
        if(transform.position.y>2)
        {
            moveVector.y = -1f;
        }
        moveVector.z = speed * Time.deltaTime;
        controller.Move(moveVector);


        coinMagnet = FindObjectOfType<CoinMagnet>();
    }

    public void setSpeed(int modifier)
    {
        speed = 25 + modifier;
    }

    

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.point.z>transform.position.z + controller.radius && hit.gameObject.tag != "Coin" && hit.gameObject.tag != "Floor")
        {
            Death();
        }
    
    }

    public void Death()
    {
        Debug.Log("You're dead");
        movement.enabled = false;
        //Destroy(gameObject);
        gameObject.SetActive(false);
        Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<GameManager>().deathSound.Play();
        FindObjectOfType<GameManager>().endGame();
    }

    public IEnumerator Attract()
    {

        //spawn cool effect
        //Instantiate(pickUpEffects, transform.position, transform.rotation);
        coinMagnet.GetComponent<SpriteRenderer>().enabled = false;
        coinMagnet.GetComponent<AudioSource>().Play();
        gameObject.transform.GetChild(1).gameObject.SetActive(true);


        yield return new WaitForSeconds(coinMagnet.powerUpTime);



        coinMagnet.powerUpIsActive = false;

        //gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);


        //player.GetComponent<Animator>().enabled = false;

        //player.GetComponent<MeshRenderer>().material.color = myColor;

        //destroy effect
        coinMagnet.enabled = false;


    }

}
