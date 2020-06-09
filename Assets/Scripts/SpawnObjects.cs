using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject[] prefabs;
    float timeLeft;
    string lastPrefab;

    void Start()
    {
        timeLeft = 0;
    }
    
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            SpawnNewObject();
            timeLeft = getTime();
        }
    }

    float getTime()
    {
        return Random.Range(2, 4);
    }

    void SpawnNewObject()
    {
        int index;

        while (true)
        {
            index = Random.Range(0, prefabs.Length - 1);
            if(prefabs[index].name != lastPrefab)
            {
                lastPrefab = prefabs[index].name;
                break;
            }
        }
        
        Vector3 pos = new Vector3(spawnPosition.position.x,
            spawnPosition.position.y, spawnPosition.position.z);
        GameObject newObject = Instantiate(prefabs[index], pos, Quaternion.identity);
    }



}
