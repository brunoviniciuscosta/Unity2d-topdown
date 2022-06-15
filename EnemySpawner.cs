using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject rangedEnemy;
    [SerializeField] GameObject meleeEnemy;
    private float rangedSpawnInterval;
    private float meleeSpawnInterval;
    private int enemyQuant;



    void Start()
    {
        switch (GameDifficulty.difficulty)
        {
            case GameDifficulty.Difficulties.Facil:
                rangedSpawnInterval = 3.6f;
                meleeSpawnInterval = 4f; ;
                break;
            case GameDifficulty.Difficulties.Medio:
                rangedSpawnInterval = 2.8f;
                meleeSpawnInterval = 3.4f;
                break;
            case GameDifficulty.Difficulties.Dificil:
                rangedSpawnInterval = 1.6f;
                meleeSpawnInterval = 2f;
                break;
            case GameDifficulty.Difficulties.Impossivel:
                rangedSpawnInterval = 0.8f;
                meleeSpawnInterval = 1.3f;
                break;
        }

        //StartCoroutine(spawnEnemy(rangedSpawnInterval, rangedEnemy));
        StartCoroutine(spawnEnemy(meleeSpawnInterval, meleeEnemy));
    }
    private void Update()
    {
        enemyQuant = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 10), Random.Range(-6f, 6f), 0), Quaternion.identity);
        if (enemyQuant < 200)
        {
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
