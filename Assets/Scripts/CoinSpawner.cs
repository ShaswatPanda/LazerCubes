using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform playerTransform;
    private int noOfTiles = 30;
    private float spawnZ = 30f;
    private int tileLength = 10;
    public GameObject coinPrefab;
    private float safeZone = 60f;
    public List<GameObject> activeCoins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.z - safeZone) > (spawnZ - (noOfTiles * tileLength)))
        {
            SpawnCoin();
            DeleteCoin();
        }
    }

    void SpawnCoin()
    {
        GameObject go;
        go = Instantiate(coinPrefab, new Vector3(Mathf.Ceil(Random.Range(-1,2)), 1, playerTransform.position.z + 120), Quaternion.identity ) as GameObject;
        activeCoins.Add(go);
        spawnZ += tileLength;
    }

    void DeleteCoin()
    {
        if (activeCoins.Count > noOfTiles)
        {
            Destroy(activeCoins[0]);
            activeCoins.RemoveAt(0);
        }
    }
}
