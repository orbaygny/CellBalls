using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwerveSystem : MonoBehaviour
{
   // Rigidbody rb;

    public static SwerveSystem Instance { get; private set; }

    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private float MoveFactorX => _moveFactorX;

    public bool isMoveForward = false;
    public bool isParent = false;

    public float speed = 0f;
    public float jump = 0;

    public float swerveSpeed = 0.5f;
    public float swerveMinus;
    public float swervePlus;

    public Vector3 x ;

    public Vector3 velocity;

    public Transform parentObject;

    public bool divide;
    public bool merge;
    public float time;
    public bool onAir;
    public bool startTimer;

    public bool _jump;

    public bool finish;
    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();

        velocity = new Vector3(5, 0, 5);
        time = 3.0f;
        jump = 0;
    }
    private void Update()
    {
        if (_jump)
        {
            Debug.Log("a");
            jump = Mathf.Lerp(jump, -0.3f, 0.45f*Time.deltaTime);
        }

       
       
        
       /* if (startTimer)
        {
            time -= Time.deltaTime;
        }
        Debug.Log(time);
        if (time <= 0)
        {
            divide = false;
            merge = true;
            startTimer = false;
            time = 3.5f;
        }*/
        x = parentObject.transform.position;
        x.x = Mathf.Clamp(x.x,swerveMinus,swervePlus);
        parentObject.transform.position = x;
        if (Input.GetMouseButtonDown(0))
        {   
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }



        // CamSwerve();
        if (!finish && !GameManager.Instance.gameEnd && !GameManager.Instance.firstStart) { Swerve(); }
        Movement();




    }

    private void FixedUpdate()
    {
        
       // rb.AddForce(transform.right * 2,ForceMode.Force);

        //Swerve();
    }

    void Movement()
    {
        if(isMoveForward)
        {
            switch(isParent){
                case true:
                parentObject.Translate(0, jump, speed * Time.deltaTime);
                break;

                case false:
                transform.Translate(0, jump, speed * Time.deltaTime);
                break;
            }
        }
    }

    void Swerve()
    {   float swerveAmount = Time.fixedDeltaTime * swerveSpeed * MoveFactorX;
//        rb.AddForce(velocity, ForceMode.Force);
        switch(isParent){
            case true:
            if(MoveFactorX<=0 && parentObject.position.x>swerveMinus)
            {
                    //parentObject.Translate(swerveAmount, 0, 0);
                    //velocity.x -= 0.5f;
            } 
            if(MoveFactorX>0 && parentObject.position.x<swervePlus)
            {
                //parentObject.Translate(swerveAmount, 0, 0);
            }           
            break;

            case false:
            if(MoveFactorX<0 && transform.position.x>swerveMinus)
            {
                    //Debug.Log("Turning");
                    //velocity.x -= 1f;
                transform.Translate(swerveAmount, 0, 0);
                    time = 3.5f;
                    // merge = false;
                    // divide = true;
                    // startTimer = true;

                    
                } 
            if(MoveFactorX>0 && transform.position.x<swervePlus)
            {
                    //elocity.x += 1f;
                    transform.Translate(swerveAmount, 0, 0);
                    time = 3.5f;
                    //merge = false;
                    //divide = true;
                    //startTimer = true;

                    
                }

            
             
            break;
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
 
}
