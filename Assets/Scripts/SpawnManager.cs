using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] animalPrefaps;
    public int animalIndex;
    /*private float spawnRangeX = 12;
    private float spawnPosZ = 20;
    private float startDelay = 2;*/
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), 90, 60f);
        Instantiate(animalPrefaps[Random.Range(0, animalPrefaps.Length)]);
    }
    void SpawnRandomAnimal()
    {
         int animalIndex = Random.Range(0,1);
        


          Instantiate(animalPrefaps[animalIndex],new Vector3(0,0,0),Quaternion.identity);
    }

}
