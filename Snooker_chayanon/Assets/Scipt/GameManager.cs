using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        //set ball on the table
        Setballs(BallColors.White, 0);
        Setballs(BallColors.Red, 1);
        Setballs(BallColors.Pink, 2);
        Setballs(BallColors.Blue, 3);
        Setballs(BallColors.Brown, 4);
        Setballs(BallColors.Green, 5);
        Setballs(BallColors.Yellow, 6);
        Setballs(BallColors.Black, 7);
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
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        ballLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }

        if (cueBall.GetComponent<Rigidbody>())
        {
            
        }
        
    }
}
