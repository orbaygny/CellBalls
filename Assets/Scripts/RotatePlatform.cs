using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private float MoveFactorX => _moveFactorX;




    public float swerveSpeed = 0.5f;
    public float swerveMinus;
    public float swervePlus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        Swerve();
    }


    void Swerve()
    {
        float swerveAmount = Time.fixedDeltaTime * swerveSpeed * MoveFactorX;


        if (MoveFactorX <= 0 )
        {
            transform.Rotate(0, 0, swerveAmount);
            //transform.Translate(swerveAmount, 0, 0);
        }
        if (MoveFactorX > 0)
        {
            transform.Rotate(0, 0, swerveAmount);
            //transform.Translate(swerveAmount, 0, 0);
        }

    }
}
