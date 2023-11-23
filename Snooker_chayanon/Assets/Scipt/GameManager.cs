using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]private int playerscore;
    [SerializeField]private GameObject ballPrefab;
    [SerializeField]private GameObject[] ballPos;
    [SerializeField] private GameObject cueBall;  
    [SerializeField] private GameObject ballLine;
    [SerializeField] private float xInput;
    [SerializeField] private float speed;
    [SerializeField] private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        camera = Camera.main.gameObject;
        
        //set ball on the table
        
        Setballs(BallColors.Red, 1);
        Setballs(BallColors.Pink, 2);
        Setballs(BallColors.Blue, 3);
        Setballs(BallColors.Brown, 4);
        Setballs(BallColors.Green, 5);
        Setballs(BallColors.Yellow, 6);
        Setballs(BallColors.Black, 7);
        SetCamera();
    }

    void Setballs(BallColors colors , int pos)
    {
        GameObject ball = Instantiate(ballPrefab,ballPos[pos].transform.position,Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPoint(colors);
    }

    void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput/5,0f));
        
    }

    void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        ballLine.SetActive(false);
    }

    void SetCamera()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(-10, 5, 0);
    }

    void StopBall()
    {
        
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;
        SetCamera();
        camera.transform.eulerAngles = new Vector3(11.914f, 90f, 0f);
        ballLine.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopBall();
        }

    }
}
