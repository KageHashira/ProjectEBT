using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ebtManager : MonoBehaviour
{
    //All the Variables Used for the Dice Outcome Display.
    public TMP_Text resultText;
    public Image diceImg1;
    public Image diceImg2;                
    public Sprite[] diceSprites;

    //All the Variables Used for the Time Outcome.
    public TMP_Text timerText;
    private float startTime;                                       // the start time for the timer
    private float timeInMinutes;
    private bool timerStarted;                                     // a bool to indicate whether the timer has started

    //All Variables Used for EnemySpawner and Spawner.
    public GameObject enemyPrefab;
    public List<Transform> enemySpawnPoints;
   [SerializeField] private List<GameObject> spawnedEnemies;                       // list of spawned enemies





    private void Start()
    {
        timerText.text = "00:00";
        spawnedEnemies = new List<GameObject>();                   // initialize the list of spawned enemies
    }

    private void Update()
    {
        // update the timer if it has started
        if (timerStarted)
        {
            UpdateTimer();                      
        }
    }

    public void RollDice()
    {
        DestroyEnemies();

        // generate a random number between 0 and 6 for the first dice
        int diceNum1 = Random.Range(0, 6);                               
        int diceNum2 = Random.Range(0, 6);

        // set the result text to the sum of the two dices + 2
        resultText.text = (diceNum1 + diceNum2 + 2).ToString();

        // set the sprite for the second dice based on the second random number
        diceImg1.sprite = diceSprites[diceNum1];
        diceImg2.sprite = diceSprites[diceNum2];


        // set the Timer and Eneies based on the result of the dice roll
        EBTspawner(diceNum1 + diceNum2 + 2);

        


    }

    // function to set the EBT based on the result of the dice roll
    private void EBTspawner(int diceResult)
    {
        switch (diceResult)
        {
            case 2:
                timeInMinutes = 1f;
                SpawnEnemies(2);
                break;
            case 3:
                timeInMinutes = 2f;
                SpawnEnemies(3);
                break;
            case 4:
                timeInMinutes = 3f;
                SpawnEnemies(4);
                break;
            case 5:
                timeInMinutes = 4f;
                SpawnEnemies(5);
                break;
            case 6:
                timeInMinutes = 5f;
                SpawnEnemies(6);
                break;
            case 7:
                timeInMinutes = 6f;
                SpawnEnemies(7);
                break;
            case 8:
                timeInMinutes = 7f;
                SpawnEnemies(8);
                break;
            case 9:
                timeInMinutes = 8f;
                SpawnEnemies(9);
                break;
            case 10:
                timeInMinutes = 9f;
                SpawnEnemies(10);
                break;
            case 11:
                timeInMinutes = 10f;
                SpawnEnemies(11);
                break;
            case 12:
                timeInMinutes = 11f;
                SpawnEnemies(12 );
                break;
        }

        // Start the timer
        startTime = Time.time;
        timerStarted = true;
    }
    private void SpawnEnemies(int count)
    {
        // Select random spawn locations for the specified number of enemies
        List <Transform> availableLocations = new List<Transform>(enemySpawnPoints);
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, availableLocations.Count);
            Transform spawnLocation = availableLocations[randomIndex];
            availableLocations.RemoveAt(randomIndex);

            // Spawn a new enemy at the selected location
            GameObject enemy = Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
            spawnedEnemies.Add(enemy);
        }
    }
    //private void SpawnEnemies(int numberOfEnemies)
    //{


    //    for (int i = 0; i < numberOfEnemies; i++)
    //    {
    //        int spawnPointIndex = Random.Range(0, enemySpawnPoints.Count);
    //        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoints[spawnPointIndex].position, Quaternion.identity);

    //    }
    //}


    //Function to Destroy all currently spawned enemies
    private void DestroyEnemies()
    {
        foreach (var enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
        spawnedEnemies.Clear();
    }


    private void UpdateTimer()
    {
        // Calculate the amount of time remaining on the timer
        float elapsedTime = Time.time - startTime;
        float remainingTime = timeInMinutes * 60 - elapsedTime;

        // Update the timer display with the remaining time
        if (remainingTime > 0)
        {
            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // The timer has run out, so update the display accordingly
            timerText.text = "Time's up!";
        }
    }
}
