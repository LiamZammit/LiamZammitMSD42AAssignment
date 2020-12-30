using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooting : MonoBehaviour
{
    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.5f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject objectLaserPrefab;

    [SerializeField] float objectLaserSpeed = 0.3f;



    void Start()
    {
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        
    }

    private void Update()
        {
            CountDownAndShoot();
        }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            ObjectFire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

        }
    }

    private void ObjectFire()
    {
        GameObject objectLaser = Instantiate(objectLaserPrefab, transform.position, Quaternion.identity) as GameObject;

        objectLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -objectLaserSpeed);

    }

}