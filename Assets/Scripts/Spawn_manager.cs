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
 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animals.Length);
        Instantiate(animals[animalIndex], spawnPos,
            animals[animalIndex].transform.rotation);
    }
}
