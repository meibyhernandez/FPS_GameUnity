using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int enemiesAlive = 0;

    public int round = 0;

    public GameObject[] spawnPoints; 

    public GameObject enemyPrefab ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
        }
    }

    public void NextWave(int round)
    {
        for(var i = 0; i < round; i++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            enemySpawned.GetComponent<Enemy_manager>().gameManager = GetComponent<GameManager>();

            enemiesAlive++;
        }

       
    }
}
