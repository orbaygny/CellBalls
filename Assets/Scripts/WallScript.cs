using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    Rigidbody rb;
    MeshCollider col;
    Vector3 startPos;
    bool calDistance;
    public Material trans;

    public float holeR;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<MeshCollider>();
        Invoke("Dis", 8);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (calDistance && Vector3.Distance(startPos,transform.position)>0)
        {
            rb.useGravity = true;
            GetComponent<MeshRenderer>().material = trans;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndingWalls") && collision.gameObject.GetComponent<Rigidbody>().useGravity)
        {
            rb.useGravity = true;
            
        }
    }

    private void Dis()
    {
        startPos = transform.position;
        calDistance = true;
    }
}
