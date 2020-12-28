using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Object Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the Object that will spawn in this wave
    [SerializeField] GameObject objectPrefab;

    //the path that wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each Object spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of objects in the Wave
    [SerializeField] int numberOfObjects = 5;

    //the speed of the enemy
    [SerializeField] float objectMoveSpeed = 2f;

    public GameObject GetObjectPrefab()
    {
        return objectPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //access pathPrefab and for each child
        //add it to the List waveWayPoints
        foreach (Transform wp in pathPrefab.transform)
        {
            waveWayPoints.Add(wp);
        }

        return waveWayPoints;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObjects()
    {
        return numberOfObjects;
    }

    public float GetObjectMoveSpeed()
    {
        return objectMoveSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
