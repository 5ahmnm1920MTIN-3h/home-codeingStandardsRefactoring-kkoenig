using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    public GameObject[] obstacles;
    public bool isGameOver = false;
    public float minSpawnTime, maxSpawnTime;
    const string coroutineSpawmKeyword = "Spawn";
    const float defaultWaitTime = 1f;

    //  // Called once on Gamestart, sets instance variable
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update, starts coroutine
    void Start()
    {
        StartCoroutine(coroutineSpawmKeyword);
    }
 
    // Spawns obstacles with random timegap
    IEnumerator Spawn()
    {
        float waitTime = defaultWaitTime;
        yield return new WaitForSeconds (waitTime);

        while (!isGameOver)
        {
            SpawnObstacle();
            waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Called by IEnumerator Spawn, choosing random distances and elements of obstacles
    void SpawnObstacle()
    {
        int randomPosition = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomPosition], transform.position, Quaternion.identity);
    }
}
