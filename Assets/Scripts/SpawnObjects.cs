using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject[] prefabs;
    float timeLeft;
    string lastPrefab;

    float currentSpeed;
    float currentTimeRangeStart;
    float currentTimeRangeEnd;
    bool decreaseTime = true;

    StickMan stickMan;

    void Start()
    {
        timeLeft = 0;
        currentSpeed = Mathf.Log(3 * (Time.time + 2));
        ManageSpawnTiming();

        stickMan = FindObjectOfType<StickMan>();
        if (!stickMan)
        {
            Debug.LogError("Stick Man cannot be found!");
        }
    }


    void Update()
    {
        ManageSpawnTiming();
        ManageSpeed();

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0 && !stickMan.gameIsFinished)
        {
            SpawnNewObject();
            timeLeft = Random.Range(currentTimeRangeStart, currentTimeRangeEnd);
        }
    }

    private void ManageSpeed()
    {
        currentSpeed = 0.05f * Time.timeSinceLevelLoad + 5f;
        if (currentSpeed > 7)
        {
            currentSpeed = 7f;
        }
    }

    private void ManageSpawnTiming()
    {
        if (decreaseTime)
        {
            currentTimeRangeStart = -0.02f * Time.timeSinceLevelLoad + 1.5f;
            currentTimeRangeEnd = -0.02f * Time.timeSinceLevelLoad + 2f;
            if (Time.time > 30)
            {
                currentTimeRangeStart = 0.9f;
                currentTimeRangeEnd = 1.1f;
                decreaseTime = false;
            }
        }
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
        newObject.GetComponent<Object>().speed = currentSpeed;
    }



}
