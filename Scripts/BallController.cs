using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [field:SerializeField]public float RotateSpeed {  get; set; }
    [SerializeField] Transform directionTransform, ballTransform;
    public Vector2 Distance { get; private set; }
    //RandomShape _randomShape;


    private void Start()
    {
        //_randomShape = FindObjectOfType<RandomShape>().GetComponent<RandomShape>();
        RotateSpeed = 1.8f;
    }
    void FixedUpdate()
    {
        DirectionCalculate();
        transform.Rotate(0, 0, RotateSpeed);
        
      
        /*if (transform.rotation.z >=90)
         {
             rotateSpeed *= -1;

         }
         else if(transform.rotation.z <=-90)
         {
             rotateSpeed *= -1;

         }*/
        /*if (transform.position.x >= 1.88f)
{
    ballSpeed *= -1;
}
if (transform.position.x <= -1.88f)
{
    ballSpeed *= -1;
}
transform.position = new Vector2(transform.position.x +  ballSpeed, transform.position.y);*/
    }
    private void DirectionCalculate()
    {
        Distance = directionTransform.position - transform.position;
        //Debug.Log(distance);
    }

}
