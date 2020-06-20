using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
   
    public Transform playerTransform;
    private int noOfTiles = 7;
    private float spawnZ = -15f;
    private int tileLength = 60;
    public GameObject[] tilePrefab;
    private float safeZone = 60f;
    public List<GameObject> activeTiles;
   
    void Start()
    {
        activeTiles = new List<GameObject>();
        

        for(int i = 0; i< noOfTiles; i++)
        {
            if(i<3)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile();
            }
            //spawnTile(0);
            
        }
        
    }

  
    void Update()
    {

        if ((playerTransform.position.z - safeZone) > (spawnZ - (noOfTiles*tileLength)))
        {
            spawnTile();
            deleteTile();
        }
    }

    void spawnTile(int prefabIndex = -1)
    {
        GameObject go;
        int randomIndex = Random.Range(0, tilePrefab.Length);
        int randomDepth = Random.Range(1, tileLength/2);

        GameObject obstacle = tilePrefab[randomIndex].transform.GetChild(1).gameObject;

        //Setting the random depth of obstacle

        obstacle.transform.parent = null;
        if (randomIndex < 9)
        {
            obstacle.transform.localScale += new Vector3(0, 0, randomDepth);
        }
        obstacle.transform.parent = tilePrefab[randomIndex].transform;



        //Actual spawning ahead of player object

        if (prefabIndex == -1)
            {
                go = Instantiate(tilePrefab[randomIndex]) as GameObject;
            }
            else
            {
                go = Instantiate(tilePrefab[prefabIndex]) as GameObject;
            }
            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;

            activeTiles.Add(go);



        //Resetting the depth of obstacle 
        
        obstacle.transform.parent = null;
        if (randomIndex < 9)
        {
            obstacle.transform.localScale -= new Vector3(0, 0, randomDepth);
        }
        obstacle.transform.parent = tilePrefab[randomIndex].transform;
    }

    void deleteTile()
    {
        if(activeTiles.Count > noOfTiles)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
        
    }


   
    void setRandomDepth(int randomIndex, int randomDepth, GameObject obstacle)
    {
        
       

    }
    void resetRandomDepth(int randomIndex, int randomDepth, GameObject obstacle)
    {
       
    }

}
