using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine.EventSystems;
public class MergeBalls : MonoBehaviour
{
    Collider _collider;

    Transform mainBall;
    public Transform leftRig;
    public Transform middleRig;
    public Transform rightRig;
    [Space]
    Vector3 rigPos;
    Vector3 ballPos;

    public Vector3 localPos;
    float x;
    float y;
    float z;

    float mainBallScale;
    float mainBallPos;
    
    
    [Space]
    float mergeTime;
    float rigTime;
    [Space]
    public bool isMain;
    public bool complate;
    bool rewind;
    bool spin;

   
    
    public int scale;
    // Start is called before the first frame update
    void Start()
    {
        spin = true;   
        mainBall = transform.parent.GetChild(0);
        mergeTime = 0.1f / Vector3.Distance(transform.position, mainBall.position);
        rigTime = 0.1f/ Vector3.Distance(transform.position, mainBall.position);

        x = mainBall.position.x - rightRig.position.x;
        y = mainBall.position.y - rightRig.position.y;
        z = mainBall.position.z - rightRig.position.z;
        ballPos = transform.position;
        rigPos = rightRig.localPosition;
        localPos = transform.localPosition;
        _collider = GetComponent<SphereCollider>();

        //MainBallScale();
        //RigMove();

       
    }

    // Update is called once per frame
    void Update()
    {

       

        Debug.Log("TMP " + scale);



        if (!isMain)
        {
            if (spin)
            {
                transform.Rotate(Vector3.right * 500 * Time.deltaTime, Space.World);
            }
        }

        else
        {
            transform.Rotate(Vector3.right * 500 * Time.deltaTime, Space.World);
        }
        if (Input.GetMouseButtonDown(0) && !SwerveSystem.Instance.onAir &&!SwerveSystem.Instance.finish && EventSystem.current.currentSelectedGameObject == null)
        {
           
                spin = false;
                //ToMainBall();
                RigMove();
                MainBallScale();
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                // SwerveSystem.Instance.merge = false;
            

        }

        if (Input.GetMouseButtonUp(0)  && !SwerveSystem.Instance.onAir &&!SwerveSystem.Instance.finish && EventSystem.current.currentSelectedGameObject == null)
        {
            
            
                DivideBalls();
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                //SwerveSystem.Instance.divide = false;
            
           

        }
    }


    public void ToMainBall()
    {
        if (!isMain)
        {

           
            transform.DOLocalMove(mainBall.localPosition, mergeTime).SetEase(Ease.Linear).SetAutoKill(false).SetId("1").OnComplete(ResetRig);
           rightRig.DOLocalMove(mainBall.GetChild(0).GetChild(2).localPosition, mergeTime).SetEase(Ease.Linear).SetAutoKill(false).SetId("3"); 

                
            
            
        }
    }

    public void RigMove()
    {
        //Debug.Log("Rig Move");
        if (!isMain)
        {
            
            
            transform.LookAt(mainBall);
            Vector3 tmp = mainBall.GetChild(0).GetChild(1).position;
            tmp.z += 5 * rigTime;
            rightRig.DOMove(tmp, rigTime).OnComplete(ToMainBall).SetAutoKill(false).SetId("2");
            //ResetRig();
        }
    }


    public void MainBallScale()
    {
        if (isMain)
        {
            scale = BallControlSystem.Instance.openBalls.Count / 3;
            if (scale < 1) { scale = 1; }

            mainBallScale = scale * 0.1f;
            mainBallPos = scale * 0.1f;
            Debug.Log(BallControlSystem.Instance.openBalls.Count);
            transform.DOLocalMoveY(mainBallPos,0.2f).SetEase(Ease.InQuint).SetAutoKill(false).SetId("4"); 
            transform.DOScale(mainBallScale+0.2f, 0.2f).SetEase(Ease.InQuint).SetAutoKill(false).SetId("5").OnComplete(SetComplate); 
            
        }
    }

    public void ResetRig()
    {

        
        transform.rotation = Quaternion.Euler(0, 90, 0);
        _collider.enabled = false;
           // rightRig.localPosition = mainBall.GetChild(0).GetChild(2).localPosition;
           
           // rightRig.parent = transform.GetChild(0);
            


        
    }

    public void DivideBalls()
    {

        if (!isMain)
        {
            DOTween.Complete("2");
            DOTween.PlayBackwards("1");
            DOTween.PlayForward("3");
            if (!GetComponent<BallCollider>().disabled) { _collider.enabled = true; }

        }

        if (isMain)
        {
            
            //DOTween.PlayBackwards("4");
            DOTween.Complete("5");
             DOTween.Complete("4");
            transform.DOLocalMoveY(0, 0.1f).SetEase(Ease.InQuint);
            transform.DOScale(0.2f, 0.1f).SetEase(Ease.InQuint);
            complate = false;
            
        }
        mainBall.parent.transform.position = new Vector3(0, mainBall.parent.transform.position.y, mainBall.parent.transform.position.z);
        spin = true;



    }

    private void SetComplate()
    {
        complate = true;
    }

   








}
