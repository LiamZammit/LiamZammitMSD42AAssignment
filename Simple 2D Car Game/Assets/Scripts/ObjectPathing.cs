using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    

    [SerializeField] WaveConfig waveConfig;

    //saves the waypoint in which we want to go
    int waypointIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {

        waypoints = waveConfig.GetWaypoints();
        //set the start position on Enemy to the 1st waypoint position
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
       objectMove();
    }

    private void objectMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //set the targetPosition to the waypoint where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //make sure that z axis = 0
            targetPosition.z = 0f;

            var objectMovement = waveConfig.GetObjectMoveSpeed() * Time.deltaTime;

            //move object from current position to targetPosition, at ObjectMovementSpeed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, objectMovement);

            //if object reaches the target position
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        //if enemy reaches last waypoint
        else
        {
            Destroy(gameObject);
        }
    }

    public void setWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;    
    }

}
