using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnLocations = new List<Transform>();
    private int spawnCount;
    private ebtManager EBTM;
    // Start is called before the first frame update
    void Start()
    {
        EBTM = GetComponent<ebtManager>();
    }


    public void SpawnEnemies()
    {
        spawnCount = int.Parse(EBTM.resultText.text);

        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = Random.Range(0, spawnLocations.Count);
            Transform randomLocation = spawnLocations[randomIndex];

            GameObject enemy = Instantiate(enemyPrefab, randomLocation.position, randomLocation.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
