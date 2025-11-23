using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float horizontalScreenSize = 9.5f;
    private float verticalScreenSize = 2.25f;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {

    InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 0.5f, 5f);

        StartCoroutine(SpawnCoin());

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 13f), 6.5f, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize, verticalScreenSize ), 0), Quaternion.identity);

    }


    //Runs every 3-5, calls create coin, and adds to the coinCounter. 
    IEnumerator SpawnCoin()
    {

        float spawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(spawnTime);
        CreateCoin();
        StartCoroutine(SpawnCoin());
    }
}
