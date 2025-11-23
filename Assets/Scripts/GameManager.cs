using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float horizontalScreenSize;
    public float verticalScreenSize;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject coinPrefab;
    public GameObject shieldPrefab;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 0.5f, 5f);
        InvokeRepeating("CreateEnemyThree", 1, 2);
        StartCoroutine(SpawnShield());
        StartCoroutine(SpawnCoin());



    }

    // Update is called once per frame
    void Update()
    {
       
    }



    //create powerups and enemies
    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-4f, 14f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 13f), 6.5f, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize, verticalScreenSize * 0.3f), 0), Quaternion.identity);

    }
    void CreateShield()
    {
        Instantiate(shieldPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize, verticalScreenSize * 0.3f), 0), Quaternion.identity);

    }


    //Runs every 3-5, calls create coin
    IEnumerator SpawnCoin()
    {

        float coinSpawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(coinSpawnTime);
        CreateCoin();
        StartCoroutine(SpawnCoin());
    }




    //Runs every 3-5, calls create shield
    IEnumerator SpawnShield()
    {
        Debug.Log("SHIELD");
        float shieldSpawnTime = 8;
        yield return new WaitForSeconds(shieldSpawnTime);
        CreateShield();
        StartCoroutine(SpawnShield());
    }
}
