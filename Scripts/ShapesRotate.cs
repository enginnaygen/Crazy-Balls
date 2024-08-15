using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesRotate : MonoBehaviour
{
    [field:SerializeField]public float RotateSpeed {  get; set; }
    //RandomShape randomShape;
    BallController _ballController;
    Camera _cam;
    BallSpawner _ballSpawner;
    [SerializeField] Color color1, color2;

    public static int deathCount;
    [SerializeField] AdsManager adsManager;

    private void Start()
    {
       

        adsManager = FindAnyObjectByType<AdsManager>().GetComponent<AdsManager>();
        _ballSpawner = FindObjectOfType<BallSpawner>().GetComponent<BallSpawner>();
        _cam = FindObjectOfType<Camera>().GetComponent<Camera>();
        _ballController = FindObjectOfType<BallController>().GetComponent<BallController>();
        //randomShape = FindObjectOfType<RandomShape>().GetComponent<RandomShape>();

        if (_ballController.RotateSpeed>0)
        {
            RotateSpeed = -0.75f;
            _cam.backgroundColor = color1;
        }
        else if (_ballController.RotateSpeed < 0)
        {
            RotateSpeed = 0.75f;
            _cam.backgroundColor = color2;

        }

        //randomShape.Before = this.gameObject;
    }
    void FixedUpdate()
    {
        //Debug.Log(deathCount);
        transform.Rotate(0, 0, RotateSpeed);
        if(_ballController.RotateSpeed==0)
        {
            RotateSpeed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ballSpawner.CanShoot = false;
        //_ballSpawner.click = false;
        //_ballSpawner.time = 0;
        deathCount++;

        if (deathCount == 5)
        {
            adsManager.LoadLoadInterstitialAd();
        }
        if (deathCount == 6)
        {
            adsManager.ShowInterstitialAd();
            deathCount = 0;
        }
    }


}
