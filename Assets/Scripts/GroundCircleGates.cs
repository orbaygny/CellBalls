using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCircleGates : MonoBehaviour
{
    MeshCollider col;
    public Material circleMat;
    public Material transMat;
    [Space]
   public GameObject mainBall;
    Material circOriginal;
    Material transOriginal;
    // Start is called before the first frame update
    void Start()
    {
        col = transform.GetChild(1).GetComponent<MeshCollider>();
        circOriginal = GetComponent<MeshRenderer>().material;
        transOriginal = transform.GetChild(1).GetComponent<MeshRenderer>().material;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (mainBall.GetComponent<MergeBalls>().complate)
        {
            GetComponent<MeshRenderer>().material = circOriginal;
            transform.GetChild(1).GetComponent<MeshRenderer>().material = transOriginal;
            if(col != null)
            {
                col.enabled = true;
            }
            


        }

        else
        {
            GetComponent<MeshRenderer>().material = circleMat;
            transform.GetChild(1).GetComponent<MeshRenderer>().material =transMat;

            if (col != null)
            {
                col.enabled = false;
            }

           
        }
    }
}
