using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using DG.Tweening;
using TMPro;

public class BallCollider : MonoBehaviour
{
    Rigidbody rb;
    Vector3 localPos;
    Vector3 pos;

    Collider _collider;
    GameObject mesh;

    public bool disabled;
    public bool isMain;

  
    public bool outFloor;

    float scale;

    int wallDesCount;

    private void Awake()
    {


        rb = GetComponent<Rigidbody>();
        localPos = transform.localPosition;
        pos = transform.position;
        mesh = transform.GetChild(1).gameObject;
        _collider = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        



        wallDesCount = 0;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pit"))
        {
            
            if (isMain) {

                if (GetComponent<MergeBalls>().complate)
                {
                    Debug.Log("PİT");
                    GameManager.Instance.gameEnd = true;
                    SwerveSystem.Instance.isMoveForward = false;
                    SwerveSystem.Instance.finish = true;
                    GetComponent<Rigidbody>().isKinematic = false;
                    GetComponent<Rigidbody>().useGravity = true;
                    foreach (Transform ball in transform.parent)
                    {
                        if (!ball.GetComponent<BallCollider>().isMain)
                        {
                            ball.GetComponent<BallCollider>().DisableBall();
                        }

                    }
                }

                else
                {
                    Debug.Log("PİT");
                    GameManager.Instance.gameEnd = true;
                    SwerveSystem.Instance.isMoveForward = false;
                    SwerveSystem.Instance.finish = true;
                    GetComponent<Rigidbody>().isKinematic = false;
                    GetComponent<Rigidbody>().useGravity = true;
                    foreach (Transform ball in transform.parent)
                    {
                        if (!ball.GetComponent<BallCollider>().isMain)
                        {
                            ball.GetComponent<Rigidbody>().isKinematic = false;
                            ball.GetComponent<Rigidbody>().useGravity = true;

                        }

                    }
                }
                
                
                
            }
            if (!isMain) {  GetComponent<Rigidbody>().isKinematic = false; GetComponent<Rigidbody>().useGravity = true; }
        }

        if (other.gameObject.CompareTag("Obstacle"))
            {
                if(isMain && GetComponent<MergeBalls>().complate && BallControlSystem.Instance.openBalls.Count <= 3)
            {
                GameManager.Instance.gameEnd = true;
                SwerveSystem.Instance.isMoveForward = false;
                CanvasController.Instance.GameLost();
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                if (!isMain)
                {
                    DisableBall();
                }

                if (isMain)
                {

                    if (gameObject.GetComponent<MergeBalls>().complate)
                    {


                        int cnt = 3;
                        //Debug.Log(cnt);
                        for (int i = cnt; i > 0; i--)
                        {
                            //Debug.Log("Collider");
                            int child = Random.Range(1, BallControlSystem.Instance.openBalls.Count);

                            BallControlSystem.Instance.openBalls[child].GetComponent<BallCollider>().DisableBall();
                        }
                        GetComponent<MergeBalls>().MainBallScale();
                    }

                   
                }
            }
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        }

        if (other.gameObject.CompareTag("WallGate"))
        {
            if (isMain)
            {
                if (GetComponent<MergeBalls>().complate && BallControlSystem.Instance.openBalls.Count <=3)
                {
                    GameManager.Instance.gameEnd = true;
                    SwerveSystem.Instance.isMoveForward = false;
                    CanvasController.Instance.GameLost();
                    transform.parent.gameObject.SetActive(false);
                }
                else
                {
                    if (gameObject.GetComponent<MergeBalls>().complate)
                    {


                        int cnt = 3;
                        //Debug.Log(cnt);
                        for (int i = cnt; i > 0; i--)
                        {
                            //Debug.Log("Collider");
                            int child = Random.Range(1, BallControlSystem.Instance.openBalls.Count);

                            BallControlSystem.Instance.openBalls[child].GetComponent<BallCollider>().DisableBall();
                        }
                        GetComponent<MergeBalls>().MainBallScale();
                        other.transform.parent.GetChild(0).gameObject.SetActive(false);
                        other.transform.parent.GetChild(1).gameObject.SetActive(false);
                    }

                    else
                    {
                        int cnt = 3;
                        //Debug.Log(cnt);
                        for (int i = cnt; i > 0; i--)
                        {
                            //Debug.Log("Collider");
                            int child = Random.Range(1, BallControlSystem.Instance.openBalls.Count);

                            BallControlSystem.Instance.openBalls[child].GetComponent<BallCollider>().DisableBall();
                        }

                        other.transform.parent.GetChild(0).gameObject.SetActive(false);
                        other.transform.parent.GetChild(1).gameObject.SetActive(false);
                    }
                }
            }
            
        
        }

        if (other.gameObject.CompareTag("Collect"))
        {

            if (isMain && GetComponent<MergeBalls>().complate)
            {
                int multipler;
                int tmp = BallControlSystem.Instance.openBalls.Count / 3;
                if(tmp<1) { tmp = 1; }
                multipler = (int) char.GetNumericValue(other.transform.parent.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text[1])  ;
                
                tmp += multipler-1;
                tmp *= 3;
               
                int cnt = (tmp-BallControlSystem.Instance.openBalls.Count );
               
                for(int i = 0; i < cnt; i++)
                {
                    Debug.Log("OpenBAlls");
                    int child = Random.Range(1, BallControlSystem.Instance.balls.Count);
                    BallControlSystem.Instance.balls[child].GetComponent<BallCollider>().EnableBall();
                    MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                }
                GetComponent<MergeBalls>().MainBallScale();

                other.transform.parent.GetChild(0).gameObject.SetActive(false);
                other.transform.parent.GetChild(1).gameObject.SetActive(false);
            }
            
        
        }

        if (other.gameObject.CompareTag("Tramp"))
        {
            if (isMain && GetComponent<MergeBalls>().complate)
            {
                SwerveSystem.Instance.onAir = true;
            
                SwerveSystem.Instance.jump = 0.3f;

                SwerveSystem.Instance._jump = true;
                other.transform.DOMoveY(-0.6f, 1f).SetEase(Ease.OutBounce);
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
               
            }

           
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            if (isMain)
            {
               
                if (SwerveSystem.Instance.onAir)
                {
                    if (!BallControlSystem.Instance.isTouch)
                    {
                        foreach (Transform ball in transform.parent)
                        {
                            
                            ball.GetComponent<MergeBalls>().DivideBalls();
                            
                        }
                    }
                    SwerveSystem.Instance.onAir = false;
                    SwerveSystem.Instance._jump = false;
                    SwerveSystem.Instance.jump = 0;
                    transform.parent.position = new Vector3(transform.parent.position.x, -0.345f, transform.parent.position.z);
                }
                
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if (isMain)
            {
                SwerveSystem.Instance.finish = true;
                
                foreach(Transform ball in transform.parent)
                {
                    ball.GetComponent<MergeBalls>().RigMove();
                    ball.GetComponent<MergeBalls>().MainBallScale();
                    
                }

                transform.parent.position = new Vector3(0, transform.parent.position.y, transform.parent.position.z);

                CamFollow.Instance.finish = true;
                GetComponent<SphereCollider>().isTrigger = false;
                //rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints.FreezeRotationX;
                rb.constraints = RigidbodyConstraints.FreezeRotationY;
                rb.constraints = RigidbodyConstraints.FreezePositionX;
                rb.constraints = RigidbodyConstraints.FreezePositionY;
                scale = BallControlSystem.Instance.openBalls.Count / 3;
                if (scale < 1) { scale = 1; }

                Debug.Log("Scale " + scale);
                CanvasController.Instance.moneyText.SetActive(true);
            }
        }

        if (other.gameObject.CompareTag("Hole"))
        {
            foreach( Transform ball in transform.parent)
            {
                if (!ball.GetComponent<MergeBalls>().isMain && ball.gameObject.activeSelf)
                {
                    ball.gameObject.SetActive(false);
                }
            }
            other.transform.GetChild(0).gameObject.SetActive(false);
                if(scale == 0)
            {
                wallDesCount++;
                transform.DOScale(0,0.1f);
                Debug.Log("ENDE LA");
                SwerveSystem.Instance.isMoveForward = false;
                GetComponent<SphereCollider>().isTrigger = true;
                GameManager.Instance.gameEnd = true;
                CanvasController.Instance.GameWin();
                CanvasController.Instance.coinsPanel.SetActive(true);
                ButtonControl.Instance.GetMoney(wallDesCount);

            }

            else if (scale > 0)
            {
                float tmp = transform.localPosition.y-0.1f;
                transform.DOScale(scale * 0.1f, 0.2f);
                transform.DOLocalMoveY(tmp, 0.2f);
                scale--;
                wallDesCount++;
            }

            MMVibrationManager.Haptic(HapticTypes.LightImpact);


        }

        if (other.gameObject.CompareTag("End"))
        {
            if (isMain)
            {
                GameManager.Instance.gameEnd = true;
                SwerveSystem.Instance.isMoveForward = false;
                CanvasController.Instance.GameLost();
                transform.parent.gameObject.SetActive(false);
            }
            
        }

        if (other.gameObject.CompareTag("GrillPit"))
        {
            if (!isMain)
            {
                GetComponent<Rigidbody>().isKinematic = false; GetComponent<Rigidbody>().useGravity = true;
                
            }
        }
        if (other.gameObject.CompareTag("End"))
        {
            if (!isMain)
            {
                DisableBall();
            }
        }

        /*if (other.gameObject.CompareTag("EndingWalls"))
        {
            if(other.GetComponent<WallScript>().holeR == transform.localScale.x && isMain)
            {
               
                rb.isKinematic = true;
                GetComponent<SphereCollider>().isTrigger = true;
                SwerveSystem.Instance.finish = false;
                CanvasController.Instance.winPanel.SetActive(true);
                MMVibrationManager.Haptic(HapticTypes.Warning);
            }
        }*/
        


    }

    private void OnTriggerStay(Collider other)
    {

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndingWalls"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            
            
        }
    }

    public void DisableBall()
    {
        disabled = true;
        BallControlSystem.Instance.openBalls.Remove(gameObject);
        _collider.enabled = false;
        mesh.SetActive(false);
        BallControlSystem.Instance.balls.Add(gameObject);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.localPosition = GetComponent<MergeBalls>().localPos;

        if (transform.parent.GetChild(0).GetComponent<MergeBalls>().complate)
        {
            transform.localPosition = transform.parent.GetChild(0).localPosition;
        }
        
    }

    public void EnableBall()
    {
        disabled = false;
        BallControlSystem.Instance.openBalls.Add(gameObject);
        
        mesh.SetActive(true);
        BallControlSystem.Instance.balls.Remove(gameObject);
        //_collider.enabled = true;
    }


}
