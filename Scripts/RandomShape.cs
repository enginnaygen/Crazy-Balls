using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class RandomShape : MonoBehaviour
{

    [SerializeField] GameObject[] shapes;
    [SerializeField] GameObject visible;
    [SerializeField] int highScore;
    [SerializeField] Text scoreText, afterScoreText, highScoreText;
    public GameObject endingPanel, startPanel;
    ShapesRotate _shapesRotate;
    BallController _ballController;
    BallSpawner _ballSpawner;

    public GameObject Before {get; set;}
    public int Score { get; set; }
    void Start()
    {
        _ballController = FindObjectOfType<BallController>().GetComponent<BallController>();
        _ballSpawner = FindObjectOfType<BallSpawner>().GetComponent<BallSpawner>();

        //Time.timeScale = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "High Score: " + highScore;
           

        }
        else if(!PlayerPrefs.HasKey("HighScore"))
        {
            highScore = 0;
            highScoreText.text = "High Score: " + 0;

        }
        visible = shapes[Random.Range(0, shapes.Length)];
        Instantiate(visible);
        afterScoreText.text = "Score: " + 0;

    }
    /*void Update()
    {
        //shapesRotate = FindObjectOfType<ShapesRotate>().GetComponent<ShapesRotate>();
        //scoreText.text = Score.ToString();
     
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score++;
        afterScoreText.text = "Score: " + Score;
        scoreText.text = ""+Score;


        
        if (Score > highScore)
        {
            highScore = Score;
            PlayerPrefs.SetInt("HighScore", highScore);

        }
        highScoreText.text = "High Score: " + highScore;

        //scoreText.text = Score.ToString();
        //highScoreText.text = "High Score: "+highScore;


        if (Score > 0)
        {
            if (Score % 5 == 0)
            {

                NewShape();


            }
        }  
        RotatingArrangenment(); 
    }

    void RotatingArrangenment()
    {
        if (Score % 10 == 0 && Score > 0 && _ballController.RotateSpeed > 0)
        {
            _ballController.RotateSpeed += 0.1f;
            _ballController.RotateSpeed = -_ballController.RotateSpeed;
        }
        else if (Score % 10 == 0 && Score > 0 && _ballController.RotateSpeed < 0)
        {
            _ballController.RotateSpeed -= 0.1f;
            _ballController.RotateSpeed = -_ballController.RotateSpeed;
        }
    }

    public void Begin()
    {
        startPanel.SetActive(false);
        _ballSpawner.CanShoot = true;
        Time.timeScale = 1;

    }
    public void ReStart()
    {
        _ballController.RotateSpeed = 1.8f;
        Score = 0;
        scoreText.text = "" + 0;
        afterScoreText.text = "Score: "+0;
        Time.timeScale = 1f;
        NewShape();
        _shapesRotate.RotateSpeed = -0.75f;
        endingPanel.SetActive(false);
        _ballSpawner.CanShoot = true;
    }

    public void Exit()
    {
        Application.Quit();
        //Debug.Log("Exit");
    }

    private void NewShape()
    {
        Before = FindObjectOfType<ShapesRotate>().gameObject;
        visible = shapes[Random.Range(0, shapes.Length)];
        //Debug.Log("visible"+ visible);
        //Debug.Log("before"+ Before);
        if (visible.gameObject.tag == Before.gameObject.tag) //visible== Before diye direkt yapýnca yüksek ihtimalle ayný obje olarak görmüyor ondan else if'e geçiyor, daha sonra uðraþýrým
        {
            //Destroy(visible);
            while (visible.gameObject.tag == Before.gameObject.tag)
            {
                visible = shapes[Random.Range(0, shapes.Length)];
                if (visible.gameObject.tag != Before.gameObject.tag) break;
            }
            Destroy(Before);
            Instantiate(visible);
            _shapesRotate = FindObjectOfType<ShapesRotate>().GetComponent<ShapesRotate>();

            //Debug.Log("visible" + visible);


        }
        else if (visible.gameObject.tag != Before.gameObject.tag)
        {
            Destroy(Before);
            Instantiate(visible);
            _shapesRotate = FindObjectOfType<ShapesRotate>().GetComponent<ShapesRotate>();

        }
    }
}
   

