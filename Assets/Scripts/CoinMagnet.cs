using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    Transform playerTransform;
    public float coinSpeed = 5f;
    GameObject[] coin;
    public GameObject pickUpEffects;
    public float powerUpTime = 12f;
    public bool powerUpIsActive = false;
    Player player;
    public float timeRemaining;
    //public Color myColor;
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        player = FindObjectOfType<Player>();
        timeRemaining = powerUpTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        coin = GameObject.FindGameObjectsWithTag("Coin");
        

        if(powerUpIsActive)
        {
            foreach (GameObject c in coin)
            {
                if(c.transform.position.z - playerTransform.position.z < 30)
                {
                    c.AddComponent<Coin>();
                    
                }
            }

            timeRemaining -= Time.deltaTime;
            //player.GetComponent<Animator>().enabled = true;
        }


        //Debug.Log(timeRemaining);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            powerUpIsActive = true;
            //StartCoroutine(Attract());  
            StartCoroutine(other.GetComponent<Player>().Attract());
        }


    }

    IEnumerator Attract()
    {

        //spawn cool effect
        //Instantiate(pickUpEffects, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<AudioSource>().Play();
        //player.transform.GetChild(1).gameObject.SetActive(true);
       

        yield return new WaitForSeconds(powerUpTime);


        
        powerUpIsActive = false;


        
        
        //player.GetComponent<Animator>().enabled = false;

        //player.GetComponent<MeshRenderer>().material.color = myColor;

        //destroy effect
        enabled = false;


    }

    
}

