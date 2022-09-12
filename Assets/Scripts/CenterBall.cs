using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterBall : MonoBehaviour
{
    public Transform centerBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        centerBall = GetClosestEnemy();
        //CamFollow.Instance.target = centerBall;
    }

    Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in transform)
        {
            float directionToTarget = potentialTarget.position.x;
            float dSqrToTarget = directionToTarget;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
