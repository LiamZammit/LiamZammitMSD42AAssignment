﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    //start from wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when calling Coroutine, specify which wave we need to spawn objects from
    private IEnumerator SpawnAllObjectsInWave(WaveConfig waveToSpawn)
    {
        for (int objectCount = 1; objectCount <= waveToSpawn.GetNumberOfObjects(); objectCount++)
        {
            var newObject = Instantiate(waveToSpawn.GetObjectPrefab(),
                        waveToSpawn.GetWaypoints()[0].transform.position,
                        Quaternion.identity);
            
            newObject.GetComponent<ObjectPathing>().setWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach(WaveConfig currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllObjectsInWave(currentWave));
        }
    }
}
