using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
   public GameObject sibling;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball") && other.gameObject.GetComponent<MergeBalls>().complate && other.GetComponent<MergeBalls>().isMain)
        {
            if(sibling!= null)
            {
                Destroy(sibling.GetComponent<MeshCollider>());
            }
        }
    }


}
