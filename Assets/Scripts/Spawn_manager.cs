using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public GameObject[] animals;
    public int animalIndex;

    //Spawn values
    private float spawnRangeX = 15;
    private float spawnPosZ = 15;

    //invoke values
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5F;

    private Playercontroller playerControllerScript;

    public int animalsDestroyedCount; 

    public float repeatRateMin = 1;
    public float repeatRateMax = 5;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
        //InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        Invoke("SpawnRandomAnimal", (Random.Range(repeatRateMin, repeatRateMax)));
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.restart)
        {
            Invoke("SpawnObstacle", (Random.Range(repeatRateMin, repeatRateMax)));
            playerControllerScript.restart = false;
        }
    }

   

    void SpawnRandomAnimal()
    {
        if (!isGameOver)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animals.Length);
            GameObject animal = Instantiate(animals[animalIndex], spawnPos,
                animals[animalIndex].transform.rotation);
            Fly_forward animScript = animal.GetComponent<Fly_forward>();
            animScript.speed = animScript.speed + (float)animalsDestroyedCount;

            float randomDelay = Random.Range(repeatRateMin, repeatRateMax);
            Debug.Log("Random interval" + randomDelay);
            Invoke("SpawnRandomAnimal", randomDelay);
        }
    }
}
