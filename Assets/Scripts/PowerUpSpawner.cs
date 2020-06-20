using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform playerTransform;
    private int noOfTiles = 1;
    private float spawnZ = 300f;
    private int tileLength = 600;
    public GameObject[] powerUps;
    private float safeZone = 120f;
    public List<GameObject> activePowerUps;
    int i;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.z - safeZone) > (spawnZ - (noOfTiles * tileLength)))
        {
            SpawnPowerUp();
            DeletePowerUp();
        }
    }

    void SpawnPowerUp()
    {
        i = Random.Range(0, powerUps.Length);
        GameObject go;
        go = Instantiate(powerUps[i], new Vector3(Mathf.Ceil(Random.Range(-1, 2)), 1, playerTransform.position.z + 120), Quaternion.identity) as GameObject;
        //go.transform.SetParent(gameObject.transform);
        activePowerUps.Add(go);
        spawnZ += tileLength;
    }

    void DeletePowerUp()
    {
        if (activePowerUps.Count > noOfTiles)
        {
            Destroy(activePowerUps[0]);
            activePowerUps.RemoveAt(0);
        }
    }
}
