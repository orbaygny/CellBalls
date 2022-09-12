using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTourqe : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 vel;

    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private float MoveFactorX => _moveFactorX;
    public float swerveSpeed = 0.5f;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vel = new Vector3(0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
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
        Swerve();*/
    }

    private void FixedUpdate()
    {
        rb.AddForce(vel, ForceMode.Force);
    }

    void Swerve()
    {
        float swerveAmount = Time.fixedDeltaTime * swerveSpeed * MoveFactorX;

        if (MoveFactorX < 0)
        {
            Debug.Log("Turning");
            vel.x -= 0.2f;
            //transform.Translate(swerveAmount, 0, 0);
        }
        if (MoveFactorX > 0)
        {
            vel.x += 0.2f;
            //transform.Translate(swerveAmount, 0, 0);
        }




    }
}
    