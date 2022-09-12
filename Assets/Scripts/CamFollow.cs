using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public static CamFollow Instance { get; private set; }
    public Transform target;
    public float smootheSpeed = 0.125f;
    public Vector3 offset;

    public bool finish;
    float x;
    float fov;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Instance = this;
    }
    void Start()
    {
        x = 0;
        fov = Camera.main.fieldOfView;
    }

    private void Update()
    {

        if (finish)
        {
            //transform.rotation = Quaternion.Euler(x, 0, 0);
            //Camera.main.fieldOfView = fov;
           // x = Mathf.Lerp(x, 35, 1f* Time.deltaTime);
            offset = Vector3.Lerp(offset, new Vector3(0, 5, -16), 0.2f * Time.deltaTime);
            //fov = Mathf.Lerp(fov, 85, 3.5f * Time.deltaTime);

        }




    }
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.x = 0;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smootheSpeed);
        transform.position = smoothedPosition;
        //transform.LookAt(target);*/
    }
}
