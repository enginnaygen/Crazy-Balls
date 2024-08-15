using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBallController : MonoBehaviour
{
    [SerializeField]RandomShape randomShape;
    [SerializeField] float ballSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField]BallController ballController;
    [SerializeField] Animation animationn;

   


    void Start()
    {
        ballController = FindObjectOfType< BallController>().GetComponent<BallController>();
        randomShape = FindObjectOfType<RandomShape>().GetComponent<RandomShape>();
        rb.velocity = Vector3.zero;
        rb.velocity = ballController.Distance * ballSpeed;
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 100);
        Destroy(this.gameObject, 1.5f);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        
        animationn.Play();
        rb.velocity = Vector2.zero;
        ballController.RotateSpeed = 0;
        yield return new WaitForSecondsRealtime(0.4f);
        randomShape.endingPanel.SetActive(true);
        Time.timeScale = 0f;
        Destroy(this.gameObject);
        
    }

}

