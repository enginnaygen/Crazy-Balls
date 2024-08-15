using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnBall;
    public bool Click { get; set; }
    //public float time;
    public bool CanShoot { get; set; }


    private void Start()
    {
        CanShoot = false;
        Click = false;
    }
    void Update()
    {
        //time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)&&CanShoot)
        {   Click = true;
        }

    }

    private void FixedUpdate()
    {
        BallSpawn();
    }

    private void BallSpawn()
    {
        if (Click)
        {
            Click = false;
            Instantiate(spawnBall);
            //time = 0;
        }
    }
}
