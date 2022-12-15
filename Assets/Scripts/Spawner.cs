using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemy;
    public float SpawnTime = 2f;
    public int enemyspawnCount = 10;
    public GameController gameController;
    private bool lastEnemySpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    } 

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpawn&&FindObjectOfType<Enemyscript>()==null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }
    IEnumerator EnemySpawner()
    {
        for (int i = 0; i < enemyspawnCount; i++)
        {
            yield return new WaitForSeconds(SpawnTime);
            SpawnerEnemy();
        }

        lastEnemySpawn = true;
    }
    void SpawnerEnemy()
    {
        int randomValue = Random.Range(0, Enemy.Length);
        int randomXPos = Random.Range(-4, 4);
        Instantiate(Enemy[randomValue], new Vector2(randomXPos, transform.position.y), Quaternion.identity);
    }
}