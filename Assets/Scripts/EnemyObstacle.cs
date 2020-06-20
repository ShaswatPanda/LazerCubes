using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour
{
    
    Player player;
    public float range = 10f;
    public ParticleSystem laser;
    AudioSource laserSound;
    bool laserSoundIsPlaying = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        laser = GetComponent<ParticleSystem>();
        laser.Pause();
        laserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z - player.transform.position.z < 60)
        {
            Shoot();
            laser.Play();
            if(laserSoundIsPlaying == false)
            {
                laserSound.Play();
                laserSoundIsPlaying = true;
            }
            
        }
        //Shoot();
    }


    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.forward, out hit, range))
        {

            if ((hit.transform.name) == "Player")
            {
                Debug.Log(hit.transform.name);
                
                player.Death();
            }  
            
            if(hit.transform.tag == "Coin")
            {
                hit.transform.gameObject.SetActive(false);
            }
        }

    }
}
