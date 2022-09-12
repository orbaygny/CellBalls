using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball") && other.GetComponent<MergeBalls>().isMain && other.GetComponent<MergeBalls>().complate)
        {
            foreach(Transform col in transform.parent)
            {
                col.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }
}
