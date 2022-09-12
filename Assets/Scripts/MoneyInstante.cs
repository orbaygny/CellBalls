using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInstante : MonoBehaviour
{
    public GameObject singleMoney;
    public Transform canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            Debug.Log("Ball Create ");
          GameObject tmp =  Instantiate(singleMoney,canvas);
            tmp.SetActive(true);
        }
    }
}
